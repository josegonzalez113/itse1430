using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Attribute
    {
    }
    public class Attributes
    {
        // combobox array for attributes
        public static Character[] GetAttributes ()
        {
            var attribues = new Character[5];
            attribues[0] = new Character("Strength");
            attribues[0] = new Character("Intelligence");
            attribues[0] = new Character("Agility");
            attribues[0] = new Character("Constitution");
            attribues[0] = new Character("Charisma");

            return attribues;
        }
    }
}
