using System.Linq;
using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();

            // Groups any notifications that might exist inside each of the ValueObjects below.
            AddNotifications(name, document, email);
        }

        /*
         * OPEN / CLOSED principle: by defining all of the 'setters' of my class private, I'm ensuring that no one outside from this class, can alter
         *  my object's instance.
         */

        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasActiveSubscription = false;

            foreach(var sub in _subscriptions)
            {
                if (sub.Active)
                    hasActiveSubscription = true;

            }

            // Using the Contract approach...
            AddNotifications(new Contract<Student>()
                .Requires()
                .IsFalse(hasActiveSubscription, "Student.Subscriptions", "You already have an active subscription")
                .IsGreaterThan(subscription.Payments.Count, 0, "Student.Subscription.Payments", "This subscription has no payments")
            );


            if (IsValid) 
            {
                // I'm not sure about this... I have to check if the instance is valid before trying to add the subscription and if I DON'T add it,
                // the one calling it must check. Whereas if I was working with Exceptions, I could just throw one and I would be sure that whoever 
                // called this method would have to know something failed.
                _subscriptions.Add(subscription);
            }

            //// In case I don't want to work with the 'Contract' pattern...
            //if (hasActiveSubscription)
            //    AddNotification("Student.Subscriptions", "You already have an active subscription");
        }

        public override string ToString()
        {
            return $"{Name.FirstName} {Name.LastName}";
        }
    }
}