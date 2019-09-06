namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;

    public interface IDocWriter
    {
        void SaveToWord(string invTemplatePath, object saveAs, IInvoice invoice);
    }
}
