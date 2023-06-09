using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Exceptions
    {
        static string CalculateWithExceptions(string s)
        {
            string[] parts = s.Split();
            int f1 = 0;
            try
            {
                f1 = int.Parse(parts[0]);
            }
            catch (FormatException nef)
            {
                Console.WriteLine("Bad number 1");
                return "";
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine("Not a calculation");
                return "";
            }
            int f2;
            try
            {
                f2 = int.Parse(parts[2]);
            }
            catch (FormatException nef)
            {
                Console.WriteLine("Bad number 2");
                return "";
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine("Not a calculation");
                return "";
            }
            string oper = parts[1];
            if (oper == "+")
            {
                return f1 + "+" + f2 + "=" + (f1 + f2);
            }
            if (oper == "*")
            {
                return f1 + "+" + f2 + "=" + (f1 * f2);
            }
            return "";
        }

        public static void Tester()
        {
            Console.WriteLine(CalculateWithExceptions("1 + 2"));
        }

    }

}
