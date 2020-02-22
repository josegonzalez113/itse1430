using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public Character Character;
        public Character ( string about )
        {
            About = about ?? "";
        }

        public string About { get; }

        public override string ToString ()
        {
            return About;
        }

        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        private string _name;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;
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
