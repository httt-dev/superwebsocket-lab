using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Models
{
    public class CreditUnionASIPrintData : BaseASIPrintData
    {
        public string Signature { get; set; }
        public string AppLabel { get; set; }
        public string ATC { get; set; }
        public string ARC { get; set; }
        public string ReqestDateTime { get; set; }
        public string Message { get; set; }
        public string ApprovalNo { get; set; }
        public string TransactionNo { get; set; }
        public string BankName { get; set; }
        public string CenterErrorCode { get; set; }
        public string Brand { get; set; }
        public string UnionpayNo { get; set; }
        public string TC { get; set; }
        public string AccountNo { get; set; }
        public string PaymentType { get; set; }
        public string PANSeqNo { get; set; }
        public string CardType { get; set; }
        public string AID { get; set; }
    }

}
