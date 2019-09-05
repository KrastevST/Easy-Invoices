namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInvoiceParser
    {
        IList<string> SeparateInvoiceStrings(string fileAsString);
        IInvoice ParseInvoiceFromString(string invoiceAsString, IPrimitiveParser parser);
    }
}
