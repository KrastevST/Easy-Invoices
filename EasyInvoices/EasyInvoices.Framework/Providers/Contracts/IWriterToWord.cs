namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;

    public interface IWriterToWord
    {
        void SaveInvoiceToWord(string invTemplatePath, object saveAs, IInvoice invoice);
    }
}
