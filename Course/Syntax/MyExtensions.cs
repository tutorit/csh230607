using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal static class MyExtensions
    {

        static public string Left(this string s,int n)
        {
            return s.Substring(0, 3);
        }

        static public string Right(this string s, int n)
        {
            return s.Substring(s.Length - 3);
        }
    }
}
