using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator;

namespace CharacterLibrary.FileSystem
{
    public class FileCharacterDatabase : CharacterDatabase
    {
        public FileCharacterDatabase ( string filename )
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));  //"filename"
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            _filename = filename;
        }

        protected override Character AddCore ( Character character )
        {
            EnsureLoaded();
            character.Id = (_items.Any() ? _items.Max(c => c.Id) : 0) + 1;

            _items.Add(character);
            SaveCharacters();

            return character;
        }

        private void EnsureLoaded ()
        {
            if (_items == null)
                GetAllCore();
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);
            if (character != null)
            {
                _items.Remove(character);
                SaveCharacters();
            };
        }

        protected override Character GetCore ( int id )
        {
            if (!File.Exists(_filename))
                return null;

            using (var reader = new StreamReader(_filename))
            {                 
                while (!reader.EndOfStream)
                {
                    //reader.ReadToEnd();
                    var line = reader.ReadLine();
                    var character = LoadCharacter(line);
                    if (character?.Id == id)
                        return character;
                };
            };
            return null;
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            _items = new List<Character>();

            if (File.Exists(_filename))
            {
                try
                {
                    var character = LoadMovies();

                    _items.AddRange(character);
                } catch (FileNotFoundException)
                { /* Ignore */ };
            };
            return _items;
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Character not found");

            _items.Remove(existing);

            character.Id = id;
            _items.Add(character);

            SaveCharacters();
        }

        protected override Character FindByName ( string name )
        {
            EnsureLoaded();
            return _items.FirstOrDefault(c => String.Compare(c.Name, name, true) == 0);
        }
        protected override Character FindById ( int id )
        {
            EnsureLoaded();
            return _items.FirstOrDefault(c => c.Id == id);
        }

        private IEnumerable<Character> LoadMovies ()
        {           
            var lines = File.ReadAllLines(_filename);
            foreach (var line in lines)
            {
                var character = LoadCharacter(line);
                if (character != null)
                    yield return character;
            };
        }
        private void SaveCharacters ()
        {
            var lines = new List<string>();
            foreach (var charcater in _items)
            {
                var line = SaveCharacter(charcater);
                if (!String.IsNullOrEmpty(line))
                    lines.Add(line);
            };
            File.WriteAllLines(_filename, lines);
        }

        private Character LoadCharacter ( string line )
        {
            var tokens = line.Split(',');

            if (tokens.Length != 7)
                return null;

            if (!Int32.TryParse(tokens[0], out var id) || id <= 0)
                return null;

            var name = UnquotedString(tokens[1]);
            if (String.IsNullOrEmpty(name))
                return null;

            var description = UnquotedString(tokens[2]);
            var genre = UnquotedString(tokens[3]);

            return new Character() {
                Id = id,
                Name = name,
                Description = description,
               // Profession = !String.IsNullOrEmpty(profession) ? new Profession(profession) : null, // TODO: figure out the error
            };
        }

        private string SaveCharacter ( Character character )
        {
            //CSV - comma separate values - Id, Title, Description, ...
            return $"{character.Id}, {QuotedString(character.Name)}, {QuotedString(character.Description)}, {QuotedString(character.Profession?.About)},{QuotedString(character.Attribute?.About)},{QuotedString(character.Race?.About)}";
        }

        private static string QuotedString ( string value ) => $"\"{value}\"";

        private static string UnquotedString ( string value ) => value?.Trim('"', ' ', '\t') ?? "";

        private List<Character> _items;
        private readonly string _filename;
    }
}
}
