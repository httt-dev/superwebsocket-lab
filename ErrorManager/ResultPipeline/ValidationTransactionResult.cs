using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.ResultPipeline
{
    //public class TransactionResult
    //{
    //    NDCResponseResult NDCResponseResult {  get; set; }
    //    public bool IsValidateFinished { get; set; }
    //    public string Result { get; set; } // su dung ket qua nay de flow thanh toan/cancel ...tiep tuc xu ly 
    //    public ErrorCodeInfo ErrorCodeInfo {  get; set; }

    //    public static TransactionResult CreateSucess(NDCResponseResult responseResult)
    //    {
    //        return new TransactionResult
    //        {
    //            NDCResponseResult = responseResult,
    //            IsValidateFinished = true,
    //            Result = "OK"
    //        };
    //    }

    //    public static TransactionResult CreateError(string messageId)
    //    {
    //        return new TransactionResult
    //        {
    //            IsValidateFinished = false,
    //            Result = "NG"
    //        };
    //    }

    //}

    public class ValidationTransactionResult
    {
        public NDCResponseResult NDCResponseResult { get; }
        public bool IsValidateFinished { get; }
        public TransactionResult Result { get; }
        public ErrorCodeInfo ErrorCodeInfo { get; }

        public ValidationTransactionResult()
        {
            IsValidateFinished = false;
            Result = TransactionResult.UnSet;
        }

        // Private constructor, chỉ sử dụng bởi Builder.
        private ValidationTransactionResult(NDCResponseResult ndcResponseResult, bool isValidateFinished, TransactionResult result, ErrorCodeInfo errorCodeInfo)
        {
            NDCResponseResult = ndcResponseResult;
            IsValidateFinished = isValidateFinished;
            Result = result;
            ErrorCodeInfo = errorCodeInfo;
        }


        // Builder class cho TransactionResult
        public class TransactionResultBuilder
        {
            private NDCResponseResult _ndcResponseResult;
            private bool _isValidateFinished;
            private TransactionResult _result;
            private ErrorCodeInfo _errorCodeInfo;

            public TransactionResultBuilder() { }

            // Thiết lập NDCResponseResult
            public TransactionResultBuilder SetNDCResponseResult(NDCResponseResult ndcResponseResult)
            {
                _ndcResponseResult = ndcResponseResult;
                return this;
            }

            // Thiết lập IsValidateFinished
            public TransactionResultBuilder SetIsValidateFinished(bool isValidateFinished)
            {
                _isValidateFinished = isValidateFinished;
                return this;
            }

            // Thiết lập Result
            public TransactionResultBuilder SetResult(TransactionResult result)
            {
                _result = result;
                return this;
            }

            // Thiết lập ErrorCodeInfo
            public TransactionResultBuilder SetErrorCodeInfo(ErrorCodeInfo errorCodeInfo)
            {
                _errorCodeInfo = errorCodeInfo;
                return this;
            }

            // Phương thức build để tạo TransactionResult từ Builder
            public ValidationTransactionResult Build()
            {
                return new ValidationTransactionResult(_ndcResponseResult, _isValidateFinished, _result, _errorCodeInfo);
            }
        }

        // Phương thức tạo mới để trả về một đối tượng của Builder
        public static TransactionResultBuilder Builder()
        {
            return new TransactionResultBuilder();
        }

        public static ValidationTransactionResult CreateSucess(NDCResponseResult ndcResponseResult , string messageId)
        {
            var transactionResult = ValidationTransactionResult.Builder()
                                    .SetNDCResponseResult(ndcResponseResult)
                                    .SetIsValidateFinished(true)
                                    .SetResult(TransactionResult.Success)
                                    .SetErrorCodeInfo(new ErrorCodeInfo { MessageID = messageId })
                                    .Build();
            return transactionResult;
        }

        public static ValidationTransactionResult CreateError(NDCResponseResult ndcResponseResult, TransactionResult  result , string messageId)
        {
            var transactionResult = ValidationTransactionResult.Builder()
                                     .SetNDCResponseResult(ndcResponseResult)
                                     .SetIsValidateFinished(true)
                                     .SetResult(result)
                                     .SetErrorCodeInfo(new ErrorCodeInfo { MessageID =messageId})
                                     .Build();

            return transactionResult;
        }

    }

}
