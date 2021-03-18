using EasyInvoices.Framework.Models;
using System.Collections.Generic;

namespace EasyInvoices.Framework.Providers.Contracts
{
    public interface IInvoiceParser
    {
        IList<string> SplitInvoices(string fileAsString);
        IInvoice ParseInvoice(string invoiceAsString, IDecimalParser parser);
    }
}
