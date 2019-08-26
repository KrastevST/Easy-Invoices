﻿namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class InvoiceParser
    {
        private readonly char separatorChar;

        public InvoiceParser(char separator)
        {
            this.separatorChar = separator;
        }
        public ICollection<Invoice> parseInvoices(string fileAsString, IPrimitiveParser parser)
        {
            string separator = "" + this.separatorChar + this.separatorChar;
            // Trim to avoid empty entries
            var separatedInvoices = Regex.Split(fileAsString.Trim(separatorChar), separator);

            var result = new List<Invoice>();

            foreach (var inv in separatedInvoices)
            {
                var parsedInv = ParseInvoice(inv, parser);
                result.Add(parsedInv);
            }

            return result;
        }

        private Invoice ParseInvoice(string invoiceAsString, IPrimitiveParser parser)
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
