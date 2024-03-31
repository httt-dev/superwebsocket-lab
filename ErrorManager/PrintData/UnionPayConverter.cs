using ErrorManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.PrintData
{
    public class UnionPayConverter : IPaymentDataConverter<CreditUnionASIPrintData>
    {
        public CreditUnionASIPrintData ConvertFromJson(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}
