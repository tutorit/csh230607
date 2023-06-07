// See https://aka.ms/new-console-template for more information

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

NumberGame();

