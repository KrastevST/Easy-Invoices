namespace EasyInvoices.Framework.Providers.Contracts
{
    using EasyInvoices.Framework.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDateParser
    {
        string ParseDateFromInvoice(IInvoice invoice);
    }
}
