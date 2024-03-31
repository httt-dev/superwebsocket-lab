using ErrorManager.Models;
using ErrorManager.Opos;
using ErrorManager.PrintData;
using ErrorManager.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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


        public bool HasDCC()
        {
            return AdditionalSercurityInfomation.CsvFormatItemCount() == 10;
        }

        public bool IsPaymentTransaction()
        {
            return RequestInfo.PosRequestType == Enums.PosRequestType.EXEC_SALES;
        }

        public string ExtractPosPrintData()
        {
            string printData = string.Empty;

            switch (PaymentMedia)
            {
                case OposCatPayment.Credit:
                case OposCatPayment.NFC:
                    if (HasDCC())
                    {
                        printData = AdditionalSercurityInfomation.GetCsvItemAt(Enums.PrintDataIndex.CreditWithDCC);
                    }
                    else
                    {
                        printData = AdditionalSercurityInfomation.GetCsvItemAt(Enums.PrintDataIndex.CreditWithoutDCC);
                    }
                    break;

                case OposCatPayment.UnionPay:
                    printData = AdditionalSercurityInfomation.GetCsvItemAt(Enums.PrintDataIndex.UnionPay);
                    break;

                case OposCatPayment.Suica:
                    printData = AdditionalSercurityInfomation.GetCsvItemAt(Enums.PrintDataIndex.Suica);
                    break;

            }

            return printData;
        }

        public CreditASIPrintData ConvertPosPrintDataToCreditASIPrintData()
        {
            PaymentProcessor processor = new PaymentProcessor();
            string jsonData = ExtractPosPrintData();
            // Chuyển đổi thành CreditPrintData cho thanh toán Credit
            CreditASIPrintData creditData = processor.ProcessPaymentJson<CreditASIPrintData>(OposCatPayment.Credit, jsonData);
            return creditData;
        }

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
