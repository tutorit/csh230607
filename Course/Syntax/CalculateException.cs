using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class CalculateException : Exception
    {
        public int Figure1 { get; private set; }

        public CalculateException(string msg,int f1) : base(msg)
        {
            Figure1 = f1;
        }
    }
}
