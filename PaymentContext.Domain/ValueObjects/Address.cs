using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string addressComplement, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            AddressComplement = addressComplement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract<Address>()
                .Requires()
                .IsNotNullOrEmpty(Street, "Address.Street", "Street can't be null or empty")
            );
        }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string AddressComplement { get; private set; }

        public string Neighborhood { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }
    }
}
