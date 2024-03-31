using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Enums
{
    public enum PosRequestType
    {
        /// <summary>
        /// 決済端末に接続確認を行う
        /// </summary>
        INIT,

        QUIT,
        EXEC_SALES,
        EXEC_VOID,
        TOTAL_DURING,
        TOTAL_FIN,
        RESUME,
        MAINTENANCE,
        PRINT_STORE,

    }

    public enum ResponseType
    {
        DirectResonse,
        CallBackResponse
    }

    public enum PrintDataIndex
    {
        CreditWithDCC = 10,
        CreditWithoutDCC = 21,
        UnionPay = 10,
        Suica = 13,
    }
}
