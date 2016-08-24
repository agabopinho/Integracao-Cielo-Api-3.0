using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cielo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cielo.Models;
using Cielo.Configurations;

namespace Cielo.Tests
{
    [TestClass()]
    public class CieloApiTests
    {
        private CieloApi api;
        private DateTime validExpirationDate;
        private DateTime invalidExpirationDate;

        [TestInitialize]
        public void ConfigEnvironment()
        {
            api = new CieloApi(CieloEnvironment.Sandbox, Merchant.Sandbox);
            validExpirationDate = new DateTime(DateTime.Now.Year + 1, 12, 1);
            invalidExpirationDate = new DateTime(DateTime.Now.Year - 1, 12, 1);
        }

        [TestMethod()]
        public void CriaUmaTransacaoAutorizadaSemCapturaResultadoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.Authorized1, 
                holder: "Teste Holder", 
                expirationDate: validExpirationDate, 
                securityCode: "123", 
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700, 
                currency: Enums.Currency.BRL, 
                installments: 1, 
                capture: false, 
                softDescriptor: ".Net Test Project", 
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(), 
                customer: customer, 
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Authorized, "Transação não foi autorizada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCapturaAutorizadaComParcelaMenorQueCincoReaisResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.Authorized1,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 5,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: true,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Authorized, "Transação não foi autorizada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoAutorizadaComCapturaResultadoPagamentoConfirmado()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.Authorized1,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 2500,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: true,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.PaymentConfirmed, "Transação não teve pagamento confirmado");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoNaoAutorizadaResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorized,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoBloqueadoResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorizedCardBlocked,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoCanceladoResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorizedCardCanceled,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoExpiradoResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorizedCardExpired,
                holder: "Teste Holder",
                expirationDate: invalidExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoComProblemasResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorizedCardProblems,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }

        [TestMethod()]
        public void CriaUmaTransacaoComCartaoDeTimeOutInternoCieloResultadoNaoAutorizada()
        {
            var customer = new Customer(name: "Fulano da Silva");

            var creditCard = new CreditCard(
                cardNumber: SandboxCreditCard.NotAuthorizedTimeOut,
                holder: "Teste Holder",
                expirationDate: validExpirationDate,
                securityCode: "123",
                brand: Enums.CardBrand.Visa);

            var payment = new Payment(
                amount: 15700,
                currency: Enums.Currency.BRL,
                installments: 1,
                capture: false,
                softDescriptor: ".Net Test Project",
                creditCard: creditCard);

            /* store order number */
            var merchantOrderId = new Random().Next();

            var transaction = new Transaction(
                merchantOrderId: merchantOrderId.ToString(),
                customer: customer,
                payment: payment);

            var returnTransaction = api.CreateTransaction(Guid.NewGuid(), transaction);

            Assert.IsTrue(returnTransaction.Payment.Status == Enums.Status.Denied, "Transação não foi negada");
        }
    }
}