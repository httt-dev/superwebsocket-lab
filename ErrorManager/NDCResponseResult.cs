using ErrorManager.Opos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{

    public enum EventType
    {
        None,
        OutputCompleteEvent,
        ErrorEvent
    }
    public class CallBackResponse
    {
        public EventType EventType {  get; set; }
        public string ResultCode { get; set; }
        public string ResultCodeExtended { get; set; }

    }
    public class NDCResponseResult
    {
        public RequestInfo RequestInfo { get; set; }
        public CallBackResponse CallBackResponse { get; set; }
        /// <summary>
        /// 必要なプロパティの取得に失敗した | POS受信エラー | CC99 | CC99
        /// </summary>
        public bool IsPropGetError {  get; set; }
        public bool IsCallBackResponseTimeout { get; set; }

        public string SequenceNumber { get; set; }
        public string AdditionalSercurityInfomation { get; set; }
        public string AccountNumber { get; set; }
        public string ApprovalCode { get; set; }
        public string Balance { get; set; }
        public string CardCompanyID { get; set; }
        public string CenterResultCode { get; set; }
        public string PaymentCondition { get; set; }
        public string PaymentDetail { get; set; }
        public string SettledAmount { get; set; }
        public string SlipNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string TransactionType { get; set; }
        public string PaymentMedia { get; set; }


        public bool IsNoneEvent()
        {
            return this.CallBackResponse.EventType == EventType.None;
        }
        public bool IsOutputCompleteEvent()
        {
            return this.CallBackResponse.EventType == EventType.OutputCompleteEvent;
        }

        public bool IsErrorEvent()
        {
            return this.CallBackResponse.EventType == EventType.ErrorEvent;
        }

        public bool IsSeqNumberDiff()
        {
            return this.SequenceNumber != this.RequestInfo.SequenceNumber;
        }
        public bool IsSeqNumberZero()
        {
            return this.SequenceNumber =="0";
        }

        public bool HasResultCodeIsExtended()
        {
            return this.CallBackResponse.ResultCode == OposResultCode.OPOS_E_EXTENDED;
        }
    }

}
