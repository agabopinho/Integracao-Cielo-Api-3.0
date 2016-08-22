using Microsoft.VisualStudio.TestTools.UnitTesting;
using Duarti.Maverick.Cielo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duarti.Maverick.Cielo.Model;
using Duarti.Maverick.Cielo.Configurations;

namespace Duarti.Maverick.Cielo.Tests
{
    [TestClass()]
    public class CieloApiTests
    {
        private CieloApi api;

        [TestInitialize]
        public void ConfigEnvironment()
        {
            api = new CieloApi(CieloEnvironment.Sandbox, Merchant.Sandbox);
        }

        [TestMethod()]
        public void CriaUmaTransacaoAutorizadaSemCapturaResultadoAutorizada()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.Authorized1, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, false, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Authorized, "Transação não foi autorizada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCapturaAutorizadaComParcelaMenorQueCincoReaisResultadoNaoAutorizada()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.Authorized1, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(1000, Enums.Currency.BRL, 10, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            // Email enviado sobre o problema.
            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoAutorizadaComCapturaResultadoPagamentoConfirmado()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.Authorized1, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.PaymentConfirmed, "Transação não teve pagamento confirmado");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoNaoAutorizadoResultadoNaoAutorizar()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorized, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoBloqueadoResultadoNaoAutorizar()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorizedCardBlocked, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoCanceladoResultadoNaoAutorizar()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorizedCardCanceled, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoExpiradoResultadoNaoAutorizar()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorizedCardExpired, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoComProblemasResultadoNaoAutorizar()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorizedCardProblems, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoDeTimeOutInternoCieloResultadoNaoAutorizado()
        {
            var merchantOrderId = new Random().Next();
            var customer = new Customer("Fulano da Silva");
            var creditCard = new CreditCard(SandboxCreditCard.NotAuthorizedTimeOut, "Teste Holder", new DateTime(DateTime.Now.Year + 1, 12, 1), "123", Enums.CardBrand.Visa);
            var payment = new Payment(15700, Enums.Currency.BRL, 1, true, ".Net Test Project", creditCard);
            var transaction = new Transaction(merchantOrderId.ToString(), customer, payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }
    }
}