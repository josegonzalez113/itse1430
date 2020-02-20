using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Character
    {
        public Character ( string profession )
        {
            
        }

        public static Character[] Profession ()
        {
            var professions = new Character[5];
            professions[0] = new Character("Dwarf");

        }
    }
}
