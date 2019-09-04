namespace EasyInvoices.Framework
{
    using EasyInvoices.Framework.Providers;
    using EasyInvoices.Framework.Providers.Contracts;

    public class Engine
    {
        private readonly IInvoiceParser invParser;
        private readonly IPrimitiveParser primParser;
        private readonly IReader reader;
        private readonly IWriterToWord writer;
        private readonly string invoiceTemplatePath;
        private readonly string saveNameTemplate;
        private readonly IDateParser dateParser;

        public Engine(IInvoiceParser invParser, IPrimitiveParser primParser, IDateParser dateParser, IReader reader, IWriterToWord writer, string invoiceTemplatePath, string saveNameTemplate)
        {
            this.invParser = invParser;
            this.primParser = primParser;
            this.reader = reader;
            this.writer = writer;
            this.invoiceTemplatePath = invoiceTemplatePath;
            this.saveNameTemplate = saveNameTemplate;
            this.dateParser = dateParser;
        }

        public void Start()
        {
            var fileAsString = this.reader.Read();
            var separateInvoiceStrings = this.invParser.SeparateInvoiceStrings(fileAsString);

            foreach (var invString in separateInvoiceStrings)
            {
                var invoice = this.invParser.ParseInvoiceFromString(invString, this.primParser);
                string date = dateParser.ParseDateFromInvoice(invoice);
                // TODO - add company. 
                string savePath = string.Format(this.saveNameTemplate, "Atradius", date);

                this.writer.SaveInvoiceToWord(this.invoiceTemplatePath, savePath, invoice);
            }
        }
    }
}
