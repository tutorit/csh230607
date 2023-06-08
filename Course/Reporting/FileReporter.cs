using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    internal class FileReporter : ReporterBase, IReporter
    {
        private string filename;
        public FileReporter(string fn)
        {
            filename = fn;
        }

        public override void CloseWriter(TextWriter writer)
        {
            writer.Flush();
            writer.Close();
        }

        public override TextWriter GetWriter()
        {
            return new StreamWriter(filename);
        }
    }
}
