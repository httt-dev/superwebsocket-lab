using ErrorManager.Models;
using ErrorManager.Opos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.PrintData
{
    public class PaymentConverterFactory
    {
        public static IPaymentDataConverter<T> GetConverter<T>(string paymentType)
        {
            switch (paymentType)
            {
                case OposCatPayment.Credit:
                    return new CreditPaymentConverter() as IPaymentDataConverter<T>;
                case OposCatPayment.UnionPay:
                    return new CreditUnionASIPrintData() as IPaymentDataConverter<T>;

                default:
                    throw new ArgumentException("Unsupported payment type");
            }
        }
    }
}
