using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Power
    {
        public Power ( string about )
        {
            About = about ?? "";
        }

        public string About { get; }

        public override string ToString ()
        {
            return About;
        }
    }

    public class Powers
    {
        // combobox array for powers
        public static Power[] GetAttributePower ()
        {
            var power = new Power[5];
            power[0] = new Power("20");
            power[1] = new Power("21");
            power[2] = new Power("22");
            power[3] = new Power("23");
            power[4] = new Power("24");

            return power;
        }

        public static Power[] GetRacePower ()
        {
            var power = new Power[5];
            power[0] = new Power("30");
            power[1] = new Power("31");
            power[2] = new Power("32");
            power[3] = new Power("33");
            power[4] = new Power("34");

            return power;
        }

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
    }
}
