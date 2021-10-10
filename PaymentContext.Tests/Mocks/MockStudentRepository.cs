using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class MockStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "12345678901")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "1@1.com")
                return true;

            return false;
        }
    }
}
