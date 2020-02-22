using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Attribute
    {
        public Attribute ( string about )
        {
            About = about ?? "";
        }
        public string About { get; }

        public override string ToString ()
        {
            return About;
        }
    }
    public class Attributes
    {
        // combobox array for attributes
        public static Attribute[] GetAttributes ()
        {
            var attribues = new Attribute[5];
            attribues[0] = new Attribute("Strength");
            attribues[0] = new Attribute("Intelligence");
            attribues[0] = new Attribute("Agility");
            attribues[0] = new Attribute("Constitution");
            attribues[0] = new Attribute("Charisma");

            return attribues;
        }
    }
}
