using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.ResultPipeline
{
    public interface IResultValidationStep<T>
    {
        ValidationTransactionResult Validate(T obj , ValidationTransactionResult previousResult);
    }
}
