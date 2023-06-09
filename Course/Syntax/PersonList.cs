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

        public IEnumerable<int> GiveSomeNumbers()
        {
            Console.WriteLine("G1");
            yield return 6;
            Console.WriteLine("G2");
            yield return 3;
            Console.WriteLine("G3");
            yield return 8;
            Console.WriteLine("G4");
        }

        public Person this[int n]
        {
            get
            {
                return persons[n];
            }
        }

        public Person this[string name]
        {
            get
            {
                return persons.Find(p => p.Name == name);
            }
        }

        public void PrintReverse()
        {
            Console.WriteLine("_____PrintReverse____");
            for (int i = persons.Count - 1; i >= 0; i--) Console.WriteLine(persons[i]);
        }

        public IEnumerable<Person> Reverse()
        {
            for (int i = persons.Count - 1; i >= 0; i--) yield return persons[i];
        }

        public void SortByName()
        {
            persons.Sort();
        }

        public void SortByAge()
        {
            persons.Sort((a, b) => a.Age.Value - b.Age.Value);
        }

        public IEnumerable<Person> OrderByNameAgeGreaterThan(int age)
        {
            //return from Person p in persons where p.Age > age orderby p.Name select p;
            return persons
                .Where(p => p.Age > age)
                .OrderBy(p => p.Name);
        }
        public IEnumerable<string> NamesOfSeniors()
        {
            var a = persons.Where(p => p.Age > 50);
            var b = a.OrderBy(p => p.Name);
            var c = b.Select(p => p.Name);
            //return from Person p in persons where p.Age > age orderby p.Name select p;
            return persons
                .Where(p => p.Age > 50)
                .OrderBy(p => p.Name)
                .Select(p => p.Name);
        }

        public IEnumerable<(string Name,int Age)> GetTuples()
        {
            return persons.Select(p => (p.Name, p.Age.Value));
        }
    }
}
