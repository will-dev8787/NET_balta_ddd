using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new MockStudentRepository(), new MockEmailService());

            var command = new CreateBankslipSubscriptionCommand();
            command.FirstName = "Akira";

            command.LastName = "Matsuguma";

            // Same document value to the one defined in the MockRepository
            command.Document = "12345678901";

            command.Email = "a@a.com";

            command.BarCode = "123456789";

            command.BankslipNumber = "123456789";

            command.PaymentNumber = "123465";

            command.PaidDate = DateTime.Now;

            command.ExpireDate = DateTime.Now.AddMonths(1);

            command.Total = 60;

            command.TotalPaid = 60;

            command.Payer = "Matsu CORP";

            command.PayerDocument = "123456789";

            command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;

            command.PayerEmail = "aa@a.com";

            command.Street = "aaa";

            command.AddressNumber = "123";

            command.AddressComplement = "aaa";

            command.Neighborhood = "aaa";

            command.City = "aaa";

            command.State = "aaa";

            command.Country = "aaa";

            command.ZipCode = "aaa";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }
    }
}
