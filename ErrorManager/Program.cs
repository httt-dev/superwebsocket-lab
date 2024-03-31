using ErrorManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static void GetCreditASISample()
        {
            // Chuỗi JSON
            string json = @"{
                                'TerminalID': 'TERMINAL_ID_VALUE',
                                'TransactionType': 'TRANSACTION_TYPE_VALUE',
                                'ErrorCode': 'ERROR_CODE_VALUE',
                                'PhoneNo': 'PHONE_NUMBER_VALUE',
                                'POSsequenceNo': 'POS_SEQUENCE_NUMBER_VALUE',
                                'TotalAmount': 'TOTAL_AMOUNT_VALUE',
                                'Result': 'RESULT_VALUE',
                                'StoreName': 'STORE_NAME_VALUE',
                                'TransactionDate': 'TRANSACTION_DATE_VALUE',
                                'SlipNo': 'SLIP_NUMBER_VALUE',
                                'AccountNo': 'ACCOUNT_NUMBER_VALUE',
                                'CardType': 'CARD_TYPE_VALUE',
                                'TransactionNo': 'TRANSACTION_NUMBER_VALUE',
                                'CardCompany': 'CARD_COMPANY_VALUE',
                                'ApprovalNo': 'APPROVAL_NUMBER_VALUE',
                                'PaymentCode': 'PAYMENT_CODE_VALUE',
                                'ItemCode': 'ITEM_CODE_VALUE',
                                'TaxOther': 'TAX_OTHER_VALUE',
                                'CardholderName': 'CARDHOLDER_NAME_VALUE',
                                'Signature': 'SIGNATURE_VALUE',
                                'ARC': 'ARC_VALUE',
                                'ATC': 'ATC_VALUE',
                                'Brand': 'BRAND_VALUE',
                                'PANSeqNo': 'PAN_SEQ_NUMBER_VALUE',
                                'AID': 'AID_VALUE',
                                'AppLabel': 'APP_LABEL_VALUE',
                                'Message': 'MESSAGE_VALUE',
                                'ExchangeRate': 'EXCHANGE_RATE_VALUE',
                                'MarginRatePercentage': 'MARGIN_RATE_PERCENTAGE_VALUE',
                                'DCCAmount': 'DCC_AMOUNT_VALUE',
                                'DCCMessage': 'DCC_MESSAGE_VALUE',
                                'ConfirmationColumn': 'CONFIRMATION_COLUMN_VALUE',
                                'ConfirmationMessage': 'CONFIRMATION_MESSAGE_VALUE',
                                'NumberofInstallments': 'NUMBER_OF_INSTALLMENTS_VALUE',
                                'PaymentStartMonth': 'PAYMENT_START_MONTH_VALUE',
                                'NumberofBonuspay': 'NUMBER_OF_BONUS_PAY_VALUE',
                                'PaymentType': 'PAYMENT_TYPE_VALUE'
                            }";

            // Chuyển đổi JSON thành đối tượng CreditASI
            CreditASIPrintData creditASI = JsonConvert.DeserializeObject<CreditASIPrintData>(json);
        }
    }
}
