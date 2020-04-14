using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{

    // Is-a relationship
    public abstract class MovieDatabase : IMovieDatabase
    {
        protected abstract Movie GetCore (int id);

        public Movie Add ( Movie movie )
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");
            //return null;

            //.NET validation
            ObjectValidator.Validate(movie);

            //Movie names must be unique
            try
            {
                var existing = FindByTitle(movie.Title);
                if (existing != null)
                    throw new InvalidOperationException("Movie must be unique");

                return AddCore(movie);
            } catch (InvalidOperationException)
            {
                //Rethrow exception
                throw;
            } catch (Exception e)
            {
                //Rewrite exception with original exception as the inner exception
                throw new InvalidOperationException("Error adding movie", e);
            };
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            // TODO: Error
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            return GetCore(id);
        }

        public IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();

        protected abstract IEnumerable<Movie> GetAllCore ();

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        //Todo: Shouldn't need the original movie
        public string Update ( int id, Movie movie )
        {
            //if (movie == null)
            //  return "Movie is null";
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");

            ObjectValidator.Validate(movie);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            //return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                throw new ArgumentException("Movie not found", nameof(id));
            //return "Movie not found";

            //Movie names must be unique
            var sameName = FindByTitle(movie.Title);
            if (sameName != null && sameName.Id != id)
                throw new InvalidOperationException("Movie must be unique");
            //return "Movie must be unique";

            UpdateCore(id, movie);

            return null;
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

        protected abstract Movie FindById ( int id );
    }
}
