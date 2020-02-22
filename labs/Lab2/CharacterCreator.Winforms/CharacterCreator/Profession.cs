using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class Profession
    {
        public Profession ( string about )
        {
            About = about ?? "";
        }

        public string About { get; }

        public override string ToString ()
        {
            return About;
        }
    }

    public class Professions
    {
        // combobox array for profession
        public static Profession[] GetProfessions ()
        {
            var professions = new Profession[5];
            professions[0] = new Profession("Fighter");
            professions[0] = new Profession("Hunter");
            professions[0] = new Profession("Priest");
            professions[0] = new Profession("Rogue");
            professions[0] = new Profession("Wizard");

            return professions;
        }
    }
}
