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
        public string ParseDateFromInvoice(Invoice invoice)
        {
            string year = invoice.InvoiceNumber.Substring(0, 2);
            string month = invoice.InvoiceNumber.Substring(2, 2);

            string result =  $"{month} {year}";

            return result;
        }
    }
}
