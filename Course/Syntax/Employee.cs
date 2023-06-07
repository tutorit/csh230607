using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Employee : Person
    {
        public double Salary { get; set; }
        public Employee(string name, double salary) : base(name)
        {
            Salary = salary;
        }

        override public void DoSomeWork()
        {
            Console.WriteLine("Yess SIR!!!");
        }


        public override string ToString()
        {
            return Name+" earns "+Salary+" EUR/month";
        }
    }
}
