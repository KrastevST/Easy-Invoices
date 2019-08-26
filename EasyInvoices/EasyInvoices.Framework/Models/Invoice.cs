using System;

namespace EasyInvoices.Framework.Models
{
    public class Invoice
    {
        private readonly string invoiceNumber;
        private readonly string currency;
        private readonly decimal days;
        private readonly decimal rate;
        private readonly decimal vat;

        public Invoice(string invoiceNumber, decimal days, decimal rate, string currency, decimal vat)
        {
            this.invoiceNumber = invoiceNumber;
            this.currency = currency;
            this.days = days;
            this.rate = rate;
            this.vat = vat;
        }

        public string InvoiceNumber { get => this.invoiceNumber; }
        public string Currency { get => this.currency.ToUpper(); }
        public decimal Days { get => this.days; }
        public decimal Rate { get => this.rate; }
        public decimal Vat { get => this.vat; }
        public DateTime InvoiceDate { get => DateTime.UtcNow.Date; }
        public DateTime DueDate { get => this.InvoiceDate.AddDays(7); }
        public decimal Amount { get => (this.days * this.rate); }
        public decimal VatAmount { get => (this.vat * this.Amount) / 100; }
        public decimal Total { get => this.Amount + this.VatAmount; }
    }
}
