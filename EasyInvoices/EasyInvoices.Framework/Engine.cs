namespace EasyInvoices.Framework
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers;
    using EasyInvoices.Framework.Providers.Contracts;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly IInvoiceParser invParser;
        private readonly IDecimalParser decParser;
        private readonly IDateParser dateParser;
        private readonly IReader reader;
        private readonly IDocWriter writer;
        private readonly string DocTemplatePath;
        private readonly string saveNameTemplate;
        private readonly string company;

        // TODO - check for nulls
        public Engine(IInvoiceParser invParser, IDecimalParser decParser, IDateParser dateParser, IReader reader, IDocWriter writer, string docTemplatePath, string saveNameTemplate, string company)
        {
            this.invParser = invParser;
            this.decParser = decParser;
            this.reader = reader;
            this.writer = writer;
            this.DocTemplatePath = docTemplatePath;
            this.saveNameTemplate = saveNameTemplate;
            this.dateParser = dateParser;
            this.company = company;
        }

        public void Start()
        {
            string fileAsString = this.reader.Read();
            IList<string> splitInvoices = this.invParser.SplitInvoices(fileAsString);

            foreach (string invAsStr in splitInvoices)
            {
                IInvoice parsedInv = this.invParser.ParseInvoice(invAsStr, this.decParser);
                string date = dateParser.ParseInvoiceDate(parsedInv);
                string savePath = string.Format(this.saveNameTemplate, this.company, date);

                this.writer.SaveAsDoc(this.DocTemplatePath, savePath, parsedInv);
            }
        }
    }
}
