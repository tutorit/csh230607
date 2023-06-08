using Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class CompanyReport : Report
    {
        private Company data;
        private IReporter rep;

        public CompanyReport(Company data,IReporter rep)
        {
            this.data = data;
            this.rep = rep;
        }

        override public void DoReport()
        {
            rep.BeginReport("Company Info");
            rep.PrintData("Company", data.Name);
            rep.PrintData("Address", data.Address);
            rep.EndReport("End of Company");
        }
    }
}
