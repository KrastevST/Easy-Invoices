using System;

namespace EasyInvoices.Framework.Models
{
    public interface IInvoice
    {
        string Number { get; }
        string Currency { get; }
        decimal Days { get; }
        decimal Rate { get; }
        decimal VatPercent { get; }
        DateTime DatePrinted { get; }
        DateTime DueDate { get; }
        decimal Amount { get; }
        decimal VatAmount { get; }
        decimal Total { get; }
    }
}
