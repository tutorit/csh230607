using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class Person
    {
        private string _name="Unnamed";
        private string _email = "";
        private DateOnly? _birthday=null;

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
    }
}
