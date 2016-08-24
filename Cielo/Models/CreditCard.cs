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
}
