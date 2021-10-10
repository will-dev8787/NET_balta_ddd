using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudent(string document)
        {
            return x => x.Document.Number == document;

            /*
             * Inside the 'StudentRepository', I would use a '_context' (to the database) to get the query expression from here to be used there, by Linq and the context.
             */
        }
    }
}
