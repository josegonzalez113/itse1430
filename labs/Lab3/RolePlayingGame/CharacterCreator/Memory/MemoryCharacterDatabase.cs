using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterCreator
{
    public class MemoryCharacterDatabase : CharacterDatabase
    {
        protected override Character GetCore ( int id )
        {
            var character = FindById(id);
            if (character == null)
                return null;

            return CloneCharacter(character);
        }

        protected override Character AddCore ( Character character )
        {
            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return CloneCharacter(item);
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            // Filtering
            var items = _characters.Where(c => true);

            //Transform
            return _characters.Select(c => CloneCharacter(c));
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var item = FindById(id);

            // Update
            CopyCharacter(item, character, false);
        }

        protected override Character FindByName ( string name ) => (from character in _characters
                                                                  where String.Compare(character.Name, name, true) == 0
                                                                  select character).FirstOrDefault();
        private Character CloneCharacter ( Character character )
        {

            var item = new Character();
            CopyCharacter(item, character, true);

            return item;
        }

        protected override Character FindById ( int id ) => _characters.FirstOrDefault(c => c.Id == id);

         private void CopyCharacter ( Character target, Character source, bool includeId )
        {

            if (includeId)
                target.Id = source.Id;
                target.Name = source.Name;
                target.Description = source.Description;
            //profession
            if (source.Profession != null)
                target.Profession = new Profession(source.Profession.About);
            else
                target.Profession = null;
            //Race
            if (source.Race != null)
                target.Race = new Race(source.Race.About);
            else
                target.Race = null;
            //Attributes
            if (source.Attribute != null)
                target.Attribute = new Attribute(source.Attribute.About);
            else
                target.Attribute = null;
            //Power
            if (source.Power != null)
                target.Power = new Power(source.Power.About);
            else
                target.Power = null;
        }

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}
