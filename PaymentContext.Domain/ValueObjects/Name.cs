using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterOrEqualsThan(FirstName.Length, 3, "Name.FirstName", "FirstName too short")
                .IsGreaterOrEqualsThan(LastName.Length, 3, "Name.LastName", "LastName too short")
            );
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
