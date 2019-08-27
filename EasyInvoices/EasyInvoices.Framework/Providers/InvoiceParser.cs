﻿namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class InvoiceParser : IInvoiceParser
    {
        private readonly char separatorChar;

        public InvoiceParser(char separator)
        {
            // TODO char cannot be * or \
            this.separatorChar = separator;
        }

        public IList<string> SeparateInvoiceStrings(string fileAsString)
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
            decimal? days = parser.ParseDecimal(invoiceAsArray[1]);
            decimal? rate = parser.ParseDecimal(invoiceAsArray[2]);
            string currency = invoiceAsArray[3];
            decimal? vat = parser.ParseDecimal(invoiceAsArray[4].Trim('%'));

            var parsedInvoice = new Invoice(invNum, days, rate, currency, vat);

            return parsedInvoice;
        }
    }
}
