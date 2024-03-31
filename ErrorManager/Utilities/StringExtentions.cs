using ErrorManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorManager.Utilities
{
    public static class StringExtentions
    {
        public static int CsvFormatItemCount(this string str , char split = ',')
        {
            return str.Split(split).Count();
        }
        public static string GetCsvItemAt(this string str , PrintDataIndex index)
        {
            var values = str.Split(',');

            if ((int)index > values.Length)
            {
                return string.Empty;
            }
            return values[(int)index];
        }
    }
}
