// See https://aka.ms/new-console-template for more information
using Syntax;
using Reporting;

Console.WriteLine("Reporting");

Console.Out.WriteLine("Hello");

Person p = new Person("Mike") { BirthdayString="2.4.1980"};
/*
Reporter rep = new Reporter();
rep.BeginReport("Person info");
rep.PrintData("Name", p.Name);
rep.PrintData("Age", p.Age);
rep.PrintData("Birthday", p.Birthday);
rep.EndReport("End of data");
*/
ScreenReporter sr = new ScreenReporter();
FileReporter fr = new FileReporter(@"c:\data\person.txt");

Formatter upper = (a, b) => $"{a.ToUpper()} - {b}";
Formatter xml = (a, b) => $"<{a}>{b}</{a}>";
Formatter columns = (a, b) => $"{a.PadRight(20)}{b}";

sr.Formatter = columns;

PersonReport pr = new PersonReport(p,sr);
pr.DoReport();
