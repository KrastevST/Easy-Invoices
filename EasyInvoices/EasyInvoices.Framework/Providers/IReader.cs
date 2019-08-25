namespace EasyInvoices.Framework.Providers
{
    using System.Collections.Generic;

    public interface IReader
    {
        string Read();
        void Close();
    }
}
