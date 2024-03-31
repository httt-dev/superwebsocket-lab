using ErrorManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    
    
    // EventType 

    public class ExecuteResult
    {
        public PosRequestType PosRequestType { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public string ErrorTypeId { get; set; }
        public string ErrorTypeDesc { get; set; }
        public string SaleMessageId { get; set; }
        public string CancelMessageId { get; set; }
        public string MessageId { get; set; }
    }



    public class ExecuteResultExtended
    {
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public string ErrorTypeId { get; set; }
        public string ErrorTypeDesc { get; set; }
    }

    public class DirectResponse
    {
        public ExecuteResult ExecuteResult { get; set; }
        public ExecuteResultExtended ExecuteResultExtended { get; set; }

    }

    public class ErrorTypeList
    {
        public readonly static string Success = "成功";
        public readonly static string InvalidCard = "カード無効";
        public readonly static string RequestAccepted = "依頼受理";
        public readonly static string ApprovalRequired = "要承認";
        public readonly static string PaymentInterrupted = "決済中断";
        public readonly static string Failure = "失敗";
        public readonly static string InputError = "入力エラー";
        public readonly static string OtherError = "その他エラー";
        public readonly static string Unprocessed = "未処理";
        public readonly static string UnknownSuccess = "成否不明";
        public readonly static string NoPreviousTransactionInfo = "元取引情報なし";
        public readonly static string POSSendError = "POS送信エラー";
        public readonly static string POSReceiveError = "POS受信エラー";
        public readonly static string UserError = "ユーザエラー(不成立)";
        public readonly static string OtherUnfulfilled = "その他(不成立)";
        public readonly static string NoPreviousTransaction = "直前取引なし(不成立)";

        // Mảng này ánh xạ các chuỗi loại lỗi sang mã loại lỗi tương ứng
        public static readonly Dictionary<string, string> ErrorTypeToCodeMap = new Dictionary<string, string>
        {
            {Success, "0"},
            {InvalidCard, "2"},
            {RequestAccepted, "3"},
            {ApprovalRequired, "4"},
            {PaymentInterrupted, "5"},
            {Failure, "E0"},
            {InputError, "E1"},
            {OtherError, "E2"},
            {Unprocessed, "E3"},
            {UnknownSuccess, "E4"},
            {NoPreviousTransactionInfo, "E5"},
            {POSSendError, "E6"},
            {POSReceiveError, "E7"},
            {UserError, "E8"},
            {OtherUnfulfilled, "E9"},
            {NoPreviousTransaction, "E10"}
        };

        // Mảng này ánh xạ các mã loại lỗi sang chuỗi loại lỗi tương ứng
        public static readonly Dictionary<string, string> ErrorCodeToTypeMap = ErrorTypeToCodeMap.ToDictionary(kv => kv.Value, kv => kv.Key);

        // Phương thức này để lấy mã loại lỗi từ chuỗi loại lỗi
        public static string GetErrorCode(string errorType)
        {
            return ErrorTypeToCodeMap.TryGetValue(errorType, out var errorCode) ? errorCode : null;
        }

        // Phương thức này để lấy chuỗi loại lỗi từ mã loại lỗi
        public static string GetErrorType(string errorCode)
        {
            return ErrorCodeToTypeMap.TryGetValue(errorCode, out var errorType) ? errorType : null;
        }

        // Phương thức này để kiểm tra tính hợp lệ của một loại lỗi
        public static bool IsValidErrorType(string errorType)
        {
            return ErrorTypeToCodeMap.ContainsKey(errorType);
        }
    }

}
