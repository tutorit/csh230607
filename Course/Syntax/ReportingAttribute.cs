using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class ReportingAttribute : Attribute
    {
        public string Title { get; private set; }

        public ReportingAttribute(string t)
        {
            Title = t;
        }
    }
}
