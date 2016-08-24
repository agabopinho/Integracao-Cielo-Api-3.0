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
    }
}
