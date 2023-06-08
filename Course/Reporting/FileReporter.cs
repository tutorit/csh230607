using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class FileReporter : IReporter
    {
        private string filename;
        private StreamWriter wr;
        public FileReporter(string fn)
        {
            filename = fn;
        }

        public void BeginReport(string title)
        {
            wr = new StreamWriter(filename);
            wr.WriteLine(title);
        }

        public void EndReport(string footer)
        {
            wr.WriteLine(footer);
            wr.Flush();
            wr.Close();
        }

        public void PrintData(string title, string data)
        {
            wr.WriteLine($"{title}={data}");
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
