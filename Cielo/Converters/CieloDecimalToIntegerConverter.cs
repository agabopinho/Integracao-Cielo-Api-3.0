using Cielo.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cielo.Converters
{
    public class CieloDecimalToIntegerConverter : JsonConverter
    {
        public override bool CanRead { get; } = true;

        public override bool CanWrite { get; } = true;

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return NumberHelper.IntegerToDecimal(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                var newValue = NumberHelper.DecimalToInteger(value);

                JToken.FromObject(newValue).WriteTo(writer);
            }
        }
    }
}
