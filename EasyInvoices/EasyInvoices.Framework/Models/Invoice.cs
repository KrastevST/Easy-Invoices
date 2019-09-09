using Bytes2you.Validation;
using System;

namespace EasyInvoices.Framework.Models
{
    public class Invoice : IInvoice
    {
        private readonly string invoiceNumber;
        private readonly string currency;
        private readonly decimal days;
        private readonly decimal rate;
        private readonly decimal vat;

        public Invoice(string invoiceNumber, decimal days, decimal rate, string currency, decimal vat)
        {
            Guard.WhenArgument(invoiceNumber, "invoiceNumber").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(days, "days").IsLessThan(0).Throw();
            Guard.WhenArgument(rate, "rate").IsLessThan(0).Throw();
            Guard.WhenArgument(currency, "currency").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(vat, "vat").IsLessThanOrEqual(0).Throw();

            this.invoiceNumber = invoiceNumber;
            this.currency = currency.ToUpper();
            this.days = days;
            this.rate = rate;
            this.vat = vat;
        }

        public string Number { get => this.invoiceNumber; }
        public string Currency { get => this.currency; }
        public decimal Days { get => this.days; }
        public decimal Rate { get => this.rate; }
        public decimal Vat { get => this.vat; }
        public DateTime DatePrinted { get => DateTime.UtcNow.Date; }
        public DateTime DueDate { get => this.DatePrinted.AddDays(7); }
        public decimal Amount { get => (this.days * this.rate); }
        public decimal VatAmount { get => (this.vat * this.Amount) / 100; }
        public decimal Total { get => this.Amount + this.VatAmount; }
    }
}
