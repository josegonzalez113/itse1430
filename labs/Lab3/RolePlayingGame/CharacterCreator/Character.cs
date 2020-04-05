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
        public Power1 Power1 { get; set; }
        public Power2 Power2 { get; set; }


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
        }
    }
}

// The code below was removed from the Validate() method...
// For some reason i can't hit the (save) button after "editing" an existing character-
// unless i re-pick the values for each combobox even if they already have a value. 
// !!Textbox work perfectly fine!!
/*
    // Profession
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
    };
    // Power
    if (String.IsNullOrEmpty(Power.About))
    {
        yield return new ValidationResult("Power is required", new[] { nameof(Power) });
    };

*/

    // However validation from the CharacterForm side-
    // does require you to pick a value for each field except the description because its optinal.