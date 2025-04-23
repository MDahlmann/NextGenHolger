namespace FindWally
{
    internal class Wally
    {
        internal string[] wallyCoordinates { get; set; }
        internal string columnGuess { get; set; }
        internal string rowGuess { get; set; }


        internal Wally()
        {

        }

        internal void SetWallyCoordinates(int width, int height)
        {
            Random rnd = new Random();
            wallyCoordinates = new string[2];
            wallyCoordinates[0] = rnd.Next(1, width).ToString();
            wallyCoordinates[1] = rnd.Next(1, height).ToString();
        }

        internal void PlayerGuessInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("""


                Have you located Wally?

                """);
            Console.Write("Input column: ");
            columnGuess = Console.ReadLine();

            Console.Write("Input row:   ");
            rowGuess = Console.ReadLine();

            Console.WriteLine();
        }

        internal void WrongGuess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("""


            Wrong - try again!

            """);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input column: ");
            columnGuess = Console.ReadLine();
            Console.Write("Input row:   ");
            rowGuess = Console.ReadLine();
            Console.WriteLine();
        }
    }
}