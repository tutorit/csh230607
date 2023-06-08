using Syntax;
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
            return Name+","+Id+" earns "+Salary+" EUR/month";
        }
    }
}


class Superior : Employee
{
    public Superior(string name) : base(name, 10000)
    {

    }
}