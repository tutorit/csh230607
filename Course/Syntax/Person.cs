using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{

    record Customer(string name,double purchases)
    {
        public bool Active { get; set; }
    }

    [Reporting("Person info")]
    public class Person
    {
        private string _name="Unnamed";
        private string _email = "";
        private DateOnly? _birthday=null;
        public int Id { get;init; }
        public static int NextId { get; private set; } =1;

        //public Person() {}

        public Person(string name,string email="",DateOnly? bd = null)
        {
            Name = name;
            Email = email;
            Birthday = bd;
            Id = NextId++;
        }

        public Person(string name,string email,string bd)
        {
            Name = name;
            Email = email;
            BirthdayString = bd;
            Id = NextId++;
        }

        [Reporting("Full name")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) _name = value;
            }
        }

        public void Deconstruct(out string name,out string email)
        {
            name = Name;
            email = Email;
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value ?? "";
                //_email = value == null ? "" : value;
            }
        }

        public DateOnly? Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value == null) _birthday = null;
                else if (value <= DateOnly.FromDateTime(DateTime.Now)) _birthday = value;
            }
        }

        [Reporting("Birthday")]
        public string BirthdayString
        {
            get
            {
                return Birthday?.ToString() ?? "Not known";
            }
            set
            {
                Birthday = DateOnly.Parse(value);
            }
        }

        public int? Age
        {
            get
            {
                return DateTime.Now.Year - Birthday?.Year;
            }
        }

        virtual public void DoSomeWork()
        {
            Console.WriteLine("No, I'm too lazy");
        }

        public override string ToString()
        {
            return Name+"("+Id+")," + Email + "," + BirthdayString;
        }
    }
}
