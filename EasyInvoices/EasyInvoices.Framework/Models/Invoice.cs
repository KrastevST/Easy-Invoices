using Bytes2you.Validation;
using System;
using System.Text.RegularExpressions;

namespace EasyInvoices.Framework.Models
{
    public class Invoice : IInvoice
    {
        private readonly string invoiceNumber;
        private readonly string currency;
        private readonly decimal days;
        private readonly decimal rate;
        private readonly decimal vatPercent;

        public Invoice(string invoiceNumber, decimal days, decimal rate, string currency, decimal vatPercent)
        {
            Guard.WhenArgument(invoiceNumber, "invoiceNumber").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(days, "days").IsLessThan(0).Throw();
            Guard.WhenArgument(rate, "rate").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(currency, "currency").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(vatPercent, "vat").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(vatPercent, "vat").IsGreaterThan(100).Throw();

            if (!Regex.IsMatch(invoiceNumber, "^[0-9]*$") ||
                    invoiceNumber.Length != 5)
            {
                throw new ArgumentException("invoiceNumber must consist of exactly five numeric symbols", "invoiceNumber");
            }

            if (!Regex.IsMatch(currency, "^[a-zA-Z]*$") ||
                    currency.Length != 3)
            {
                throw new ArgumentException("currency must consist of exactly three latin letters");
            }

            this.invoiceNumber = invoiceNumber;
            this.currency = currency.ToUpper();
            this.days = days;
            this.rate = rate;
            this.vatPercent = vatPercent;
        }

        public string Number { get => this.invoiceNumber; }
        public string Currency { get => this.currency.ToUpper(); }
        public decimal Days { get => this.days; }
        public decimal Rate { get => this.rate; }
        public decimal VatPercent { get => this.vatPercent; }
        public DateTime DatePrinted { get => DateTime.UtcNow.Date; }
        public DateTime DueDate { get => this.DatePrinted.AddDays(7); }
        public decimal Amount { get => (this.days * this.rate); }
        public decimal VatAmount { get => (this.vatPercent * this.Amount) / 100; }
        public decimal Total { get => this.Amount + this.VatAmount; }
    }
}
