// See https://aka.ms/new-console-template for more information
using Syntax;
using Reporting;

Console.WriteLine("Reporting");

Person p = new Person("Mike") { BirthdayString="2.4.1980"};
/*
Reporter rep = new Reporter();
rep.BeginReport("Person info");
rep.PrintData("Name", p.Name);
rep.PrintData("Age", p.Age);
rep.PrintData("Birthday", p.Birthday);
rep.EndReport("End of data");
*/
PersonReport pr = new PersonReport(p);
pr.DoReport();
