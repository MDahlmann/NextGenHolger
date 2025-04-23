using System.Diagnostics;

namespace FindWally
{
    internal static class GameLogic
    {
        public static void StartGame()
        {
            bool loop = true;

            do
            {
                Stopwatch timer = new Stopwatch();

                Playboard playboard = new Playboard();

                Wally wally = new Wally();


                timer.Reset();

                Messages.WelcomeMessage();

                playboard.GetSetDifficulty();

                Messages.ChosenDifficulty(playboard.Difficulty);

                Messages.Countdown();

                playboard.GenerateBoard();

                wally.SetWallyCoordinates(playboard.Width, playboard.Height);

                playboard.PlaceWally(wally.wallyCoordinates);

                playboard.PrintBoard();

                timer.Start();

                wally.PlayerGuessInput();


                while (!(wally.columnGuess == wally.wallyCoordinates[1] && wally.rowGuess == wally.wallyCoordinates[0]))
                {
                    Console.Clear();
                    playboard.PrintBoard();
                    wally.WrongGuess();
                }
                if (wally.columnGuess == wally.wallyCoordinates[1] && wally.rowGuess == wally.wallyCoordinates[0])
                {
                    timer.Stop();
                    Console.WriteLine("Congratulations - you've found Wally!");
                    Console.WriteLine($"You did it in: {timer.Elapsed.Minutes:D2}m {timer.Elapsed.Seconds:D2}s {timer.Elapsed.Milliseconds}ms");
                }

                Highscores.UpdateHighscore(timer, playboard.Difficulty);

                Highscores.PrintHighscore(playboard.Difficulty);

                Messages.PlayAgain(playboard.Difficulty, ref loop);

            } while (loop == true);
        }
    }
}
