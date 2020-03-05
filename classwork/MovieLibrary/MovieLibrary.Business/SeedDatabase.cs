using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class SeedDatabase
    {
        public IMovieDatabase SeedIfEmpty (IMovieDatabase database)
        {
            if (database.GetAll().Length == 0)
            {
                database.Add(new Movie() { Title = "Jaws", RunLength = 60, ReleaseYear = 2000 });
                database.Add(new Movie() { Title = "Avatar", RunLength = 60, ReleaseYear = 2000 });
                database.Add(new Movie() { Title = "Hello", RunLength = 60, ReleaseYear = 2000 });
            };

            return database;
        }
    }
}
