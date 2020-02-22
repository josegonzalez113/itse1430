using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Profession
    {
    }

    public class Characters
    {
        // combobox array for profession
        public static Character[] GetProfessions ()
        {
            var professions = new Character[5];
            professions[0] = new Character("Fighter");
            professions[0] = new Character("Hunter");
            professions[0] = new Character("Priest");
            professions[0] = new Character("Rogue");
            professions[0] = new Character("Wizard");

            return professions;
        }
    }
}
