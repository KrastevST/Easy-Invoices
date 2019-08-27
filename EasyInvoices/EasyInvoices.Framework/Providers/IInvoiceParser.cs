namespace EasyInvoices.Framework.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInvoiceParser
    {
        ICollection<string> SeparateStringToInvoiceStrings(string fileAsString, IPrimitiveParser parser);
        Invoice ParseInvoiceFromString(string invoiceAsString, IPrimitiveParser parser);
    }
}
