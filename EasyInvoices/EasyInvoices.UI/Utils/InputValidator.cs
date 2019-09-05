namespace EasyInvoices.UI.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;
    using EasyInvoices.UI;

    public class InputValidator : IValidator
    {
        public bool IsValidInput( string readPath , string sheet, string row, string savepath, string company)
        {
            if (IsSelected(readPath) == false)
            {
                MessageBox.Show("You must select an Excel file.");
                return false;
            }

            if (IsValidPositiveInt(sheet) == false)
            {
                MessageBox.Show("The chosen sheet must be an integer number greater than zero.");
                return false;
            }

            if (IsValidPositiveInt(row) == false)
            {
                MessageBox.Show("The chosen row must be an integer number greater than zero.");
                return false;
            }

            if (IsSelected(savepath) == false)
            {
                MessageBox.Show("You must select a destination folder.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(company))
            {
                MessageBox.Show("You must enter a company name.");
                return false;
            }

            if (this.IsValidFilename(company) == false)
            {
                MessageBox.Show("Company name can not contain any of the following characters: \n/\\:*?<>|");
                return false;
            }

            return true;
        }

        private bool IsValidPositiveInt(string input)
        {
            int result;

            int.TryParse(input, out result);

            if (result < 1)
            {
                return false;
            }

            return true;
        }

        private bool IsSelected(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return true;
        }

        private bool IsValidFilename(string input)
        {
            char[] invalidFileNameChars = { '/', '\\', ':', '*', '?', '<', '>', '|' };

            if (input.IndexOfAny(invalidFileNameChars) >= 0)
                return false;

            return true;
        }
    }
}