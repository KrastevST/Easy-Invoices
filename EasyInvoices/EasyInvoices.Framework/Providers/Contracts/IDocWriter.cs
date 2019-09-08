namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;

    public interface IDocWriter
    {
        void SaveAsDoc(string invTemplatePath, object saveAs, IInvoice invoice);
    }
}
