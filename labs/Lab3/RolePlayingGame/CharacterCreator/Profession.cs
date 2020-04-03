using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Profession
    {
        public Profession ( string about )
        {
            About = about ?? "";
        }
        public string About { get; }
        public override string ToString () => About;
    }

    public class Professions
    {
        // combobox array for profession
        public static Profession[] GetProfession ()
        {
            var professions = new Profession[5];
            professions[0] = new Profession("Fighter");
            professions[1] = new Profession("Hunter");
            professions[2] = new Profession("Priest");
            professions[3] = new Profession("Rogue");
            professions[4] = new Profession("Wizard");

            return professions;
        }
    }
}
