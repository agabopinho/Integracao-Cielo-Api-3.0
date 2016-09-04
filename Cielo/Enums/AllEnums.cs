using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cielo
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

    public enum Interval
    {
        [EnumMember(Value = "Monthly")]
        Monthly = 1,
        [EnumMember(Value = "Bimonthly")]
        Bimonthly = 2,
        [EnumMember(Value = "Quarterly")]
        Quarterly = 3,
        [EnumMember(Value = "SemiAnnual")]
        SemiAnnual = 6,
        [EnumMember(Value = "Annual")]
        Annual = 12
    }

    public static class Country
    {
        public const string AFG = "AFG";
        public const string ALB = "ALB";
        public const string DZA = "DZA";
        public const string ASM = "ASM";
        public const string AND = "AND";
        public const string AGO = "AGO";
        public const string AIA = "AIA";
        public const string ATA = "ATA";
        public const string ATG = "ATG";
        public const string ARG = "ARG";
        public const string ARM = "ARM";
        public const string ABW = "ABW";
        public const string AUS = "AUS";
        public const string AUT = "AUT";
        public const string AZE = "AZE";
        public const string BHS = "BHS";
        public const string BHR = "BHR";
        public const string BGD = "BGD";
        public const string BRB = "BRB";
        public const string BLR = "BLR";
        public const string BEL = "BEL";
        public const string BLZ = "BLZ";
        public const string BEN = "BEN";
        public const string BMU = "BMU";
        public const string BTN = "BTN";
        public const string BOL = "BOL";
        public const string BES = "BES";
        public const string BIH = "BIH";
        public const string BWA = "BWA";
        public const string BVT = "BVT";
        public const string BRA = "BRA";
        public const string IOT = "IOT";
        public const string BRN = "BRN";
        public const string BGR = "BGR";
        public const string BFA = "BFA";
        public const string BDI = "BDI";
        public const string KHM = "KHM";
        public const string CMR = "CMR";
        public const string CAN = "CAN";
        public const string CPV = "CPV";
        public const string CYM = "CYM";
        public const string CAF = "CAF";
        public const string TCD = "TCD";
        public const string CHL = "CHL";
        public const string CHN = "CHN";
        public const string CXR = "CXR";
        public const string CCK = "CCK";
        public const string COL = "COL";
        public const string COM = "COM";
        public const string COG = "COG";
        public const string COD = "COD";
        public const string COK = "COK";
        public const string CRI = "CRI";
        public const string HRV = "HRV";
        public const string CUB = "CUB";
        public const string CUW = "CUW";
        public const string CYP = "CYP";
        public const string CZE = "CZE";
        public const string CIV = "CIV";
        public const string DNK = "DNK";
        public const string DJI = "DJI";
        public const string DMA = "DMA";
        public const string DOM = "DOM";
        public const string ECU = "ECU";
        public const string EGY = "EGY";
        public const string SLV = "SLV";
        public const string GNQ = "GNQ";
        public const string ERI = "ERI";
        public const string EST = "EST";
        public const string ETH = "ETH";
        public const string FLK = "FLK";
        public const string FRO = "FRO";
        public const string FJI = "FJI";
        public const string FIN = "FIN";
        public const string FRA = "FRA";
        public const string GUF = "GUF";
        public const string PYF = "PYF";
        public const string ATF = "ATF";
        public const string GAB = "GAB";
        public const string GMB = "GMB";
        public const string GEO = "GEO";
        public const string DEU = "DEU";
        public const string GHA = "GHA";
        public const string GIB = "GIB";
        public const string GRC = "GRC";
        public const string GRL = "GRL";
        public const string GRD = "GRD";
        public const string GLP = "GLP";
        public const string GUM = "GUM";
        public const string GTM = "GTM";
        public const string GGY = "GGY";
        public const string GIN = "GIN";
        public const string GNB = "GNB";
        public const string GUY = "GUY";
        public const string HTI = "HTI";
        public const string HMD = "HMD";
        public const string VAT = "VAT";
        public const string HND = "HND";
        public const string HKG = "HKG";
        public const string HUN = "HUN";
        public const string ISL = "ISL";
        public const string IND = "IND";
        public const string IDN = "IDN";
        public const string IRN = "IRN";
        public const string IRQ = "IRQ";
        public const string IRL = "IRL";
        public const string IMN = "IMN";
        public const string ISR = "ISR";
        public const string ITA = "ITA";
        public const string JAM = "JAM";
        public const string JPN = "JPN";
        public const string JEY = "JEY";
        public const string JOR = "JOR";
        public const string KAZ = "KAZ";
        public const string KEN = "KEN";
        public const string KIR = "KIR";
        public const string PRK = "PRK";
        public const string KOR = "KOR";
        public const string KWT = "KWT";
        public const string KGZ = "KGZ";
        public const string LAO = "LAO";
        public const string LVA = "LVA";
        public const string LBN = "LBN";
        public const string LSO = "LSO";
        public const string LBR = "LBR";
        public const string LBY = "LBY";
        public const string LIE = "LIE";
        public const string LTU = "LTU";
        public const string LUX = "LUX";
        public const string MAC = "MAC";
        public const string MKD = "MKD";
        public const string MDG = "MDG";
        public const string MWI = "MWI";
        public const string MYS = "MYS";
        public const string MDV = "MDV";
        public const string MLI = "MLI";
        public const string MLT = "MLT";
        public const string MHL = "MHL";
        public const string MTQ = "MTQ";
        public const string MRT = "MRT";
        public const string MUS = "MUS";
        public const string MYT = "MYT";
        public const string MEX = "MEX";
        public const string FSM = "FSM";
        public const string MDA = "MDA";
        public const string MCO = "MCO";
        public const string MNG = "MNG";
        public const string MNE = "MNE";
        public const string MSR = "MSR";
        public const string MAR = "MAR";
        public const string MOZ = "MOZ";
        public const string MMR = "MMR";
        public const string NAM = "NAM";
        public const string NRU = "NRU";
        public const string NPL = "NPL";
        public const string NLD = "NLD";
        public const string NCL = "NCL";
        public const string NZL = "NZL";
        public const string NIC = "NIC";
        public const string NER = "NER";
        public const string NGA = "NGA";
        public const string NIU = "NIU";
        public const string NFK = "NFK";
        public const string MNP = "MNP";
        public const string NOR = "NOR";
        public const string OMN = "OMN";
        public const string PAK = "PAK";
        public const string PLW = "PLW";
        public const string PSE = "PSE";
        public const string PAN = "PAN";
        public const string PNG = "PNG";
        public const string PRY = "PRY";
        public const string PER = "PER";
        public const string PHL = "PHL";
        public const string PCN = "PCN";
        public const string POL = "POL";
        public const string PRT = "PRT";
        public const string PRI = "PRI";
        public const string QAT = "QAT";
        public const string ROU = "ROU";
        public const string RUS = "RUS";
        public const string RWA = "RWA";
        public const string REU = "REU";
        public const string BLM = "BLM";
        public const string SHN = "SHN";
        public const string KNA = "KNA";
        public const string LCA = "LCA";
        public const string MAF = "MAF";
        public const string SPM = "SPM";
        public const string VCT = "VCT";
        public const string WSM = "WSM";
        public const string SMR = "SMR";
        public const string STP = "STP";
        public const string SAU = "SAU";
        public const string SEN = "SEN";
        public const string SRB = "SRB";
        public const string SYC = "SYC";
        public const string SLE = "SLE";
        public const string SGP = "SGP";
        public const string SXM = "SXM";
        public const string SVK = "SVK";
        public const string SVN = "SVN";
        public const string SLB = "SLB";
        public const string SOM = "SOM";
        public const string ZAF = "ZAF";
        public const string SGS = "SGS";
        public const string SSD = "SSD";
        public const string ESP = "ESP";
        public const string LKA = "LKA";
        public const string SDN = "SDN";
        public const string SUR = "SUR";
        public const string SJM = "SJM";
        public const string SWZ = "SWZ";
        public const string SWE = "SWE";
        public const string CHE = "CHE";
        public const string SYR = "SYR";
        public const string TWN = "TWN";
        public const string TJK = "TJK";
        public const string TZA = "TZA";
        public const string THA = "THA";
        public const string TLS = "TLS";
        public const string TGO = "TGO";
        public const string TKL = "TKL";
        public const string TON = "TON";
        public const string TTO = "TTO";
        public const string TUN = "TUN";
        public const string TUR = "TUR";
        public const string TKM = "TKM";
        public const string TCA = "TCA";
        public const string TUV = "TUV";
        public const string UGA = "UGA";
        public const string UKR = "UKR";
        public const string ARE = "ARE";
        public const string GBR = "GBR";
        public const string USA = "USA";
        public const string UMI = "UMI";
        public const string URY = "URY";
        public const string UZB = "UZB";
        public const string VUT = "VUT";
        public const string VEN = "VEN";
        public const string VNM = "VNM";
        public const string VGB = "VGB";
        public const string VIR = "VIR";
        public const string WLF = "WLF";
        public const string ESH = "ESH";
        public const string YEM = "YEM";
        public const string ZMB = "ZMB";
        public const string ZWE = "ZWE";
        public const string ALA = "ALA";
    }
}
