namespace EasyInvoices.Framework
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers;
    using EasyInvoices.Framework.Providers.Contracts;

    public class Engine
    {
        private readonly IInvoiceParser invParser;
        private readonly IPrimitiveParser primParser;
        private readonly IDateParser dateParser;
        private readonly IReader reader;
        private readonly IWriterToWord writer;
        private readonly string invoiceTemplatePath;
        private readonly string saveNameTemplate;
        private readonly string company;

        public Engine(IInvoiceParser invParser, IPrimitiveParser primParser, IDateParser dateParser, IReader reader, IWriterToWord writer, string invoiceTemplatePath, string saveNameTemplate, string company)
        {
            this.invParser = invParser;
            this.primParser = primParser;
            this.reader = reader;
            this.writer = writer;
            this.invoiceTemplatePath = invoiceTemplatePath;
            this.saveNameTemplate = saveNameTemplate;
            this.dateParser = dateParser;
            this.company = company;
        }

        public void Start()
        {
            var fileAsString = this.reader.Read();
            var separateInvoiceStrings = this.invParser.SeparateInvoiceStrings(fileAsString);

            foreach (var invString in separateInvoiceStrings)
            {
                IInvoice invoice = this.invParser.ParseInvoiceFromString(invString, this.primParser);
                string date = dateParser.ParseDateFromInvoice(invoice);
                // TODO - add company. 
                string savePath = string.Format(this.saveNameTemplate, this.company, date);

                this.writer.SaveInvoiceToWord(this.invoiceTemplatePath, savePath, invoice);
            }
        }
    }
}
