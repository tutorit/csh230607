// See https://aka.ms/new-console-template for more information
using Syntax;
using System.Reflection;
using System.Reflection.Metadata;

static void NumberGame()
{
    int secret = new Random().Next(100) + 1;
    Console.WriteLine("Guess a number 1-100 ("+secret+")");
    //int guess = 0;
    int numGuesses = 0;
    while (true)
    {
        Console.Write("Give a number: ");
        string guessString = Console.ReadLine();
        //guess = int.Parse(guessString);
        bool bSuccess = int.TryParse(guessString, out int guess);
        if (!bSuccess) continue;
        if ((guess < 1) || (guess > 100)) continue;
        numGuesses++;
        if (guess == secret) break;
        if (guess < secret) Console.WriteLine("Too small");
        if (guess > secret) Console.WriteLine("Too big");
    }
    Console.WriteLine($"You got it in {numGuesses} guesses!");
}

static void ListDemo()
{
    string weekdays = "Mon,Tue,Wed,Thu,Fri";
    string[] wda = weekdays.Split(',');
    foreach (string w in wda) Console.WriteLine(w);
    List<string> wdl = new List<string>(wda);
    foreach (string d in wdl) Console.WriteLine(d);
    Console.WriteLine(wda[^1]+":"+wdl[1]);
    wdl.RemoveAt(0);
    wdl.Insert(0, "Sun");
    foreach (string d in wdl) Console.WriteLine(d);
}

static void Swap<T>(ref T a,ref T b)
{
    T c = a;
    a = b;
    b = c;
}

unsafe void TestDangerous(int* pi)
{

}

static void ShowAndIncrement(ref Vector v)
{
    v.i++;
    v.j++;
    Console.WriteLine("Vector " + v.i + "," + v.j);
}

static void PersonModifier(Person p)
{
    p.Name += " mod";
}
static void PersonTester()
{
    Person p = new Person("Mike", "mike@monroe.net", "1.6.1990") ;
    Person p2 = new Person("Mike", "mike@monroe.net", "1.6.1990");

    (string n, string e) = p;
    Console.WriteLine("Deconstructed " + n + "," + e);
    Console.WriteLine("Persons are same " + (p == p2));
    PersonModifier(p);
    //Console.WriteLine(p.Name+","+p.Email+","+p.BirthdayString);
    Console.WriteLine(p);
    p.BirthdayString = "6.7.1990";
    p.Name = "";
    //Console.WriteLine(p.Name + "," + p.Email + "," + p.BirthdayString);
    Console.WriteLine(p);

    DateTime bd = DateTime.Parse("1.2.1970");
    Console.WriteLine(bd.ToShortDateString());
    DateOnly dt = DateOnly.Parse("1.2.1980");
    Console.WriteLine(bd.ToString() + ":" + dt.ToString());
    p.Birthday = dt;
    Console.WriteLine(p.Birthday);
}

static void ClassesStructsAndRecords()
{
    PersonTester();
    Vector v = new(5, 6);
    ShowAndIncrement(ref v);
    Console.WriteLine("Vector at main:" + v.i + "," + v.j);

    Customer c = new Customer("Coders Unlimited", 4500);
    Customer c2 = new Customer("Coders Unlimited", 4500);
    c2.Active = false;
    Console.WriteLine("Cust " + c + ", same " + (c == c2));
    Customer c3 = c2 with { name = "Testers limited" };
}

//ClassesStructsAndRecords();

static void ShowIt(Person p)
{
    p.DoSomeWork();
    Console.WriteLine(p);
}

static double Add(double a, double b)
{
    return a + b;
}

static void PrintPrice(double net, double vat, Calculate ct)
{
    double total = ct(net, vat);
    Console.WriteLine($"Net {net}EUR Vat {total-net}EUR Total {total}EUR");
}

//Calculate c = Add;
//Console.WriteLine("Sum " + c(2, 6));
/*
PrintPrice(100, 24, Add);
PrintPrice(200, 24, delegate (double a, double b)
{
    return a + (a * b) / 100;
});
PrintPrice(300, 0.24, (a, b) => a * (1 + b));


Pair<int,string> p = new Pair<int,string>(3, "degrees");
Console.WriteLine(p);

Pair<string,string> p2 = new Pair<string,string>("Hello", "World");
Console.WriteLine(p2);

Pair<string, DateTime> p3 = new("Today", DateTime.Now);
Console.WriteLine(p3);

Console.WriteLine(p3.GetFirst());

int a = 3, b = 5;
Swap(ref a,ref b);

double c = 4, d = 6;
Swap(ref c, ref d);
*/

