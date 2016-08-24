using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Models
{
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
}
