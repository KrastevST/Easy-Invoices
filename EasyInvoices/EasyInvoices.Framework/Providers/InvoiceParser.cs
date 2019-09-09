namespace EasyInvoices.Framework.Providers
{
    using Bytes2you.Validation;
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class InvoiceParser : IInvoiceParser
    {
        private readonly char separatorCh;

        public InvoiceParser(char separator)
        {
            this.separatorCh = separator;
        }

        public IList<string> SplitInvoices(string fileAsString)
        {
            Guard.WhenArgument(fileAsString, "fileAsString").IsNullOrWhiteSpace().Throw();

            string separatorStr = "" + this.separatorCh + this.separatorCh;
            // Trim to avoid empty entries
            var separatedInvoices = Regex.Split(fileAsString.Trim(this.separatorCh), separatorStr);

            return separatedInvoices;
        }

        public IInvoice ParseInvoice(string invoiceAsStr, IDecimalParser parser)
        {
            Guard.WhenArgument(invoiceAsStr, "invoiceAsStr").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            var invoiceAsArrOfStr = invoiceAsStr.Split(new char[] { this.separatorCh }, StringSplitOptions.RemoveEmptyEntries);
            string invNum = invoiceAsArrOfStr[0];
            decimal days = parser.ParseDecimal(invoiceAsArrOfStr[1]);
            decimal rate = parser.ParseDecimal(invoiceAsArrOfStr[2]);
            string currency = invoiceAsArrOfStr[3];
            decimal vat = parser.ParseDecimal(invoiceAsArrOfStr[4]) * 100;

            var parsedInvoice = new Invoice(invNum, days, rate, currency, vat);

            return parsedInvoice;
        }
    }
}
