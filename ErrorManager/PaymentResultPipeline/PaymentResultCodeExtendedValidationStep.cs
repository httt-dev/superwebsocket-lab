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
    public class PaymentResultCodeExtendedValidationStep : IResultValidationStep<NDCResponseResult>
    {
        public ValidationTransactionResult Validate(NDCResponseResult ndcResponseResult, ValidationTransactionResult previousResult)
        {
            TransactionResultBuilder transactionResultBuilder = new TransactionResultBuilder();
            TransactionResultBuilder builder = ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult);

            if (ndcResponseResult.IsErrorEvent())
            {
                // khong ton tai ResultCodeExtended
                if (ndcResponseResult.HasResultCodeIsExtended() == false)
                {
                    return ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult)
                                        .SetIsValidateFinished(false)
                                        .SetResult(TransactionResult.UnSet)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "" })
                                        .Build();
                }
                // dua vao ResultCode de xac dinh thong tin loi thuoc loai nao , su dung message nao
                switch (ndcResponseResult.CallBackResponse.ResultCodeExtended)
                {
                    case OposResultCodeExtended.Code_20:

                    case OposResultCodeExtended.Code_21:

                    case OposResultCodeExtended.Code_91:

                    case OposResultCodeExtended.Code_1010:
                    case OposResultCodeExtended.Code_1020:
                    case OposResultCodeExtended.Code_1030:
                    case OposResultCodeExtended.Code_1050:
                    case OposResultCodeExtended.Code_1060:
                        // その他(不成立)
                        builder.SetIsValidateFinished(true)
                                        .SetResult(TransactionResult.OtherError)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CS01" });
                        break;
                    case OposResultCodeExtended.Code_1040:
                        // 決済中断
                        // ※ResultCodeExtended = 21 (自動取消) 参照
                        builder.SetIsValidateFinished(true)
                                        .SetResult(TransactionResult.PaymentInterruptError)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CS02" });
                        break;
                    case OposResultCodeExtended.Undefined:
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
