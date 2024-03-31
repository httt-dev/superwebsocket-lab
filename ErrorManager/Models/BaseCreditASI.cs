using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Models
{
    public class BaseCreditASI
    {

        /// <summary>
        /// 有効期限
        /// </summary>
        public string ExpirationDate { get; set; }

        /// <summary>
        /// 端末識別番号
        /// </summary>
        public string TerminalIdentificationNumber { get; set; }

        /// <summary>
        /// 商品コード
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 税・その他
        /// </summary>
        public string TaxAndOther { get; set; }

        /// <summary>
        /// 取消・返品伝票番号
        /// </summary>
        public string CancellationReturnSlipNumber { get; set; }

        /// <summary>
        /// カウンタ情報
        /// </summary>
        public string CounterInformation { get; set; }

        /// <summary>
        /// 銀聯送信日時(GW 送信日時)
        /// </summary>
        public string UnionPayTransmissionDateTime { get; set; }

        /// <summary>
        /// 取消返品区分
        /// </summary>
        public string CancellationReturnClassification { get; set; }

        /// <summary>
        /// 印字データ部 印字データ
        /// </summary>
        public string PrintDataPartContent { get; set; }

        /// <summary>
        /// 印字データ部 レングス
        /// </summary>
        public string PrintDataPartLength { get; set; }
    }


}
