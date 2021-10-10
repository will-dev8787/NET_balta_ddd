using PaymentContext.Domain.Enums;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {
        /*
         * A Command is supposed to be the sum of everything I need to create a PayPalSubscription.
         * 
         * Below I have all the primitive types from every property, of every entity, necessary to create a PayPalSubscription in the database.
         */

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public string LastTransactionNumber { get; set; }

        public string PaymentNumber { get; private set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public string Payer { get; set; }

        public string PayerDocument { get; set; }

        public EDocumentType PayerDocumentType { get; set; }

        public string PayerEmail { get; set; }

        public string Street { get; set; }

        public string AddressNumber { get; set; }

        public string AddressComplement { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
