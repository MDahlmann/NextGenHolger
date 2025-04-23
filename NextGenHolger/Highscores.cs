namespace FindWally
{
    internal static class Highscores
    {
        internal static string solutionPath = AppDomain.CurrentDomain.BaseDirectory;

        internal static string easyHighScoreName = "WallyHighScoreEasy.txt";
        internal static string mediumHighScoreName = "WallyHighScoreMedium.txt";
        internal static string hardHighScoreName = "WallyHighScoreHard.txt";

        internal static string easyHighScorePath = Path.Combine(solutionPath, easyHighScoreName);
        internal static string mediumHighScorePath = Path.Combine(solutionPath, mediumHighScoreName);
        internal static string hardHighScorePath = Path.Combine(solutionPath, hardHighScoreName);

        internal static void UpdateHighscore(System.Diagnostics.Stopwatch timer, string difficulty)
        {
            string highscoreFile = (difficulty == "EASY") ? easyHighScorePath :
                                   (difficulty == "MEDIUM") ? mediumHighScorePath :
                                   hardHighScorePath;

            Console.Write("Type in your name to see highscore: ");
            string name = Console.ReadLine();

            Console.Clear();

            string hs = File.ReadAllText(highscoreFile);

            List<string> list = new List<string>();

            if (hs != "") list = hs.Split(',').ToList();

            list.Add($"{timer.Elapsed.Minutes:D2}m {timer.Elapsed.Seconds:D2}s {timer.Elapsed.Milliseconds}ms - {name}");

            list.Sort();

            if (list.Count == 11) list.RemoveAt(10);

            string list1 = string.Join(',', list);

            File.WriteAllText(highscoreFile, list1);
        }

        internal static void PrintHighscore(string difficulty)
        {
            string highscoreFile = (difficulty == "EASY") ? easyHighScorePath :
                                   (difficulty == "MEDIUM") ? mediumHighScorePath :
                                   hardHighScorePath;

            string hs = File.ReadAllText(highscoreFile);

            List<string> list = new List<string>();

            if (hs != "") list = hs.Split(',').ToList();

            Console.WriteLine($"""
            Top 10 for difficulty: {difficulty}
            ___________________________________________

            """
            );

            int count = 1;
            foreach (string s in list)
            {
                Console.WriteLine($"{count.ToString().PadLeft(2, ' ')}: {s}");
                count++;
            }
            Console.WriteLine("___________________________________________");
        }
    }
}
