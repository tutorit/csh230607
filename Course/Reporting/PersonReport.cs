using Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class PersonReport // : ScreenReporter
    {
        private Person data;
        private IReporter rep; //=  new FileReporter(@"c:\data\person.txt");

        public PersonReport(Person data,IReporter rep)
        {
            this.data = data;
            this.rep = rep;
        }

        public void DoReport()
        {
            rep.BeginReport("Person info");
            rep.PrintData("Name", data.Name);
            rep.PrintData("Age", data.Age);
            rep.PrintData("Birthday", data.Birthday);
            rep.EndReport("End of data");
        }

    }
}
