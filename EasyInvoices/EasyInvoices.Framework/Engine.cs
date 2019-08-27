namespace EasyInvoices.Framework
{
    using EasyInvoices.Framework.Providers;
    using EasyInvoices.Framework.Providers.Contracts;

    public class Engine
    {
        private readonly IInvoiceParser invParser;
        private readonly IPrimitiveParser primParser;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly string templatePath;
        private readonly string savePathTemplate;

        public Engine(IInvoiceParser invParser, IPrimitiveParser primParser, IReader reader, IWriter writer, string templatePath, string savePathTemplate)
        {
            this.invParser = invParser;
            this.primParser = primParser;
            this.reader = reader;
            this.writer = writer;
            this.templatePath = templatePath;
            this.savePathTemplate = savePathTemplate;
        }

        public void Start()
        {
            var fileAsString = this.reader.Read();
            var separateInvoiceStrings = this.invParser.SeparateInvoiceStrings(fileAsString);

            foreach (var invString in separateInvoiceStrings)
            {
                var invoice = this.invParser.ParseInvoiceFromString(invString, this.primParser);
                this.writer.SaveInvoiceToWord(this.templatePath, savePathTemplate, invoice);
            }
        }
    }
}
