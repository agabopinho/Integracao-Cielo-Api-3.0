using Cielo;
using Cielo.Helper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cielo
{
    public class CieloApi : CieloBaseApi, ICieloApi
    {
        public virtual IMerchant Merchant { get; }
        public virtual IEnvironment Environment { get; }

        public CieloApi(IEnvironment environment, IMerchant merchant)
        {
            this.Environment = environment;
            this.Merchant = merchant;

            PreConfigurationTls12();
        }

        /// <summary>
        /// New instance of production environment
        /// </summary>
        /// <param name="merchant">Merchant of production environment</param>
        public CieloApi(IMerchant merchant)
            : this(CieloEnvironment.Production, merchant)
        {
        }

        public virtual Transaction CreateTransaction(Guid requestId, Transaction transaction)
        {
            var client = CreateClient(Environment.TransactionUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/", Method.POST);

            request.AddJsonBody(transaction);

            var response = client.Execute(request);

            VerifyResponse(response);

            return JsonConvert.DeserializeObject<Transaction>(response.Content);
        }

        public virtual Transaction GetTransaction(Guid requestId, Guid paymentId)
        {
            var client = CreateClient(Environment.QueryUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}", Method.GET);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            var response = client.Execute(request);

            VerifyResponse(response);

            return JsonConvert.DeserializeObject<Transaction>(response.Content);
        }

        public virtual ReturnStatus CancellationTransaction(Guid requestId, Guid paymentId, decimal? amount = null)
        {
            var client = CreateClient(Environment.TransactionUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}/void", Method.PUT);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            if (amount.HasValue)
            {
                request.AddParameter("Amount", NumberHelper.DecimalToInteger(amount), ParameterType.QueryString);
            }

            var response = client.Execute(request);

            VerifyResponse(response);

            return JsonConvert.DeserializeObject<ReturnStatus>(response.Content);
        }

        public virtual ReturnStatus CaptureTransaction(Guid requestId, Guid paymentId, decimal? amount = null, decimal? serviceTaxAmount = null)
        {
            var client = CreateClient(Environment.TransactionUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}/capture", Method.PUT);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            if (amount.HasValue)
            {
                request.AddParameter("Amount", NumberHelper.DecimalToInteger(amount), ParameterType.QueryString);
            }

            if (serviceTaxAmount.HasValue)
            {
                request.AddParameter("SeviceTaxAmount", NumberHelper.DecimalToInteger(serviceTaxAmount), ParameterType.QueryString);
            }

            var response = client.Execute(request);

            VerifyResponse(response);

            return JsonConvert.DeserializeObject<ReturnStatus>(response.Content);
        }
    }
}
