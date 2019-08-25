namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvoiceWriter : IWriter
    {
        private readonly string filePath;
        private readonly Invoice invoice;

        public InvoiceWriter(string filePath, Invoice  invoice)
        {
            this.filePath = filePath;
            this.invoice = invoice;
        }


    }
}
