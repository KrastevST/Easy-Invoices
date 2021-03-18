using EasyInvoices.Framework.Models;

namespace EasyInvoices.Framework.Providers.Contracts
{
    public interface IDocWriter
    {
        void SaveAsDoc(string invTemplatePath, object saveAs, IInvoice invoice);
    }
}
