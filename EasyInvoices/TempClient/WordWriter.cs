namespace TempClient
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers;
    using System;
    using System.IO;
    using System.Reflection;
    using Word = Microsoft.Office.Interop.Word;

    public class WordWriter : IWriter
    {
        private const string numberPlaceholder = "<invnum>";
        private const string datePlaceholder = "<invnum>";
        private const string currencyPlaceholder = "<invnum>";
        private const string daysPlaceholder = "<invnum>";
        private const string ratePlaceholder = "<invnum>";
        private const string vatPlaceholder = "<invnum>";

        public void SaveInvoiceToWord(object fileName, object saveAs, Invoice invoice)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document wordDoc = null;

            if (File.Exists((string)fileName))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                wordDoc = wordApp.Documents.Open(ref fileName, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);

                wordDoc.Activate();

                this.FindAndReplace(wordApp, numberPlaceholder, invoice.InvoiceNumber);
                //this.FindAndReplace(wordApp, datePlaceholder, invoice.InvoiceDate);
                //this.FindAndReplace(wordApp, currencyPlaceholder, invoice.Currency);
                //this.FindAndReplace(wordApp, daysPlaceholder, invoice.Days);
                //this.FindAndReplace(wordApp, ratePlaceholder, invoice.Rate);
                //this.FindAndReplace(wordApp, vatPlaceholder, invoice.Vat);
            }
            else
            {
                // TODO MesageBox.Show("File not Found!");
                throw new ArgumentNullException("File not found");
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
