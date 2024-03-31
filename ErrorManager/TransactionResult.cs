using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    public sealed class TransactionResult
    {
        private readonly string _name;

        private TransactionResult(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
        /// <summary>
        /// Unset value
        /// </summary>
        public static readonly TransactionResult UnSet = new TransactionResult("Init");
        /// <summary>
        /// 成功
        /// </summary>
        public static readonly TransactionResult Success = new TransactionResult("成功");
        /// <summary>
        /// ユーザエラー(不成立)
        /// </summary>
        public static readonly TransactionResult UserError = new TransactionResult("ユーザエラー(不成立)");
        /// <summary>
        /// その他(不成立)
        /// </summary>
        public static readonly TransactionResult OtherError = new TransactionResult("その他(不成立)");
        /// <summary>
        /// 成否不明
        /// </summary>
        public static readonly TransactionResult UnknownError = new TransactionResult("成否不明");

        /// <summary>
        /// POS受信エラー
        /// </summary>
        public static readonly TransactionResult PosReceiveError = new TransactionResult("POS受信エラー");
        /// <summary>
        /// 決済中断
        /// </summary>
        public static readonly TransactionResult PaymentInterruptError = new TransactionResult("決済中断");
        /// <summary>
        /// 直前取引なし(不成立)
        /// </summary>
        public static readonly TransactionResult LastTransactionNotFoundError = new TransactionResult("直前取引なし(不成立)");
    }

}
