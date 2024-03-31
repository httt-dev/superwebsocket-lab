using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Models
{
    public class CreditASIWithoutDCC : BaseCreditASI
    {
        // DCCデータ部 取引金額（外貨）
        public string TransactionAmountForeignCurrency { get; set; }

        // DCCデータ部 反転為替レート
        public string InvertedExchangeRate { get; set; }

        // DCCデータ部 取引金額（ベース）
        public string TransactionAmountBase { get; set; }

        // DCCデータ部 マークアップ小数点位置
        public string MarkupDecimalPosition { get; set; }

        // DCCデータ部 通貨コード（外貨）
        public string CurrencyCodeForeignCurrency { get; set; }

        // DCCデータ部 外貨（アルファベット）
        public string ForeignCurrency { get; set; }

        // DCCデータ部 反転レート表示位置
        public string InvertedRateDisplayPosition { get; set; }

        // DCCデータ部 マークアップ値
        public string MarkupValue { get; set; }

        // DCCデータ部 小数点位置（外貨）
        public string DecimalPositionForeignCurrency { get; set; }

        // DCCデータ部 反転レート小数点位置
        public string InvertedRateDecimalPosition { get; set; }

        // DCCデータ部 ＤＣＣフラグ
        public string DCCFlag { get; set; }
    }

}
