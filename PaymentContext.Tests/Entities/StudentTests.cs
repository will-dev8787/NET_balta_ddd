using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Payment _payment;

        public StudentTests()
        {
            _name = new Name("Akira", "Matsuguma");
            _document = new Document("35111507795", Domain.Enums.EDocumentType.CPF);
            _email = new Email("akira@akira.com");

            _address = new Address(
                street: "Rua A", 
                number: "1", 
                addressComplement: "", 
                neighborhood: "AA", 
                city: "São Paulo", 
                state: "SP", 
                country: "Brasil", 
                zipCode: "04152100"
            );

            _payment = new PayPalPayment(
                transactionCode: "12345678",
                paidDate: DateTime.Now,
                expireDate: DateTime.Now.AddDays(5),
                total: 100,
                totalPaid: 100,
                payer: "Akira",
                email: _email,
                document: _document,
                billingAddress: _address
            );

            _student = new Student(name: _name, document: _document, email: _email);
            _subscription = new Subscription(expireDate: null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(subscription: _subscription);
            Assert.IsFalse(_student.IsValid);
        }


        [TestMethod]
        public void ShouldReturnErrorWhenHasActiveSubscription()
        {
            _subscription.AddPayment(_payment);

            // First subscription should be OK and successful
            _student.AddSubscription(subscription: _subscription);
            Assert.IsTrue(_student.IsValid);

            // Second subscription should have an error and create a Notification
            _student.AddSubscription(subscription: _subscription);
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHasNoActiveSubscription()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.IsValid);
        }
    }
}
