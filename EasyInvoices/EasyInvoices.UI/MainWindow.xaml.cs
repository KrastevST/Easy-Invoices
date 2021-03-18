using EasyInvoices.Framework;
using EasyInvoices.Framework.Providers;
using EasyInvoices.Framework.Providers.Contracts;
using EasyInvoices.UI.ReferenceDependantProviders;
using EasyInvoices.UI.Utils;
using System;
using System.IO;
using System.Windows;

namespace EasyInvoices.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const char separator = '/';
        private const string docTemplatePath = "../../Invoice Template.doc";
        private const string fileNameTemplate = "Invoice_{0}_{1}.doc";
        private const string defaultSheet = "1";
        private const string defaultRow = "2";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                selectFileValue.Text = dialog.FileName;
            }
        }

        private void SelectDestinationBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                selectDestinationValue.Text = dialog.SelectedPath;
            }
        }

        private void GenerateInvoicesBtn_Click(object sender, RoutedEventArgs e)
        {
            var validator = new InputValidator();
            if (validator.IsValidInput(selectFileValue.Text, sheetValue.Text,
                        rowValue.Text, selectDestinationValue.Text,
                        companyNameValue.Text) == false)
            {
                return;
            }
            

            string readPath = selectFileValue.Text;
            int sheet = int.Parse(sheetValue.Text);
            int row = int.Parse(rowValue.Text);
            string savePathDir = selectDestinationValue.Text;
            string fullSavePath = $"{savePathDir}\\{fileNameTemplate}";
            string company = companyNameValue.Text;

            IInvoiceParser invParser = new InvoiceParser(separator);
            IDecimalParser primParser = new DecimalParser();
            IDateParser dateParser = new DateParser();
            IReader reader = new ExcelReader(readPath, sheet, row, separator);
            IDocWriter writer = new DocWriter();

            try
            {
                var engine = new Engine(invParser, primParser, dateParser, reader, writer, docTemplatePath, fullSavePath, company);
                engine.Start();
                MessageBox.Show("Invoices created successfully.");
                this.ResetForm();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullPath;

            if (File.Exists(docTemplatePath))
            {
                fullPath = System.IO.Path.GetFullPath(docTemplatePath);
                System.Diagnostics.Process.Start(fullPath);
            }
            else
            {
                MessageBox.Show("Template file could not be found.");
            }

        }

        private void ResetForm()
        {
            selectFileValue.Text = string.Empty;
            selectDestinationValue.Text = string.Empty;
            sheetValue.Text = defaultSheet;
            rowValue.Text = defaultRow;
        }
    }
}
