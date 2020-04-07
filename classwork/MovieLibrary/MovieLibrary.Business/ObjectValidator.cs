using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    //Only contain static members
    //Cannot create an instance
    // Rule 1 - Never create a type called ?Helper or ?Utility or ?Common
    // Rule 2 - No data
    // Rule 3 - Dont treat as global functions/variables
    public static class ObjectValidator 
    {
        public static IEnumerable<ValidationResult> TryValidate ( object value )
        {
            //this.InstanceFoo()
            StaticFoo();
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);
            return errors;
        }

        public static void Validate ( object value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);
        }

        //private void InstanceFoo ( /* ObjectValidator this */ ) { }

        private static void StaticFoo () { }

        //Global vaiables
        //private static ObjectValidator Instance = new ObjectValidator();
    }
}
