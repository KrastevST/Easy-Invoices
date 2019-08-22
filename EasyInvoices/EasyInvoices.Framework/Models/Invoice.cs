namespace EasyInvoices.Framework.Models
{
    public class Invoice
    {
        private readonly string invoiceNumber;
        private readonly string invoiceDate;
        private readonly string currency;
        private readonly decimal days;
        private readonly decimal rate;
        private readonly decimal vat;

        public Invoice(string invoiceNumber, string invoiceDate, string currency, decimal days, decimal rate, decimal vat)
        {
            this.invoiceNumber = invoiceNumber;
            this.invoiceDate = invoiceDate;
            this.currency = currency;
            this.days = days;
            this.rate = rate;
            this.vat = vat;
        }

        public string InvoiceNumber { get => this.invoiceNumber; }
        public string InvoiceDate { get => this.invoiceDate; }
        public string Currency { get => this.currency; }
        public decimal Days { get => this.days; }
        public decimal Rate { get => this.rate; }
        public decimal Vat { get => this.vat; }
    }
}
