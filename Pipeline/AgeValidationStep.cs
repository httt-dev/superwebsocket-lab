using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    public class AgeValidationStep : IValidationStep<MyObject>
    {
        public ValidationResult Validate(MyObject obj)
        {
            var validationResult = new ValidationResult();

            if (obj.Age <= 0)
            {
                validationResult.IsValid = false;
                validationResult.ErrorCode = "INVALID_AGE";
                validationResult.ErrorMessage = "Age must be greater than zero.";
            }
            else
            {
                // Other validation rules for Age
                validationResult.IsValid = true;
            }

            return validationResult;
        }

    }
}
