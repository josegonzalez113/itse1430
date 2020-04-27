using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CharacterCreator
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate ( object value )
        {
            StaticFoo();
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);
            return errors;
        }

        private static void StaticFoo () { }
    }
}
