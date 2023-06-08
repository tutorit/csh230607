// See https://aka.ms/new-console-template for more information
using Syntax;
using Reporting;

Console.WriteLine("Reporting");

static void ReportingV1()
{
    Person p = new Person("Mike") { BirthdayString = "2.4.1980" };
    ScreenReporter rep = new ScreenReporter();
    rep.BeginReport("Person info");
    rep.PrintData("Name", p.Name);
    rep.PrintData("Age", p.Age);
    rep.PrintData("Birthday", p.Birthday);
    rep.EndReport("End of data");
}

static void ReportingV2()
{
    Person p = new Person("Mike") { BirthdayString = "2.4.1980" };
    ScreenReporter sr = new ScreenReporter();
    FileReporter fr = new FileReporter(@"c:\data\person.txt");
    PersonReport pr = new PersonReport(p, sr);
    pr.DoReport();
}


static void ReportingV3()
{
    Person p = new Person("Mike") { BirthdayString = "2.4.1980" };
    Company c = new Company { Name = "Coders Unlimited", Address = "Bug alley 5" };

    Formatter upper = (a, b) => $"{a.ToUpper()} - {b}";
    Formatter xml = (a, b) => $"<{a}>{b}</{a}>";
    Formatter columns = (a, b) => $"{a.PadRight(20)}{b}";

    ScreenReporter sr = new ScreenReporter();
    FileReporter fr = new FileReporter(@"c:\data\person.txt");
    sr.Formatter = columns;

    PersonReport pr = new PersonReport(p, sr);
    pr.DoReport();

    FileReporter cfr = new FileReporter(@"c:\data\comp.txt");
    cfr.Formatter = xml;
    CompanyReport cr = new CompanyReport(c, cfr);
    cr.DoReport();

}

Formatter upper = (a, b) => $"{a.ToUpper()} - {b}";
Formatter xml = (a, b) => $"<{a}>{b}</{a}>";
Formatter columns = (a, b) => $"{a.PadRight(20)}{b}";

Person p = new Person("Mike") { BirthdayString = "2.4.1980" };
Company c = new Company { Name = "Coders Unlimited", Address = "Bug alley 5" };

Report r1 = Report.Create(p); // PersonReport to Screen
r1.DoReport();

Report r2 = Report.Create(c, @"c:\data\comp.txt"); // CompanyReport to file
r2.DoReport();

Report r3 = Report.Create(p, @"c:\data\person.txt", xml); // Person,file,formatter
r3.DoReport();

Report r4 = Report.Create(c, columns); // Company, screen, formatter
r4.DoReport();
