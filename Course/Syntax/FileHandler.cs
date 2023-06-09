using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class FileHandler : IDisposable
    {
        StreamReader rd;

        public FileHandler(string fn)
        {
            rd = new StreamReader(fn);
        }

        public string ReadLine(out bool eof)
        {
            string ret = rd.ReadLine();
            eof = rd.EndOfStream;
            return ret;
        }

        public void Close()
        {
            Console.WriteLine("Closing");
            rd.Close();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing");
            Close();
        }

        ~FileHandler()
        {
            Console.WriteLine("Destroying");
            Close();
        }

        static public void WriteFile(string fn)
        {
            using (StreamWriter sw = new StreamWriter(fn))
            {
                Console.WriteLine("Give some text, enter ends: ");
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s.Length == 0) break;
                    sw.WriteLine(s);
                }
            }
        }

    }
}

