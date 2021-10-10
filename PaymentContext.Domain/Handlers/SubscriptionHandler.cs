using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : 
        Notifiable<Notification>, 
        IHandler<CreateBankslipSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IEmailService _emailService;

        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            /*
             * !! DEPENDENCY INJECTION !!
             */
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBankslipSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Failed");
            }

            // Check if the document already exists
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Document already exists");

            // Check if email already exists
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "E-mail already exists");

            // Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);

            var address = new Address(
                street: command.Street,
                number: command.AddressNumber,
                addressComplement: command.AddressComplement,
                neighborhood: command.Neighborhood,
                city: command.City,
                state: command.State,
                country: command.Country,
                zipCode: command.ZipCode
            );

            // Create Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BankslipPayment(
                barCode: command.BarCode,
                bankslipNumber: command.BankslipNumber,
                paidDate: command.PaidDate,
                expireDate: command.ExpireDate,
                total: command.Total,
                totalPaid: command.TotalPaid,
                payer: command.Payer,
                email: email,
                document: new Document(command.PayerDocument, command.PayerDocumentType),
                billingAddress: address
            );

            // Create relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Group and apply validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Validate notifications
            if (!IsValid)
                return new CommandResult(false, "Something went wrong!");

            // Save
            _repository.CreateSubscription(student);

            // Send welcome e-mail
            _emailService.Send(student.Name.ToString(), student.Email.EmailAddress, "Welcome to the course!", "Subscription created!");

            // Return result
            return new CommandResult(true, "Subscription successful!");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //// Fail Fast Validations
            //command.Validate();

            //if (!command.IsValid)
            //{
            //    AddNotifications(command);
            //    return new CommandResult(false, "Failed");
            //}

            // Check if the document already exists
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Document already exists");

            // Check if email already exists
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "E-mail already exists");

            // Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);

            var address = new Address(
                street: command.Street,
                number: command.AddressNumber,
                addressComplement: command.AddressComplement,
                neighborhood: command.Neighborhood,
                city: command.City,
                state: command.State,
                country: command.Country,
                zipCode: command.ZipCode
            );

            // Create Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                transactionCode: command.TransactionCode,
                paidDate: command.PaidDate,
                expireDate: command.ExpireDate,
                total: command.Total,
                totalPaid: command.TotalPaid,
                payer: command.Payer,
                email: email,
                document: new Document(command.PayerDocument, command.PayerDocumentType),
                billingAddress: address
            );

            // Create relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Group and apply validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Save
            _repository.CreateSubscription(student);

            // Send welcome e-mail
            _emailService.Send(student.Name.ToString(), student.Email.EmailAddress, "Welcome to the course!", "Subscription created!");

            // Return result
            return new CommandResult(true, "Subscription successful!");
        }
    }
}
