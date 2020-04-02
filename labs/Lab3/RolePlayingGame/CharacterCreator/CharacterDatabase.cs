using System.Collections.Generic;
using System.Linq;

namespace CharacterCreator
{
    public abstract class CharacterDatabase : ICharacterRoster
    {

        public Character Get ( int id )
        {
            // TODO: Error
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Character GetCore (int id);

        public Character Add ( Character character )
        {
            // Validate
            if (character == null)
                return null;

            // .Net validation
            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return null;

            //TODO: Clone character to store
            var item = FindByName(character.Name);
            if (item != null)
                return null;

            return AddCore(item);
        }

        protected abstract Character AddCore ( Character character);

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public IEnumerable<Character> GetAll () => GetAllCore() ?? Enumerable.Empty<Character>();

        protected abstract IEnumerable<Character> GetAllCore ();

        public string Update ( int id, Character character )
        {
            // Validate
            if (character == null)
                return "The updated character is invalid";

            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                //if (!movie.Validate(out var error))

                if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "The existing character cannot be found or is invalid";

            // Movie names must be unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Character with the same name already exists";

            // Update
            UpdateCore(id, character);

            return null;
        }

        protected abstract void UpdateCore ( int id, Character movie );

        // helper method for the Update() method.
        protected abstract Character FindByName ( string name );

        protected abstract Character FindById ( int id );
    }
}
