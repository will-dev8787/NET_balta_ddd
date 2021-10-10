using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBankslipSubscriptionCommand : Notifiable<Notification>, ICommand
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

        public string BarCode { get; set; }

        public string BankslipNumber { get; set; }

        public string PaymentNumber { get; set; }

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

        public void Validate()
        {
            AddNotifications(new Contract<CreateBankslipSubscriptionCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(FirstName.Length, 3, "Name.FirstName", "FirstName too short")
                .IsGreaterOrEqualsThan(LastName.Length, 3, "Name.LastName", "LastName too short")
            );
        }
    }
}
