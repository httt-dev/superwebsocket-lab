using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.PrintData
{
    public interface IPaymentDataConverter<T>
    {
        T ConvertFromJson(string jsonData);
    }
}
