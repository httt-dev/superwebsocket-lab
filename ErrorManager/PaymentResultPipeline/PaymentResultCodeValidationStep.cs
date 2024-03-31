using ErrorManager.Opos;
using ErrorManager.ResultPipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ErrorManager.ResultPipeline.ValidationTransactionResult;

namespace ErrorManager.PaymentResultPipeline
{
    public class PaymentResultCodeValidationStep : IResultValidationStep<NDCResponseResult>
    {
        public ValidationTransactionResult Validate(NDCResponseResult ndcResponseResult)
        {
            TransactionResultBuilder transactionResultBuilder = new TransactionResultBuilder();
            TransactionResultBuilder builder = ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult);

            if (ndcResponseResult.IsErrorEvent())
            {
                // ton tai ResultCodeExtended
                if (ndcResponseResult.HasResultCodeIsExtended())
                {
                    return ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult)
                                        .SetIsValidateFinished(false)
                                        .SetResult(TransactionResult.UnSet)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "" })
                                        .Build();
                }
                // dua vao ResultCode de xac dinh thong tin loi thuoc loai nao , su dung message nao
                switch (ndcResponseResult.CallBackResponse.ResultCode)
                {
                    case OposResultCode.OPOS_E_CLOSED:
                    case OposResultCode.OPOS_E_NOTCLAIMED:
                    case OposResultCode.OPOS_E_NOSERVICE:
                    case OposResultCode.OPOS_E_DISABLED:
                    case OposResultCode.OPOS_E_ILLEGAL:
                    case OposResultCode.OPOS_E_NOHARDWARE:
                    case OposResultCode.OPOS_E_NOEXIST:
                    case OposResultCode.OPOS_E_FAILURE:
                    case OposResultCode.OPOS_E_BUSY:
                        // その他(不成立)
                        builder.SetIsValidateFinished(true)
                                        .SetResult(TransactionResult.OtherError)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CS01" });
                        break;
                    case OposResultCode.OPOS_E_TIMEOUT:
                    case OposResultCode.Undefined:
                        // POS受信エラー
                        builder.SetIsValidateFinished(true)
                                        .SetResult(TransactionResult.PosReceiveError)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CC99" });
                        break;
                }

            }


            return transactionResultBuilder.Build();
        }

    }
}
