using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    abstract internal class ReporterBase
    {
        private TextWriter writer;

        abstract public TextWriter GetWriter();
        abstract public void CloseWriter(TextWriter writer);
        public void BeginReport(string title)
        {
            writer = GetWriter();
            writer.WriteLine(title);
        }

        public void EndReport(string footer)
        {
            writer.WriteLine(footer);
            CloseWriter(writer);
        }


        public void PrintData(string title, string data)
        {
            writer.WriteLine($"{title}={data}");
        }

        public void PrintData(string title, int? data)
        {
            PrintData(title, data?.ToString() ?? "NaN");
        }

        public void PrintData(string title, DateOnly? data)
        {
            PrintData(title, data?.ToString() ?? "Not known");
        }
    }
}
