using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    public class ObjectValidator 
    {
        public IEnumerable<ValidationResult> Validate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);
            return errors;
        }
    }
}
