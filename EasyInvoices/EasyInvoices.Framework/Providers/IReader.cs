namespace EasyInvoices.Framework.Providers
{
    using System.Collections.Generic;

    public interface IReader
    {
        string Read(int startingRow);
        void Close();
    }
}
