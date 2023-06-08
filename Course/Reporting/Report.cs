using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax;

namespace Reporting
{
    public delegate void ReportDelegate(string stage);

    abstract internal class Report
    {
        static public event ReportDelegate ReportEvent;
        abstract public void DoReport();
        static public Report Create(object o, string fn="",Formatter f = null)
        {
            //ReportEvent?.Invoke("Initializing");
            if (ReportEvent != null) ReportEvent("Initializing");
            IReporter rep = string.IsNullOrEmpty(fn) ? new ScreenReporter() : new FileReporter(fn);
            ReportEvent?.Invoke("Created reporter");
            if (f != null) rep.Formatter = f;
            ReportEvent?.Invoke("Set formatter");
            /*
            if (o is Person) return new PersonReport(o as Person, rep);
            if (o is Company) return new CompanyReport(o as Company, rep);
            return null;
            */
            Report? ret = o switch
            {
                Person => new PersonReport(o as Person, rep),
                Company => new CompanyReport(o as Company, rep),
                _ => null
            };
            ReportEvent?.Invoke("Complete");
            return ret;
        }

        static public Report Create(object o, Formatter f)
        {
            return Create(o, "", f);
        }
    }
}
