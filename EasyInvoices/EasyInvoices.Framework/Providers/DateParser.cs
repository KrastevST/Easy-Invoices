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
        public string ParseInvoiceDate(IInvoice invoice)
        {
            string year = invoice.Number.Substring(0, 2);
            string month = invoice.Number.Substring(2, 2);
            string instance = invoice.Number.Substring(4, 1);

            string result =  $"{month}-{year} {instance}";

            return result;
        }
    }
}
