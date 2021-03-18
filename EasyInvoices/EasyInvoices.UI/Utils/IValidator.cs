namespace EasyInvoices.UI.Utils
{
    public interface IValidator
    {
        bool IsValidInput(string readPath, string sheet, string row, string savepath, string company);
    }
}
