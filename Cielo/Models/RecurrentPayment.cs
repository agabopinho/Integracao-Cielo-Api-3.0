using Cielo.Converters;
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
        public RecurrentPayment()
        {
        }

        public RecurrentPayment(Enums.Interval interval, DateTime endDate)
        {
            this.Interval = interval;
            this.EndDate = endDate;
            this.AuthorizeNow = true;
        }

        public RecurrentPayment(Enums.Interval interval, DateTime startDate, DateTime endDate)
        {
            this.Interval = interval;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AuthorizeNow = false;
        }

        public Guid? RecurrentPaymentId { get; set; }
        public bool? AuthorizeNow { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime? StartDate { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime? EndDate { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime? NextRecurrency { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Interval Interval { get; set; }
        public Link Link { get; set; }
    }
}
