using Duarti.Maverick.Cielo.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Duarti.Maverick.Cielo.Enums
{
    public enum CardBrand
    {
        [EnumMember(Value = "Visa")]
        Visa,
        [EnumMember(Value = "Master")]
        Master,
        [EnumMember(Value = "Amex")]
        Amex,
        [EnumMember(Value = "Elo")]
        Elo,
        [EnumMember(Value = "Aura")]
        Aura,
        [EnumMember(Value = "JCB")]
        JCB,
        [EnumMember(Value = "Diners")]
        Diners,
        [EnumMember(Value = "Discover")]
        Discover
    }

    public enum PaymentType
    {
        [EnumMember(Value = "CreditCard")]
        CreditCard,
        [EnumMember(Value = "DebitCard")]
        DebitCard,
        [EnumMember(Value = "EletronicTransfer")]
        EletronicTransfer,
        [EnumMember(Value = "Boleto")]
        Boleto
    }

    public enum Currency
    {
        [EnumMember(Value = "BRL")]
        BRL,
        [EnumMember(Value = "USD")]
        USD,
        [EnumMember(Value = "MXN")]
        MXN,
        [EnumMember(Value = "COP")]
        COP,
        [EnumMember(Value = "CLP")]
        CLP,
        [EnumMember(Value = "ARS")]
        ARS,
        [EnumMember(Value = "PEN")]
        PEN,
        [EnumMember(Value = "EUR")]
        EUR,
        [EnumMember(Value = "PYN")]
        PYN,
        [EnumMember(Value = "UYU")]
        UYU,
        [EnumMember(Value = "VEB")]
        VEB,
        [EnumMember(Value = "VEF")]
        VEF,
        [EnumMember(Value = "GBP")]
        GBP
    }

    public enum Status
    {
        NotFinished = 0,
        Authorized = 1,
        PaymentConfirmed = 2,
        Denied = 3,
        Voided = 10,
        Refunded = 11,
        Pending = 12,
        Aborted = 13,
        Scheduled = 20,
    }

    public enum Provider
    {
        [EnumMember(Value = "Bradesco")]
        Bradesco,
        [EnumMember(Value = "BancoDoBrasil")]
        BancoDoBrasil,
        [EnumMember(Value = "Simulado")]
        Simulado
    }

    public enum IdentityType
    {
        [EnumMember(Value = "CPF")]
        CPF
    }

    public enum Interest
    {
        [EnumMember(Value = "ByMerchant")]
        ByMerchant
    }

    public enum RecurrentPaymentInterval
    {
        [EnumMember(Value = "Monthly")]
        Monthly,
        [EnumMember(Value = "Bimonthly")]
        Bimonthly,
        [EnumMember(Value = "Quarterly")]
        Quarterly,
        [EnumMember(Value = "SemiAnnual")]
        SemiAnnual,
        [EnumMember(Value = "Annual")]
        Annual
    }
}

namespace Duarti.Maverick.Cielo.Model
{
    public class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }

    public class Link
    {
        public string Method { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public string Identity { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.IdentityType? IdentityType { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public Address Address { get; set; }
        public Address DeliveryAddress { get; set; }
    }

    public class CreditCard
    {
        public CreditCard()
        {
        }

        public CreditCard(Guid cardToken, string securityCode, Enums.CardBrand brand)
        {
            this.CardToken = cardToken;
            this.SecurityCode = securityCode;
            this.Brand = brand;
        }

        public CreditCard(string cardNumber, string holder, DateTime expirationDate, string securityCode, Enums.CardBrand brand, bool saveCard = false)
        {
            this.CardNumber = cardNumber;
            this.Holder = holder;
            this.ExpirationDate = expirationDate;
            this.SecurityCode = securityCode;
            this.Brand = brand;
            this.SaveCard = saveCard;
        }

        public string CardNumber { get; set; }
        public Guid? CardToken { get; set; }
        public string Holder { get; set; }
        [JsonConverter(typeof(CreditCardExpirationDateConverter))]
        public DateTime? ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public bool? SaveCard { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.CardBrand? Brand { get; set; }
    }

    public class Payment
    {
        public Payment()
        {
        }

        public Payment(int amount, Enums.Currency currency, int installments, bool capture, string softDescriptor, CreditCard creditCard, string country = "BRA", bool authenticate = false)
        {
            this.Type = Enums.PaymentType.CreditCard;
            this.Amount = amount;
            this.Currency = currency;
            this.Installments = installments;
            this.Capture = capture;
            this.SoftDescriptor = softDescriptor;
            this.CreditCard = creditCard;
            this.Country = country;
            this.Authenticate = authenticate;
        }

        public int? ServiceTaxAmount { get; set; }
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
        public int? Amount { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int? CapturedAmount { get; set; }
        public DateTime? CapturedDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Currency? Currency { get; set; }
        public string Country { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public Enums.Status? Status { get; set; }
        public List<Link> Links { get; set; }
        public List<object> ExtraDataCollection { get; set; }
        public string ExpirationDate { get; set; }
        public string Url { get; set; }
        public string Number { get; set; }
        public string BarCodeNumber { get; set; }
        public string DigitableLine { get; set; }
        public string Address { get; set; }
    }

    public class RecurrentPayment
    {
        public bool? AuthorizeNow { get; set; }
        public string EndDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.RecurrentPaymentInterval Interval { get; set; }
    }

    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(string merchantOrderId, Customer customer, Payment payment)
        {
            this.MerchantOrderId = merchantOrderId;
            this.Customer = customer;
            this.Payment = payment;
        }

        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
