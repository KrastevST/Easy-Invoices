namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;

    public interface IWriterToWord
    {
        void SaveInvoiceToWord(object fileName, object saveAs, Invoice invoice);
    }
}
