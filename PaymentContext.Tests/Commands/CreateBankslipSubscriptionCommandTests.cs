using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBankslipSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBankslipSubscriptionCommand();
            command.FirstName = "";
            command.LastName = "";

            command.Validate();

            Assert.AreEqual(false, command.IsValid);
        }
    }
}
