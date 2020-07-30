using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class XsvLogFormatter : ILogFormatter
    {
        protected char Seperator;
        public XsvLogFormatter(char seperator) { this.Seperator = seperator; }

        public static XsvLogFormatter Instance(char seperator) => new XsvLogFormatter(seperator);

        public string Header => $"level{Seperator}date{Seperator}source" + $"{Seperator}threadId{Seperator}ProcessId{Seperator}message"
            + $"{Seperator}name:value pairs";

        public string Footer => string.Empty;

        public string FileExtention => "log";

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()}{Seperator}{entry.DateTime.ToString()}"
                + $"{Seperator}{entry.Source.ToString()}{Seperator}{entry.ThreadId.ToString()}"
                + $"{Seperator}{entry.ProcessId}{Seperator}{entry.Message}{Seperator}"
                + string.Join($"{Seperator}", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }
    }
}
