using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    public class ValidationPipeline<T>
    {
        private readonly List<IValidationStep<T>> _steps = new List<IValidationStep<T>>();

        public void AddStep(IValidationStep<T> step)
        {
            _steps.Add(step);
        }

        public ValidationResult Validate(T obj)
        {
            foreach (var step in _steps)
            {
                var result = step.Validate(obj);
                if (!result.IsValid)
                    return result;
            }
            return new ValidationResult { IsValid = true};
        }
    }
}
