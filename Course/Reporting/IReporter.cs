using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal interface IReporter
    {
        void BeginReport(string title);
        void EndReport(string footer);

        void PrintData(string title, string data);
        void PrintData(string title, int? data);
        void PrintData(string title, DateOnly? data);
    }
}
