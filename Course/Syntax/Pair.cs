using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Pair<T,S>
    {
        T a;
        S b;

        public Pair(T x, S y)
        {
            a = x;
            b = y;
        }

        public T GetFirst()
        {
            return a;
        }
        public override string ToString()
        {
            return $"({a},{b})";
        }
    }
}
