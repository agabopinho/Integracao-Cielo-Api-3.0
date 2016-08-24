# Cielo-API-3.0

Projeto em .NET para integração com a API de pagamento Cielo API 3.0.

Exemplo de uso em ambiente SANDBOX:

```
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
```

Documentação de apoio da API Cielo: 
http://developercielo.github.io/Webservice-3.0

Merchant Key e Merchant Id para integração em Sandbox: 
https://cadastrosandbox.cieloecommerce.cielo.com.br

Git da Cielo: 
https://github.com/DeveloperCielo

Outras documentações em Cielo Developers:
https://www.cielo.com.br/desenvolvedores e http://bit.ly/2bO2Cw2