using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal class PersonList
    {
        List<Person> persons = new()
        {
            new Person("Aapo","aapo@brothers.net","1.2.1950"),
            new Person("Tuomas","tuomas@brothers.net","1.2.1930"),
            new Person("Simeoni","simo@brothers.net","1.2.1960"),
            new Person("Eero","eeor@brothers.net","1.2.1920"),
            new Person("Lauri","lauri@brothers.net","1.2.1970"),
            new Person("Juhani","juhani@brothers.net","1.2.1910"),
            new Person("Timo","timo@brothers.net","1.2.1980"),
        };

        public void ShowAll(string title = "_____ALL_____")
        {
            Console.WriteLine(title);
            foreach (Person p in persons) Console.WriteLine(p);
        }
    }
}
