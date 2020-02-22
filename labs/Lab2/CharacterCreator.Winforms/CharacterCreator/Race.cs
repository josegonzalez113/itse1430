using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Race
    {
    }

    public class Races
    {
        // combobox array for race
        public static Character[] GetRace ()
        {
            var races = new Character[5];
            races[0] = new Character("Dwarf");
            races[0] = new Character("Elf");
            races[0] = new Character("Gnome");
            races[0] = new Character("Half Elf");
            races[0] = new Character("Human");

            return races;
        }
    }
}
