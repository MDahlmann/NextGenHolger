namespace FindWally
{
    internal static class Messages
    {
        internal static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("""
                Welcome to "Where's Wally".
    
                Your task is to find the
                lonely '@' hiding among
                the other letters.
                
                Input desired difficulty:
                "Easy", "Medium" or "Hard"
    
                """);
        }

        internal static void InvalidDifficulty()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Try again.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        internal static void ChosenDifficulty(string difficulty)
        {
            Console.Clear();
            Console.WriteLine($"""
                You've picked '{difficulty}' difficulty.
                Get ready - the game is about to begin!
                """);

            Thread.Sleep(3000);
        }

        internal static void Countdown()
        {
            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            Console.Clear();
        }

        internal static void PlayAgain(string difficulty, ref bool loop)
        {
            Console.WriteLine("""

                Do you want to play again?
                "Yes" or "No"
                """);

            string svar = Console.ReadLine().ToLower();

            while (!(svar == "yes" || svar == "no"))
            {
                Console.Clear();
                Highscores.PrintHighscore(difficulty);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Invalid input");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("""

                Do you want to play again?
                "Yes" or "No"
                """);
                svar = Console.ReadLine().ToLower();
            }

            if (svar == "no") loop = false;
            else if (svar == "yes") loop = true;
        }
    }
}
