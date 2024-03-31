using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Models
{
    public class BaseASIPrintData
    {
        public string TerminalID { get; set; }
        public string TransactionType { get; set; }
        public string ErrorCode { get; set; }
        public string PhoneNo { get; set; }
        public string POSsequenceNo { get; set; }
        public string TotalAmount { get; set; }
        public string Result { get; set; }
        public string StoreName { get; set; }
        public string TransactionDate { get; set; }
        public string SlipNo { get; set; }
    }

}
