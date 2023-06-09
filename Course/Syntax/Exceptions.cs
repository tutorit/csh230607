using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Exceptions
    {
        static int PromptForInt(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string s = Console.ReadLine();
                    return int.Parse(s);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Not a number");
                }

            }
        }

        static string LessExceptions(string s)
        {
            if (s == null) return "Cannot calculate null";
            string[] parts = s.Split();
            if (parts.Length < 3) return "Not a calculation";
            bool bValid1 = int.TryParse(parts[0], out int f1);
            bool bValid2 = int.TryParse(parts[2], out int f2);
            if (!(bValid1 && bValid2)) return "Bad numbers";
            if (f1 > 100) throw new CalculateException("Too big", f1);
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
            int i=PromptForInt("Give a number:");
            Console.WriteLine(CalculateWithExceptions("4 + 5"));
            Console.WriteLine(LessExceptions("1 + 2"));
            Console.WriteLine(LessExceptions("a + 2"));
            try
            {
                Console.WriteLine(LessExceptions("130 + 6"));
            }
            catch(CalculateException cex)
            {
                Console.WriteLine("Caught own exception " + cex.Message + "," + cex.Figure1);
            }
        }

    }

}
