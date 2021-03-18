namespace EasyInvoices.Framework.Providers.Contracts
{
    public interface IDecimalParser
    {
        decimal ParseDecimal(string value);
    }
}
