namespace EasyInvoices.Framework.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInvoice
    {
        string InvoiceNumber { get; }
        string Currency { get; }
        decimal? Days { get; }
        decimal? Rate { get; }
        decimal? Vat { get; }
        DateTime InvoiceDate { get; }
        DateTime DueDate { get; }
        decimal? Amount { get; }
        decimal? VatAmount { get; }
        decimal? Total { get; }
    }
}
