// See https://aka.ms/new-console-template for more information
using Syntax;
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

static void Swap(ref int a,ref int b)
{
    int c = a;
    a = b;
    b = c;
}

unsafe void TestDangerous(int* pi)
{

}

static void PersonTester()
{
    Person p = new() {Name="Mike",Email="mike@monroe.net" };
    Console.WriteLine(p.Name+","+p.Email+","+p.BirthdayString);
    p.BirthdayString = "6.7.1990";
    p.Name = "";
    Console.WriteLine(p.Name + "," + p.Email + "," + p.BirthdayString);

    DateTime bd = DateTime.Parse("1.2.1970");
    Console.WriteLine(bd.ToShortDateString());
    DateOnly dt = DateOnly.Parse("1.2.1980");
    Console.WriteLine(bd.ToString() + ":" + dt.ToString());
    p.Birthday = dt;
    Console.WriteLine(p.Birthday);
}

PersonTester();

/*
Vector v = new(2,5);
v.i = 12;
Console.WriteLine("i=" + v.i+", "+v.j);
/
/*
//NumberGame();
ListDemo();
int x = 1, y = 2;
Swap(ref x,ref  y);
Console.WriteLine($"{x},{y}");
*/
/*
int i = 32;
var j = 43;
//j = "Hello";
dynamic k = "Hello";
Console.WriteLine("Type of k " + k.GetType());
k = 32;
Console.WriteLine("Type of k " + k.GetType());
*/
