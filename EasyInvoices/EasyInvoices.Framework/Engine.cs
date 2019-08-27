namespace EasyInvoices.Framework
{
    using EasyInvoices.Framework.Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private readonly IInvoiceParser invParser;
        private readonly IPrimitiveParser primParser;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IInvoiceParser invParser, IPrimitiveParser primParser, IReader reader, IWriter writer)
        {
            this.invParser = invParser;
            this.primParser = primParser;
            this.reader = reader;
            this.writer = writer;
        }
    }
}
