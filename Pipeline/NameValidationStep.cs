using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    public class NameValidationStep : IValidationStep<MyObject>
    {
        public ValidationResult Validate(MyObject obj)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrEmpty(obj.Name))
            {
                validationResult.IsValid = false;
                validationResult.ErrorCode = "NAME_EMPTY";
                validationResult.ErrorMessage = "Name cannot be empty.";
            }
            else
            {
                // Other validation rules for Name
                validationResult.IsValid = true;
            }

            return validationResult;
        }
    }
}
