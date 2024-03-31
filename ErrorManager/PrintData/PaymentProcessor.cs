using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.PrintData
{
    public class PaymentProcessor
    {
        /**
 
        string jsonData = "{ \"ErrorCode\": \"100\", \"Result\": \"Success\", ... }";
        string paymentType = "Credit"; // Hoặc "UnionPay" hoặc "Suica"

        // Sử dụng PaymentProcessor để chuyển đổi dữ liệu JSON thành đối tượng tương ứng
        PaymentProcessor processor = new PaymentProcessor();
        
        // Chuyển đổi thành CreditPrintData cho thanh toán Credit
        CreditASIPrintData creditData = processor.ProcessPaymentJson<CreditASIPrintData>(paymentType, jsonData);

        */

        public T ProcessPaymentJson<T>(string paymentType , string jsonData)
        {
            var converter = PaymentConverterFactory.GetConverter<T>(paymentType);
            return converter.ConvertFromJson(jsonData);
        }
    }
}
