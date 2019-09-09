namespace EasyInvoices.UI.ReferenceDependantProviders
{
    using Bytes2you.Validation;
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.IO;
    using System.Reflection;
    using Word = Microsoft.Office.Interop.Word;

    public class DocWriter : IDocWriter
    {
        private const string numberPlaceholder = "<invnum>";
        private const string datePlaceholder = "<invdate>";
        private const string dueDatePlaceholder = "<duedate>";
        private const string currencyPlaceholder = "<curr>";
        private const string daysPlaceholder = "<days>";
        private const string ratePlaceholder = "<rate>";
        private const string vatPlaceholder = "<vat>";
        private const string amountPlaceholder = "<amount>";
        private const string vatamntPlaceholder = "<vatamnt>";
        private const string totalPlaceholder = "<total>";

        public void SaveAsDoc(string invTemplatePath, object saveAs, IInvoice invoice)
        {
            Guard.WhenArgument(invTemplatePath, "invTemplatePath").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(saveAs, "saveAs").IsNull().Throw();
            Guard.WhenArgument(invoice, "invoice").IsNull().Throw();

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document wordDoc = null;

            if (File.Exists(invTemplatePath))
            {
                object fullPath = Path.GetFullPath(invTemplatePath);

                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                wordDoc = wordApp.Documents.Open(ref fullPath, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);

                wordDoc.Activate();

                this.FindAndReplace(wordApp, numberPlaceholder, invoice.Number);
                this.FindAndReplace(wordApp, datePlaceholder, invoice.DatePrinted.ToString(@"dd-MM-yyyy"));
                this.FindAndReplace(wordApp, dueDatePlaceholder, invoice.DueDate.ToString(@"dd-MM-yyyy"));
                this.FindAndReplace(wordApp, currencyPlaceholder, invoice.Currency);
                this.FindAndReplace(wordApp, daysPlaceholder, invoice.Days.ToString("#.##"));
                this.FindAndReplace(wordApp, ratePlaceholder, invoice.Rate.ToString("n2"));
                this.FindAndReplace(wordApp, vatPlaceholder, invoice.VatPercent);
                this.FindAndReplace(wordApp, amountPlaceholder, invoice.Amount.ToString("n2"));
                this.FindAndReplace(wordApp, vatamntPlaceholder, invoice.VatAmount.ToString("n2"));
                this.FindAndReplace(wordApp, totalPlaceholder, invoice.Total.ToString("n2"));
            }
            else
            {
                throw new FileNotFoundException("File not found", invTemplatePath);
            }

            wordDoc.SaveAs2(ref saveAs, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing);

            wordDoc.Close();
            wordApp.Quit();
        }

        private void FindAndReplace(Word.Application wordApp, object toFindText, object replaceWithText)
        {
            Guard.WhenArgument(wordApp, "wordApp").IsNull().Throw();
            Guard.WhenArgument(toFindText, "toFindText").IsNull().Throw();
            Guard.WhenArgument(replaceWithText, "replaceWithText").IsNull().Throw();

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object matchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref toFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref matchAllForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

    }
}
