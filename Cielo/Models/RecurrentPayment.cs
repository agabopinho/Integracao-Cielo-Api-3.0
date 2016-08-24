using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Models
{
    public class RecurrentPayment
    {
        public bool? AuthorizeNow { get; set; }
        public string EndDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.RecurrentPaymentInterval Interval { get; set; }
    }
}
