namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWriter
    {
        void SaveInvoiceToWord(object fileName, object saveAs, Invoice invoice);
    }
}
