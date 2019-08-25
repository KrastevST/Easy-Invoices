namespace TempClient
{
    using EasyInvoices.Framework.Providers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main()
        {
            var er = new ExcelReader(@"C:\Users\Wayfahrer\Desktop\2019 Financials IT&F.xlsx", 1, '/', 2);
            var parser = new InvoiceParser('/');
            var result = er.Read();
            er.Close();
            var parsedResult = parser.parseInvoices(result);

            foreach (var item in parsedResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
