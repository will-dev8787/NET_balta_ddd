using Microsoft.VisualStudio.TestTools.UnitTesting;

using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        /*
         * Red, Green, Refactor Methodology
         * 
         * 1) Create tests that will fail (RED)
         * 2) Make them pass (GREEN)
         * 3) Refactor and improve the code (REFACTOR)
         */
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document(
                number: "123",
                documentType: EDocumentType.CNPJ
            );

            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document(
                number: "34110468000150",
                documentType: EDocumentType.CNPJ
            );

            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document(
                number: "123",
                documentType: EDocumentType.CPF
            );

            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("34225545806")]
        [DataRow("34225545807")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            // Using [DataTestMethod] and multiple [DataRow] allows me to test several different values against the same test.

            var doc = new Document(
                number: cpf,
                documentType: EDocumentType.CPF
            );

            Assert.IsTrue(doc.IsValid);
        }
    }
}
