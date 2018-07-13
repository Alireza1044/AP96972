using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class CsvLogFormatter : XsvLogFormatter
    {
        private CsvLogFormatter():base(',') { }
        private static CsvLogFormatter _Instance;
        public new static CsvLogFormatter Instance => new CsvLogFormatter();
    }
}
