namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class InvoiceParser : IInvoiceParser
    {
        private readonly char separatorChar;

        public InvoiceParser(char separator)
        {
            this.separatorChar = separator;
        }

        public ICollection<string> SeparateStringToInvoiceStrings(string fileAsString)
        {
            string separator = "" + this.separatorChar + this.separatorChar;
            // Trim to avoid empty entries
            var separatedInvoices = Regex.Split(fileAsString.Trim(separatorChar), separator);

            return separatedInvoices;
        }

        public Invoice ParseInvoiceFromString(string invoiceAsString, IPrimitiveParser parser)
        {
            var invoiceAsArray = invoiceAsString.Split(new char[] { this.separatorChar }, StringSplitOptions.RemoveEmptyEntries);
            string invNum = invoiceAsArray[0];
            decimal days = parser.parseDecimal(invoiceAsArray[1]);
            decimal rate = parser.parseDecimal(invoiceAsArray[2]);
            string currency = invoiceAsArray[3];
            decimal vat = parser.parseDecimal(invoiceAsArray[4].Trim('%'));

            var parsedInvoice = new Invoice(invNum, days, rate, currency, vat);

            return parsedInvoice;
        }
    }
}
