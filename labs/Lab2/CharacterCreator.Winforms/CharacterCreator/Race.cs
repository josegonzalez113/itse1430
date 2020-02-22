using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Race
    {
        public Race ( string about )
        {
            About = about ?? "";
        }

        public string About { get; }

        public override string ToString ()
        {
            return About;
        }
    }

    public class Races
    {
        // combobox array for race
        public static Race[] GetRace ()
        {
            var races = new Race[5];
            races[0] = new Race("Dwarf");
            races[0] = new Race("Elf");
            races[0] = new Race("Gnome");
            races[0] = new Race("Half Elf");
            races[0] = new Race("Human");

            return races;
        }
    }
}
