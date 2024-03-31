using ErrorManager.ResultPipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ErrorManager.ResultPipeline.ValidationTransactionResult;

namespace ErrorManager.PaymentResultPipeline
{
    public class PaymentSeqNumberValidationStep : IResultValidationStep<NDCResponseResult>
    {
        public ValidationTransactionResult Validate(NDCResponseResult ndcResponseResult)
        {
            TransactionResultBuilder transactionResultBuilder = new TransactionResultBuilder();

            // check here
            if (ndcResponseResult == null)
            {
                //POS受信エラー
                return ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult)
                                        .SetIsValidateFinished(true)
                                        .SetResult(TransactionResult.PosReceiveError)
                                        .SetErrorCodeInfo(new ErrorCodeInfo { MessageID="CC99"})
                                        .Build();
            }

            if (ndcResponseResult.IsOutputCompleteEvent())
            {
                transactionResultBuilder = OutputCompleteEventCheck(ndcResponseResult);
            }

            if (ndcResponseResult.IsErrorEvent())
            {
                transactionResultBuilder = ErrorEventCheck(ndcResponseResult);
            }

            return transactionResultBuilder.Build();
        }

        private TransactionResultBuilder OutputCompleteEventCheck(NDCResponseResult ndcResponseResult) {


            TransactionResultBuilder builder = ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult);

            // check here
            if (ndcResponseResult.IsPropGetError || ndcResponseResult.IsSeqNumberDiff())
            {
                // POS受信エラー
                
                return builder.SetIsValidateFinished(true)
                              .SetResult(TransactionResult.PosReceiveError)
                              .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CC99" });
            }
            else
            {
                // 成功
                return builder.SetIsValidateFinished(true)
                             .SetResult(TransactionResult.Success)
                             .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "" });
            }
            
        }
        private TransactionResultBuilder ErrorEventCheck(NDCResponseResult ndcResponseResult)
        {
            TransactionResultBuilder builder = ValidationTransactionResult.Builder()
                                        .SetNDCResponseResult(ndcResponseResult);

            // プロパティ：SequenceNumber の取得に失敗した
            // プロパティ：SequenceNumber > 0 且つ、入力時と異なる
            if (ndcResponseResult.IsPropGetError
                || (ndcResponseResult.IsSeqNumberDiff() && ndcResponseResult.IsSeqNumberZero() == false))
            {
                // POS受信エラー
                return builder.SetIsValidateFinished(true)
                              .SetResult(TransactionResult.PosReceiveError)
                              .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = "CC99" });

            }
            
            //プロパティ：SequenceNumber が入力時と一致する
            //プロパティ：SequenceNumber = 0
            //※ResultCode 参照
            // Next check
            return builder.SetIsValidateFinished(false);

        }
        

        

    }
}
