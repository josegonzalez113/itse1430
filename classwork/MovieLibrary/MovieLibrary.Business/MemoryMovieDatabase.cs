using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{

    // Is-a relationship
    public class MemoryMovieDatabase : IMovieDatabase
    {
        public Movie Get ( int id )
        {
            // TODO: Error
            if (id <= 0)
                return null;

            var movie = FindById(id);
            if (movie == null)
                return null;

            return CloneMovie(movie);
        }

        public Movie Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //.NET validation
            var errors = new ObjectValidator().Validate(movie);
            if (errors.Any())
                //if (!Validator.TryValidateObject(movie, new ValidationContext(movie), errors, true))
                //if (!movie.Validate(out var error))
                return null;

            //Movie names must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                return null;

            //TODO: Clone movie to store     
            var item = CloneMovie(movie);
            item.Id = _id++;
            _movies.Add(item);
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index] == null)
            //    {
            //        _movies[index] = item;
            //        item.Id = _id++;

            //        return CloneMovie(item);
            //    };
            //};

            return CloneMovie(item);
        }

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;

            //TODO: Find better way to find movie
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);

            /*for (var index = 0; index < _movies.Count; ++index)
            {
                if (_movies[index]?.Id == id)
                {
                    _movies[index] = null;
                    return;
                };
            };*/
        }

        public IEnumerable<Movie> GetAll ()
        {
            //return _movies;
            //TODO: Clone objects
            /*var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
            {
                items[index++] = CloneMovie(movie);
            }
            return items;*/

            //Use an iterator Luke
            foreach (var movie in _movies)
            {
                yield return CloneMovie(movie);
            };
        }

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        //Todo: Shouldn't need the original movie
        public string Update ( int id, Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return "Movie is null";

            //TODO: Fix this
            var errors = new ObjectValidator().Validate(movie);
            if (errors.Any())
                //if (!movie.Validate(out var error))
                return "Error";

            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "Movie not found";

            //Movie names must be unique
            var sameName = FindByTitle(movie.Title);
            if (sameName != null && sameName.Id != id)
                return "Movie must be unique";

            //Update
            CopyMovie(existing, movie, false);

            return null;
        }

        private Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie?.Title, title, true) == 0)
                    return movie;
            }
            return null;
        }

        private Movie CloneMovie ( Movie movie )
        {

            var item = new Movie();
            CopyMovie(item, movie, true);

            return item;

            /*//Object init syntax, less code
            return new Movie() {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = new Genre(movie.Genre.Description),
                IsClassic = movie.IsClassic,
                ReleaseYear = movie.ReleaseYear,
                RunLength = movie.RunLength,
            };*/
        }
        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            }
            return null;
        }


        private void CopyMovie ( Movie target, Movie source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            if (source.Genre != null)
                target.Genre = new Genre(source.Genre.Description);
            else
                target.Genre = null;
            target.IsClassic = source.IsClassic;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
        }

        //private readonly Movie[] _movies = new Movie[100];
        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
