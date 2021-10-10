using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;

            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(EmailAddress, "Email.Address", "Invalid e-mail.")
            );
        }

        public string EmailAddress { get; private set; }
    }
}
