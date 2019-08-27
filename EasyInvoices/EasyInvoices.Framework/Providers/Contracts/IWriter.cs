namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;

    public interface IWriter
    {
        void SaveInvoiceToWord(object fileName, object saveAs, Invoice invoice);
    }
}
