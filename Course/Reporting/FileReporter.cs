using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class FileReporter : IReporter
    {
        public void BeginReport(string title)
        {
            Console.WriteLine(title);
        }

        public void EndReport(string footer)
        {
            Console.WriteLine(footer);
        }

        public void PrintData(string title, string data)
        {
            Console.WriteLine($"{title}={data}");
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