static void Report(object o)
{
    Type t = o.GetType();
    ReportingAttribute ra = t.GetCustomAttribute<ReportingAttribute>();
    if (ra == null)
    {
        Console.WriteLine("Not reportable: " + t.Name);
        return;
    }
    Console.WriteLine(ra.Title);
    foreach (PropertyInfo pi in t.GetProperties())
    {
        ra = pi.GetCustomAttribute<ReportingAttribute>();
        if (ra == null) continue;
        object val = pi.GetValue(o);
        Console.WriteLine(ra.Title+"="+val);
    }
}

static void Reflection()
{
    Person p = new Person("Mike", "mike@monroe.net", "1.4.1990");
    Report(p);
    Company c = new Company { Name = "Coders", Address = "Some Street" };
    Report(c);

}

static void SetDemo()
{
    SortedSet<string> hs = new SortedSet<string>();
    hs.Add("Mon");
    hs.Add("Tue");
    hs.Add("Wed");
    hs.Add("Thu");
    hs.Add("Mon");
    foreach (string s in hs) Console.WriteLine(s);
    SortedSet<Company> cs = new SortedSet<Company>();
    cs.Add(new Company() { Name = "Coders", Address = "Featurestreet" });
    cs.Add(new Company() { Name = "ATesters", Address = "Bugstreet" });
    cs.Add(new Company() { Name = "Coders", Address = "Featurestreet" });
    foreach (Company c in cs) Console.WriteLine(c.Name);
}

static void DictDemo()
{
    Dictionary<string, Company> cd = new Dictionary<string, Company>();
    cd.Add("123", new Company() { Name = "Coders", Address = "Featurestreet" });
    cd.Add("345", new Company() { Name = "ATesters", Address = "Bugstreet" });
    //cd.Add("123", new Company() { Name = "Coders2", Address = "Featurestreet" });
    cd["123"] = new Company() { Name = "Coders2", Address = "Featurestreet" };
    cd["567"] = new Company() { Name = "Coders5", Address = "Featurestreet" };

    Console.WriteLine(cd["123"].Name);

    foreach (string key in cd.Keys) Console.WriteLine(key + " => " + cd[key].Name);
    foreach (Company c in cd.Values) Console.WriteLine(c.Name);
    foreach (var x in cd) Console.WriteLine(x.Key + " - " + x.Value.Name);
}

//SetDemo();
//DictDemo();

PersonList pl = new PersonList();
pl.ShowAll();

Console.WriteLine("Some numbers");
foreach(int n in pl.GiveSomeNumbers())
{
    Console.WriteLine("At main: " + n);
}
Console.WriteLine("Indexer " + pl[2]);
pl.PrintReverse();

Console.WriteLine("Reverse foreach");
foreach (Person p in pl.Reverse()) Console.WriteLine(p);

pl.SortByName();
pl.ShowAll("___Sorted by name___");
pl.SortByAge();
pl.ShowAll("___Sorted by age___");

Console.WriteLine("Aapo " + pl["Aapo"]);

Console.WriteLine("____Difficult?_____");
foreach(Person p in pl.OrderByNameAgeGreaterThan(50))
{
    Console.WriteLine(p);
}

Console.WriteLine("____Seniors_____");
foreach (string n in pl.NamesOfSeniors()) Console.WriteLine(n);

Console.WriteLine("___Tuples____");
foreach (var x in pl.GetTuples()) Console.WriteLine(x.Name + ":" + x.Age);

public delegate double Calculate(double a, double b);


/*

Employee e = new("Emil",3200);
Person p = new("Mike");

ShowIt(e);
ShowIt(p);
Console.WriteLine("We have " + (Person.NextId-1) + " Persons");

//NumberGame();
//ListDemo();

string s = "Hello world";
string s2 = "Hello world";
Console.WriteLine("Strings equal " + (s == s2));
Console.WriteLine(s.Substring(0, 3));
Console.WriteLine(s.Substring(s.Length - 3));

Console.WriteLine(MyExtensions.Left(s, 3));

Console.WriteLine(s.Left(3));
Console.WriteLine(s.Right(3));
*/