using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Models
{
    public class CreditASIPrintData : BaseASIPrintData
    {
        public string AccountNo { get; set; }
        public string CardType { get; set; }
        public string TransactionNo { get; set; }
        public string CardCompany { get; set; }
        public string ApprovalNo { get; set; }
        public string PaymentCode { get; set; }
        public string ItemCode { get; set; }
        public string TaxOther { get; set; }
        public string CardholderName { get; set; }
        public string Signature { get; set; }
        public string ARC { get; set; }
        public string ATC { get; set; }
        public string Brand { get; set; }
        public string PANSeqNo { get; set; }
        public string AID { get; set; }
        public string AppLabel { get; set; }
        public string Message { get; set; }
        public string ExchangeRate { get; set; }
        public string MarginRatePercentage { get; set; }
        public string DCCAmount { get; set; }
        public string DCCMessage { get; set; }
        public string ConfirmationColumn { get; set; }
        public string ConfirmationMessage { get; set; }
        public string NumberofInstallments { get; set; }
        public string PaymentStartMonth { get; set; }
        public string NumberofBonuspay { get; set; }
        public string PaymentType { get; set; }
    }

}
