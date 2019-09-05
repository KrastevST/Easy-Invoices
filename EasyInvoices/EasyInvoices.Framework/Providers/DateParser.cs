namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DateParser : IDateParser
    {
        public string ParseDateFromInvoice(IInvoice invoice)
        {
            string year = invoice.InvoiceNumber.Substring(0, 2);
            string month = invoice.InvoiceNumber.Substring(2, 2);
            string num = invoice.InvoiceNumber.Substring(4, 1);

            string result =  $"{month}-{year} {num}";

            return result;
        }
    }
}
