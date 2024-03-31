using ErrorManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    public class RequestInfo
    {
        public string SequenceNumber { get; set; }
        public string RequestId { get; set; }
        public PosRequestType PosRequestType { get; set; }
    }
}
