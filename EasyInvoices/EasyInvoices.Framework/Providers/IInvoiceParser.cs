namespace EasyInvoices.Framework.Providers
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
        Invoice ParseInvoiceFromString(string invoiceAsString, IPrimitiveParser parser);
    }
}
