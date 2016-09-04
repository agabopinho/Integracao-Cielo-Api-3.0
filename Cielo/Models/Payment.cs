using Cielo.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cielo
{
    public class Payment : ReturnStatus
    {
        private static readonly Regex softDescriptorMatch = new Regex("^[a-zA-Z0-9]?", RegexOptions.Compiled);

        private string softDescriptor;

        public Payment()
        {
        }

        public Payment(decimal amount, Currency currency, int installments, bool capture, string softDescriptor, CreditCard creditCard, string country = Cielo.Country.BRA)
        {
            this.Type = PaymentType.CreditCard;
            this.Amount = amount;
            this.Currency = currency;
            this.Installments = installments;
            this.Capture = capture;
            this.SoftDescriptor = softDescriptor;
            this.CreditCard = creditCard;
            this.Country = country;
        }

        public Payment(decimal amount, Currency currency, int installments, string softDescriptor, CreditCard creditCard, RecurrentPayment recurrentPayment, string country = Cielo.Country.BRA)
        {
            this.Type = PaymentType.CreditCard;
            this.Amount = amount;
            this.Currency = currency;
            this.Installments = installments;
            this.SoftDescriptor = softDescriptor;
            this.CreditCard = creditCard;
            this.RecurrentPayment = recurrentPayment;
            this.Country = country;
        }

        [JsonConverter(typeof(CieloDecimalToIntegerConverter))]
        public decimal? ServiceTaxAmount { get; set; }
        public int? Installments { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Interest? Interest { get; set; }
        public bool? Capture { get; set; }
        public bool? Authenticate { get; set; }
        public bool? Recurrent { get; set; }
        public RecurrentPayment RecurrentPayment { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Tid { get; set; }
        public string ProofOfSale { get; set; }
        public string AuthorizationCode { get; set; }
        public string SoftDescriptor
        {
            get
            {
                return softDescriptor;
            }
            set
            {
                if (value != null && (
                    value.Length > 13 ||
                    !softDescriptorMatch.IsMatch(value)))
                {
                    throw new ArgumentException("SoftDescriptor: it has a limit of 13 characters (not special) and no spaces.");
                }

                softDescriptor = value;
            }
        }
        public string ReturnUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Provider? Provider { get; set; }
        public Guid? PaymentId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType? Type { get; set; }
        [JsonConverter(typeof(CieloDecimalToIntegerConverter))]
        public decimal? Amount { get; set; }
        public DateTime? ReceivedDate { get; set; }
        [JsonConverter(typeof(CieloDecimalToIntegerConverter))]
        public decimal? CapturedAmount { get; set; }
        public DateTime? CapturedDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency? Currency { get; set; }
        public string Country { get; set; }
        public List<object> ExtraDataCollection { get; set; }
        public string ExpirationDate { get; set; }
        public string Url { get; set; }
        public string Number { get; set; }
        public string BarCodeNumber { get; set; }
        public string DigitableLine { get; set; }
        public string Address { get; set; }
    }
}
