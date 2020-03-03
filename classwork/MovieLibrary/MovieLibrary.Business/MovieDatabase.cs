using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class MovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            // Validate
            if (movie == null)
                return null;
            if (!movie.Validate(out var error))
                return null;
            // Movie names must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                return null;
            //TODO: Clone movie to store
            var item = CloneMovie(movie);

            for (var index = 0; index< _movies.Length; ++index)
            {
                if (_movies[index] == null)
                {
                    _movies[index] = item;
                    item.Id = _id++;

                    return CloneMovie(item);
                };
            };
            return null;
        }

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;
            //TODO: Find better way to find movie
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index]?.Id == id)
                {
                    _movies[index] = null;
                    return;
                };
            };
        }

        public Movie[] GetAll ()
        {
            //TODO: Clone objects
            return _movies;
        }

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        //Todo: Shouldn't need the original movie
        public void Update (int id, Movie newMovie )
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index]?.Id == id)
                {
                    _movies[index] = newMovie;
                    break;
                };
            };
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

        private Movie CloneMovie (Movie movie)
        {
            //Object init syntax, less code
            return new Movie() {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = new Genre(movie.Genre.Description),
                IsClassic = movie.IsClassic,
                ReleaseYear = movie.ReleaseYear,
                RunLength = movie.RunLength,
            };   
        }

        private readonly Movie[] _movies = new Movie[100];
        private int _id = 1;
    }
}
