using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            get => _name ?? "";
            set => _name = value?.Trim();
        }
        private string _name;

        public string Description
        {
            get => _description ?? "";
            set => _description = value?.Trim();
        }
        private string _description;

        public override string ToString () => Name;


        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
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
    }
}
