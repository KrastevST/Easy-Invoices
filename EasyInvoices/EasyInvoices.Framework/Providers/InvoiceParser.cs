namespace EasyInvoices.Framework.Providers
{
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
        public IEnumerable<string> parseInvoices(string fileAsString)
        {
            string separator = "" + this.separatorChar + this.separatorChar;
            var result = Regex.Split(fileAsString, separator);

            return result;
        }
    }
}
