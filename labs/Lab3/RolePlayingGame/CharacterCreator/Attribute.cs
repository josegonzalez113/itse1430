using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Attribute
    {
        public Attribute ( string about, string power)
        {
            About = about ?? "";
        }

        public string About { get; }
        public string Info { get; }

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
            attribues[0] = new Attribute("Strength", "");
            attribues[1] = new Attribute("Intelligence", "");
            attribues[2] = new Attribute("Agility", "");
            attribues[3] = new Attribute("Constitution", "");
            attribues[4] = new Attribute("Charisma", "");

            return attribues;
        }

        public static Attribute[] GetAttributePower ()
        {
            var power = new Attribute[5];
            power[0] = new Attribute("", "20");
            power[1] = new Attribute("", "21");
            power[2] = new Attribute("", "22");
            power[3] = new Attribute("", "23");
            power[4] = new Attribute("", "24");

            return power;
        }
    }
}
