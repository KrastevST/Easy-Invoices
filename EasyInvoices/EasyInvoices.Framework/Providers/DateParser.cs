using Bytes2you.Validation;
using EasyInvoices.Framework.Models;
using EasyInvoices.Framework.Providers.Contracts;

namespace EasyInvoices.Framework.Providers
{
    public class DateParser : IDateParser
    {
        public string ParseInvoiceDate(IInvoice invoice)
        {
            Guard.WhenArgument(invoice, "invoice").IsNull().Throw();

            string year = invoice.Number.Substring(0, 2);
            string month = invoice.Number.Substring(2, 2);
            string instance = invoice.Number.Substring(4, 1);

            string result =  $"{month}-{year} {instance}";

            return result;
        }
    }
}
