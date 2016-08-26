using Cielo.Configurations;
using Cielo.Models;
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

            var response = client.Post<Transaction>(request);

            VerifyResponse(response);

            return response.Data;
        }

        public virtual Transaction GetTransaction(Guid requestId, Guid paymentId)
        {
            var client = CreateClient(Environment.QueryUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}", Method.GET);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            var response = client.Get<Transaction>(request);

            VerifyResponse(response);

            return response.Data;
        }

        public virtual ReturnStatus CancellationTransaction(Guid requestId, Guid paymentId, int? amount = default(int?))
        {
            var client = CreateClient(Environment.TransactionUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}/void", Method.PUT);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            if (amount.HasValue)
            {
                request.AddParameter("Amount", amount, ParameterType.QueryString);
            }

            var response = client.Put<ReturnStatus>(request);

            VerifyResponse(response);

            return response.Data;
        }

        public virtual ReturnStatus CaptureTransaction(Guid requestId, Guid paymentId, int? amount = default(int?), int? serviceTaxAmount = default(int?))
        {
            var client = CreateClient(Environment.TransactionUrl, Merchant);
            var request = CreateRequest(requestId, "/1/sales/{PaymentId}/capture", Method.PUT);

            request.AddParameter("PaymentId", paymentId, ParameterType.UrlSegment);

            if (amount.HasValue)
            {
                request.AddParameter("Amount", amount, ParameterType.QueryString);
            }

            if (serviceTaxAmount.HasValue)
            {
                request.AddParameter("SeviceTaxAmount", serviceTaxAmount, ParameterType.QueryString);
            }

            var response = client.Put<ReturnStatus>(request);

            VerifyResponse(response);

            return response.Data;
        }
    }
}
