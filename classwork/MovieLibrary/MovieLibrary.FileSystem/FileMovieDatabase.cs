using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.FileSystem
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));  //"filename"
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            _filename = filename;
        }

        protected override Movie AddCore ( Movie movie )
        {
            EnsureLoaded();
            movie.Id = (_items.Any() ? _items.Max(m => m.Id) : 0) + 1;

            _items.Add(movie);
            SaveMovies();

            return movie;
        }

        private void EnsureLoaded ()
        {
            if (_items == null)
                GetAllCore();
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
            {
                _items.Remove(movie);
                SaveMovies();
            };
        }

        protected override Movie GetCore ( int id )
        {
            if (!File.Exists(_filename))
                return null;

            //IOException
            //var stream = File.OpenRead(_filename);

            //IDisposable syntax
            //Using statement takes an IDisposable expression and guarantees call to Dispose
            //Equivalent to try-finally
            //using (var reader = new StreamReader(stream))
            using (var reader = new StreamReader(_filename))
            {
                //SR is the textual stream reader
                //StreamWriter - writing textual streams
                //BinaryReader - reading binary data
                //BinaryWriter - writing binary data                    
                while (!reader.EndOfStream)
                {
                    //reader.ReadToEnd();
                    var line = reader.ReadLine();
                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };
            };

            //// Read the stream using ReadLine
            //try
            //{
            //    //SR is the textual stream reader
            //    //StreamWriter - writing textual streams
            //    //BinaryReader - reading binary data
            //    //BinaryWriter - writing binary data
            //    reader = new StreamReader(stream);
            //    while (!reader.EndOfStream)
            //    {
            //        //reader.ReadToEnd();
            //        var line = reader.ReadLine();
            //        var movie = LoadMovie(line);
            //        if (movie?.Id == id)
            //            return movie;
            //    };
            //} finally
            //{
            //    reader.Close();
            //    //stream.Close();  //CLosed automatically be reader
            //};

            return null;
        }


        protected override IEnumerable<Movie> GetAllCore ()
        {
            _items = new List<Movie>();

            if (File.Exists(_filename))
            {
                try
                {
                    var movies = LoadMovies();

                    _items.AddRange(movies);
                } catch (FileNotFoundException)
                { /* Ignore */ };
            };

            return _items;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Movie not found");

            _items.Remove(existing);

            movie.Id = id;
            _items.Add(movie);

            SaveMovies();
        }

        protected override Movie FindByTitle ( string title )
        {
            EnsureLoaded();

            return _items.FirstOrDefault(m => String.Compare(m.Title, title, true) == 0);
        }
        protected override Movie FindById ( int id )
        {
            EnsureLoaded();

            return _items.FirstOrDefault(m => m.Id == id);
        }

        private IEnumerable<Movie> LoadMovies ()
        {
            //Buffered approach
            //var data = File.ReadAllBytes(_filename);
            //var text = File.ReadAllText(_filename);            
            var lines = File.ReadAllLines(_filename);
            foreach (var line in lines)
            {
                var movie = LoadMovie(line);
                if (movie != null)
                    yield return movie;
            };
        }
        private void SaveMovies ()
        {
            var lines = new List<string>();
            foreach (var movie in _items)
            {
                var line = SaveMovie(movie);
                if (!String.IsNullOrEmpty(line))
                    lines.Add(line);
            };

            //File.WriteAllBytes(_filename, data);
            //File.WriteAllText(_filename, "");
            File.WriteAllLines(_filename, lines);
        }

        private Movie LoadMovie ( string line )
        {
            var tokens = line.Split(',');

            if (tokens.Length != 7)
                return null;

            if (!Int32.TryParse(tokens[0], out var id) || id <= 0)
                return null;

            var title = UnquotedString(tokens[1]);
            if (String.IsNullOrEmpty(title))
                return null;

            var description = UnquotedString(tokens[2]);
            var genre = UnquotedString(tokens[3]);

            if (!Int32.TryParse(tokens[4], out var releaseYear))
                return null;

            if (!Int32.TryParse(tokens[5], out var runLength))
                return null;

            if (!Boolean.TryParse(tokens[6], out var isClassic))
                return null;

            return new Movie() {
                Id = id,
                Title = title,
                Description = description,
                Genre = !String.IsNullOrEmpty(genre) ? new Genre(genre) : null,
                ReleaseYear = releaseYear,
                RunLength = runLength,
                IsClassic = isClassic
            };
        }

        private string SaveMovie ( Movie movie )
        {
            //CSV - comma separate values - Id, Title, Description, ...
            return $"{movie.Id}, {QuotedString(movie.Title)}, {QuotedString(movie.Description)}, {QuotedString(movie.Genre?.Description)}, {movie.ReleaseYear}, {movie.RunLength}, {movie.IsClassic}";
        }


        private static string QuotedString ( string value ) => $"\"{value}\"";

        private static string UnquotedString ( string value ) => value?.Trim('"', ' ', '\t') ?? "";

        private List<Movie> _items;
        private readonly string _filename;
    }
}
