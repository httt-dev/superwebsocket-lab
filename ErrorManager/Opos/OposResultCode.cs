using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Opos
{
    public class OposResultCode
    {
        public const string OPOS_SUCCESS = "0";
        public const string OPOS_E_CLOSED = "101";
        public const string OPOS_E_NOTCLAIMED = "103";
        public const string OPOS_E_NOSERVICE = "104";
        public const string OPOS_E_DISABLED = "105";
        public const string OPOS_E_ILLEGAL = "106";
        public const string OPOS_E_NOHARDWARE = "107";
        public const string OPOS_E_NOEXIST = "109";
        public const string OPOS_E_FAILURE = "111";
        public const string OPOS_E_TIMEOUT = "112";
        public const string OPOS_E_BUSY = "113";
        public const string OPOS_E_EXTENDED = "114";
        public const string Undefined = "未定義"; // Chuỗi không xác định

        // Phương thức này có thể được thêm để kiểm tra xem một chuỗi có phải là một mã lỗi hợp lệ không
        public static bool IsValidErrorCode(string errorCode)
        {
            return errorCode == OPOS_SUCCESS ||
                   errorCode == OPOS_E_CLOSED ||
                   errorCode == OPOS_E_NOTCLAIMED ||
                   errorCode == OPOS_E_NOSERVICE ||
                   errorCode == OPOS_E_DISABLED ||
                   errorCode == OPOS_E_ILLEGAL ||
                   errorCode == OPOS_E_NOHARDWARE ||
                   errorCode == OPOS_E_NOEXIST ||
                   errorCode == OPOS_E_FAILURE ||
                   errorCode == OPOS_E_TIMEOUT ||
                   errorCode == OPOS_E_BUSY ||
                   errorCode == OPOS_E_EXTENDED ||
                   errorCode == Undefined;
        }

        public static 
    }

    public class OposResultCodeExtended
    {
        public const string Code_20 = "20";
        public const string Code_21 = "21";
        public const string Code_91 = "91";

        public const string Code_1010 = "1010";
        public const string Code_1020 = "1020";
        public const string Code_1030 = "1030";
        public const string Code_1040 = "1040";
        public const string Code_1050 = "1050";
        public const string Code_1060 = "1060";
        public const string Undefined = "未定義"; // Chuỗi không xác định

        // Phương thức này có thể được thêm để kiểm tra xem một chuỗi có phải là một mã lỗi hợp lệ không
        public static bool IsValidErrorCode(string errorCode)
        {
            return
                    errorCode == Code_20 ||
                    errorCode == Code_21 ||
                    errorCode == Code_91 ||
                    errorCode == Code_1010 ||
                    errorCode == Code_1020 ||
                    errorCode == Code_1030 ||
                    errorCode == Code_1040 ||
                    errorCode == Code_1050 ||
                    errorCode == Code_1060 ||
                    errorCode == Undefined;
        }
    }


}
