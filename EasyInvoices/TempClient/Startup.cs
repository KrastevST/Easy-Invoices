namespace TempClient
{
    using EasyInvoices.Framework.Models;
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
            var invParser = new InvoiceParser('/');
            var result = er.Read();
            var parser = new PrimitiveParser();
            var parsedResult = invParser.parseInvoices(result, parser);

            foreach (var item in parsedResult)
            {
                Console.WriteLine(item.Amount);
                Console.WriteLine(item.Currency);
                Console.WriteLine(item.Days);
                Console.WriteLine(item.DueDate);
                Console.WriteLine(item.InvoiceDate);
                Console.WriteLine(item.InvoiceNumber);
                Console.WriteLine(item.Rate);
                Console.WriteLine(item.Total);
                Console.WriteLine(item.Vat);
                Console.WriteLine(item.VatAmount);
                Console.WriteLine("-----------------");
            }

            //var inv = new Invoice("19011", 1.5m, 1.66m, "EUr", 50m);
            //var writer = new WordWriter();
            //writer.SaveInvoiceToWord(@"C:\Users\Wayfahrer\Desktop\Invoice Template.doc", @"C:\Users\Wayfahrer\Desktop\Test.doc", inv);
        }
    }
}
