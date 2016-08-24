using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Enums
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
