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
    public class Payment : ReturnStatus
    {
        public Payment()
        {
        }

        public Payment(decimal amount, Enums.Currency currency, int installments, bool capture, string softDescriptor, CreditCard creditCard, string country = Enums.Country.BRA)
        {
            this.Type = Enums.PaymentType.CreditCard;
            this.Amount = amount;
            this.Currency = currency;
            this.Installments = installments;
            this.Capture = capture;
            this.SoftDescriptor = softDescriptor;
            this.CreditCard = creditCard;
            this.Country = country;
        }

        public Payment(decimal amount, Enums.Currency currency, int installments, string softDescriptor, CreditCard creditCard, RecurrentPayment recurrentPayment, string country = Enums.Country.BRA)
        {
            this.Type = Enums.PaymentType.CreditCard;
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
        public Enums.Interest? Interest { get; set; }
        public bool? Capture { get; set; }
        public bool? Authenticate { get; set; }
        public bool? Recurrent { get; set; }
        public RecurrentPayment RecurrentPayment { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Tid { get; set; }
        public string ProofOfSale { get; set; }
        public string AuthorizationCode { get; set; }
        public string SoftDescriptor { get; set; }
        public string ReturnUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Provider? Provider { get; set; }
        public Guid? PaymentId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PaymentType? Type { get; set; }
        [JsonConverter(typeof(CieloDecimalToIntegerConverter))]
        public decimal? Amount { get; set; }
        public DateTime? ReceivedDate { get; set; }
        [JsonConverter(typeof(CieloDecimalToIntegerConverter))]
        public decimal? CapturedAmount { get; set; }
        public DateTime? CapturedDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Currency? Currency { get; set; }
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
