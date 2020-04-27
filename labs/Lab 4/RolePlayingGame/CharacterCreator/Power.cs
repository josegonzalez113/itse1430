using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Power // Profession
    {
        public Power ( string about ) => About = about ?? "";

        public string About { get; }

        public override string ToString () => About;
    }

    public class Power1 // Race
    {
        public Power1 ( string about ) => About = about ?? "";

        public string About { get; }

        public override string ToString () => About;
    }

    public class Power2 // Attribute
    {
        public Power2 ( string about ) => About = about ?? "";

        public string About { get; }

        public override string ToString () => About;
    }

    public class Powers
    {        
        // combobox array for powers
        public static Power[] GetProfessionPower ()
        {
            var power = new Power[5];
            power[0] = new Power("36");
            power[1] = new Power("37");
            power[2] = new Power("38");
            power[3] = new Power("39");
            power[4] = new Power("40");

            return power;
        }
        public static Power1[] GetRacePower ()
        {
            var power = new Power1[5];
            power[0] = new Power1("30");
            power[1] = new Power1("31");
            power[2] = new Power1("32");
            power[3] = new Power1("33");
            power[4] = new Power1("34");

            return power;
        }
        public static Power2[] GetAttributePower ()
        {
            var power = new Power2[5];
            power[0] = new Power2("20");
            power[1] = new Power2("21");
            power[2] = new Power2("22");
            power[3] = new Power2("23");
            power[4] = new Power2("24");

            return power;
        }
    }
}
