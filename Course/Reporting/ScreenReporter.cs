using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class ScreenReporter : ReporterBase, IReporter
    {
        public override void CloseWriter(TextWriter writer)
        {
        }

        public override TextWriter GetWriter()
        {
            return Console.Out;
        }
    }
}
