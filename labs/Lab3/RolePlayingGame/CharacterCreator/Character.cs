using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public int Id { get; set; }

        public Profession Profession { get; set; }
        public Race Race { get; set; }
        public Attribute Attribute { get; set; }

        public Power Power { get; set; }

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

        int IValidatableObject.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Profession IValidatableObject.Profession { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Race IValidatableObject.Race { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Attribute IValidatableObject.Attribute { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IValidatableObject.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IValidatableObject.Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private string _description;

        

    public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name)});
            };

            /*// Profession
            if (String.IsNullOrEmpty(Profession.About))
            {
                yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });
            };
            // Race
            if (String.IsNullOrEmpty(Race.About))
            {
                yield return new ValidationResult("Race is required", new[] { nameof(Profession) });
            };
            // Attribute
            if (String.IsNullOrEmpty(Attribute.About))
            {
                yield return new ValidationResult("Attribute is required", new[] { nameof(Profession) });
            };*/

        }

        bool IValidatableObject.Validate ( out string error )
        {
            throw new NotImplementedException();
        }
    }
}
