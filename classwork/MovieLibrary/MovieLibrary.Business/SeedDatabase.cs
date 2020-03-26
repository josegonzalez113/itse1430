using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public static class SeedDatabase
    {
        //Extension method - are static methods of static classes that appear as instance members on the applied type
        // Rule 1: Must be static method
        // Rule 2: Owning type mst be static
        // Rule 3: The first parameter must be proceeded with keyword 'this'
        // Rule 4: Should behave just like instance member
        // Rule 5: Do not add frivalous methods to core types
        public static IMovieDatabase SeedIfEmpty ( this IMovieDatabase database )
        {
            if (!database.GetAll().Any())
            {
                // Collection initializer syntax- works with anything with an Add method
                var demo = new Movie() { Title = "Dune", RunLength = 260, ReleaseYear = 1985 };
                var items = new []
                {
                    new Movie() { Title = "Jaws", RunLength = 210, ReleaseYear = 1977 },
                    new Movie() { Title = "Jaws 2", RunLength = 220, ReleaseYear = 1979 },
                    demo,
                };

                //var movie = new Movie();
                //movie.Title = "Jaws";
                //movie.RunLength = 210;
                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}
