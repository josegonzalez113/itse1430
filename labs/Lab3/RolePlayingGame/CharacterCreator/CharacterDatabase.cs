using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase : ICharacterRoster
    {

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;

        public Character Add ( Character character )
        {
            // Validate
            if (character == null)
                return null;
            if (!character.Validate(out var error))
                return null;
            // Character names must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
                return null;
            //TODO: Clone character to store
            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return CloneCharacter(item);
        }

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;

            //TODO: Find better way to find character
            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        public Character Get ( int id )
        {
            // TODO: Error
            if (id <= 0)
                return null;

            var character = FindById(id);
            if (character == null)
                return null;

            return CloneCharacter(character);
        }

        public Character[] GetAll ()
        {
            //TODO: Clone objects
            var items = new Character[_characters.Count];
            var index = 0;
            foreach (var character in _characters)
            {
                items[index++] = CloneCharacter(character);
            }
            return items;
        }

        public string Update ( int id, Character character )
        {
            // Validate
            if (character == null)
                return "Character is null";
            if (!character.Validate(out var error))
                return error;
            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "Character not found";

            // Movie names must be unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Character must be unique";

            // Update
            CopyCharacter(existing, character, false);

            return null;
        }

        // helper method for the Update() method.
        private Character FindByName ( string name )
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character?.Name, name, true) == 0)
                    return character;
            }
            return null;
        }

        // helper method for the GetAll() method.
        private Character CloneCharacter ( Character character )
        {

            var item = new Character();
            CopyCharacter(item, character, true);

            return item;
        }

        // helper method for the Update() method.
        private Character FindById ( int id )
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character;
            }
            return null;
        }

        // helper method for the Update() method.
        private void CopyCharacter ( Character target, Character source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;

            if (source.Profession != null)
            {
                target.Profession = new Profession(source.Profession.About);
            } else
                target.Profession = null;

            if (source.Race != null)
            {
                target.Race = new Race(source.Race.About);
            } else
                target.Race = null;

            if (source.Attribute != null)
            {
                target.Attribute = new Attribute(source.Attribute.About);
            } else
                target.Attribute = null;
        }
    }
}
