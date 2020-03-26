using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.Memory
{
    //public interface ISelectableObject
    //{
    //    void Select ();
    //}

    //public interface IResizableObject
    //{
    //    void Resize ( int width, int height );
    //}

    //public struct SelectableResizableObject : IResizableObject, ISelectableObject
    //{
    //    public void Resize ( int width, int height );
    //    public void Select ();
    //}

    // Is-a relationship
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie GetCore ( int id )
        {

            var movie = FindById(id);
            if (movie == null)
                return null;

            return CloneMovie(movie);
        }

        protected override Movie AddCore ( Movie movie )
        {
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

        protected override void DeleteCore ( int id )
        {
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

        protected override IEnumerable<Movie> GetAllCore ()
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
        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);

            CopyMovie(existing, movie, false);

        }

        protected override Movie FindByTitle ( string title )
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
        protected override Movie FindById ( int id )
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
