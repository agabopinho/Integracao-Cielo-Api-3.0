using Cielo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo
{
    public class CieloException : Exception
    {
        public CieloException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CieloException(IRestResponse response)
            : base(response.ErrorMessage, response.ErrorException)
        {
            this.Response = response;
        }

        public Error[] CieloErrors
        {
            get
            {
                if (Response == null || Response.Content == null || !new[] { "text/json", "application/json" }.Contains(Response.ContentType))
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<Error[]>(Response.Content);
            }
        }

        public IRestResponse Response { get; protected set; }
    }
}
