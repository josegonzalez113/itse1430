using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public interface IValidatableObject
    {
        int Id { get; set; }

        Profession Profession { get; set; }
        Race Race { get; set; }
        Attribute Attribute { get; set; }

        string Name { get; set; }

        string Description {get; set;}

        bool Validate(out string error);
    }
}
