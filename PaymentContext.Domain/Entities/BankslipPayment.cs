using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class BankslipPayment : Payment
    {
        public BankslipPayment(string barCode, string bankslipNumber, DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Email email,
            Document document,
            Address billingAddress) : base(paidDate, expireDate, total, totalPaid, payer, email, document, billingAddress)
        {
            BarCode = barCode;
            BankslipNumber = bankslipNumber;
        }

        public string BarCode { get; private set; }

        public string BankslipNumber { get; private set; }
    }
}
