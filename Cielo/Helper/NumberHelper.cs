using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Helper
{
    public static class NumberHelper
    {
        public static decimal IntegerToDecimal(object value)
        {
            return Convert.ToDecimal(value) / 100;
        }

        public static object DecimalToInteger(object value)
        {
            return Convert.ToInt32(Convert.ToDecimal(value) * 100);
        }
    }
}
