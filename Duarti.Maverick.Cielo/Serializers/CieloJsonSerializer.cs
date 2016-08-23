using Cielo.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Serializers
{
    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    public class CieloJsonSerializer : ISerializer
    {
        private Newtonsoft.Json.JsonSerializer Serializer { get; set; }

        /// <summary>
        /// Default serializer
        /// </summary>
        public CieloJsonSerializer()
        {
            ContentType = "application/json";

            Serializer = Newtonsoft.Json.JsonSerializer.Create();

            Serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            Serializer.NullValueHandling = NullValueHandling.Include;
            Serializer.DefaultValueHandling = DefaultValueHandling.Include;

            Serializer.Converters.Add(new StringEnumConverter(camelCaseText: true));
            Serializer.Converters.Add(new CreditCardExpirationDateConverter());
        }

        /// <summary>
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        public CieloJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            Serializer = serializer;
        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonTextWriter = new JsonTextWriter(stringWriter))
            {
#if DEBUG
                jsonTextWriter.Formatting = Formatting.Indented;
#endif

                Serializer.Serialize(jsonTextWriter, obj);

                return stringWriter.ToString();
            }
        }
    }
}
