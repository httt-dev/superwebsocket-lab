using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.ResultPipeline
{
    public class TransactionResultValidationPipeline<T>
    {
        private readonly List<IResultValidationStep<T>> _steps = new List<IResultValidationStep<T>>();

        public void AddStep(IResultValidationStep<T> step) {  _steps.Add(step); }

        public ValidationTransactionResult ValidateProcess(T obj)
        {
            ValidationTransactionResult result = new ValidationTransactionResult();

            foreach (var step in _steps)
            {
                result = step.Validate(obj);
                if (!result.IsValidateFinished)
                    return result;
            }

            return result;

        }
    }
}
