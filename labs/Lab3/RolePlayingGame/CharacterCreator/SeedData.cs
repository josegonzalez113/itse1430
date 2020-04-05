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
                var example = new Character() { Name = "Jose", Description = "hello" };
                var items = new[]
                {
                    new Character() { Name = "Michelle", Description = "hello"},
                    example,
                };

                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}
