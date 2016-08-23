using log4net;
using log4net.Config;
using RestSharp;
using System;
using System.Net;
using System.Linq;
using Cielo.Serializers;
using Cielo.Exceptions;
using Cielo.Configurations;

namespace Cielo
{
    public abstract class CieloBaseApi
    {
        internal static readonly HttpStatusCode[] ValidStatusCodes = new[]
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted
        };

        protected RestClient CreateClient(string baseUrl, IMerchant merchant)
        {
            var client = new RestClient(baseUrl);

            client.Proxy = WebRequest.DefaultWebProxy;

            client.AddDefaultHeader("MerchantId", merchant.Id.ToString());
            client.AddDefaultHeader("MerchantKey", merchant.Key);

            return client;
        }

        protected IRestRequest CreateRequest(Guid requestId, string resource, Method method)
        {
            var request = new RestRequest(resource, method)
            {
                JsonSerializer = new CieloJsonSerializer()
            };

            request.AddHeader("RequestId", requestId.ToString());

            return request;
        }

        protected void VerifyResponse(IRestResponse response)
        {
            if (!ValidStatusCodes.Contains(response.StatusCode) ||
                response.ResponseStatus != ResponseStatus.Completed)
            {
                var exception = new CieloException(response);

                // TODO: log errors

                throw exception;
            }
        }
    }
}
