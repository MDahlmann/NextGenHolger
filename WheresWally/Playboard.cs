namespace WheresWally
{
    internal class Playboard
    {
        internal int Height { get; set; }
        internal int Width { get; set; }
        internal string? Difficulty { get; set; }
        internal string[,]? Board { get; set; }

        internal Playboard()
        {
            Height = 0;
            Width = 0;
        }

        internal void GetSetDifficulty()
        {
            Difficulty = Console.ReadLine().ToUpper();

            while (!(Difficulty == "EASY" || Difficulty == "MEDIUM" || Difficulty == "HARD"))
            {
                Messages.WelcomeMessage();
                Messages.InvalidDifficulty();
                Difficulty = Console.ReadLine().ToUpper();
            }

            if (Difficulty == "EASY")
            {
                Height = 16;
                Width = 16;
            }
            else if (Difficulty == "MEDIUM")
            {
                Height = 31;
                Width = 31;
            }
            else if (Difficulty == "HARD")
            {
                Height = 46;
                Width = 46;
            }
        }

        internal void GenerateBoard()
        {
            Random rnd = new Random();

            Board = new string[Height, Width];

            Board[0, 0] = " ";

            for (int i = 1; i < Height; i++)
            {
                Board[i, 0] = i.ToString();
            }
            for (int i = 1; i < Width; i++)
            {
                Board[0, i] = i.ToString();
            }

            for (int i = 1; i < Height; i++)
            {
                for (int j = 1; j < Width; j++)
                {
                    Board[i, j] = rnd.Next(1, 3) == 1 ? ((char)rnd.Next('a', 'z')).ToString() : ((char)rnd.Next('A', 'Z')).ToString();
                }
            }
        }

        internal void PrintBoard()
        {
            Random rnd = new Random();
            for (int i = 0; i < Board?.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i == 0 || j == 0) Console.ForegroundColor = ConsoleColor.White;
                    else Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 15);
                    Console.Write(Board[i, j].PadLeft(3, ' '));
                }
            }
        }

        internal void PlaceWally(string[] holgerCoordinates)
        {
            Board[Convert.ToInt32(holgerCoordinates[0]), Convert.ToInt32(holgerCoordinates[1])] = "@";
        }
    }
}
