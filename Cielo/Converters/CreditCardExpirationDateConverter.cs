using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Converters
{
    public class CreditCardExpirationDateConverter : IsoDateTimeConverter
    {
        public CreditCardExpirationDateConverter()
        {
            base.DateTimeFormat = "MM/yyyy";
        }
    }
}
