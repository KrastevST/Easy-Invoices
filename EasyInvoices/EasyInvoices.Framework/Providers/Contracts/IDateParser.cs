using EasyInvoices.Framework.Models;

namespace EasyInvoices.Framework.Providers.Contracts
{
    public interface IDateParser
    {
        string ParseInvoiceDate(IInvoice invoice);
    }
}
