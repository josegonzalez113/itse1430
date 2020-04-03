using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public static class SeedData
    {
        public static ICharacterRoster SeedIfEmpty ( this ICharacterRoster database )
        {
            if (!database.GetAll().Any())
            {
                // Collection initializer syntax- works with anything with an Add method
                var example = new Character() { Name = "Jose"};
                var items = new[]
                {
                    new Character() { Name = "Michelle"},
                    example,
                };

                //var character = new Characeter();
                //character.Name = "Jaws";
                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}
