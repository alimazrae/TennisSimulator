using System;
using TennisSimulator.Data;

namespace TennisSimulator.Infrastructure
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteWithNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WaitForUserInput()
        {
            Console.Read();
        }

        public void WriteGame(GameResult gameResult, string name)
        {
            Console.WriteLine($"{gameResult.Player1Score} - {gameResult.Player2Score} {name}");
        }

        private void WriteSet(SetResult result, string name)
        {
            Console.WriteLine();
            Console.WriteLine(" ----- SET WINNER ----");
            Console.WriteLine($" ----- {name} ----");
            Console.WriteLine();

        }

        public void WriteMatch(MatchResult matchResult)
        {
            Console.WriteLine(" ***** WINNER *****");
            Console.WriteLine($" ***** {GetNameFromResult(matchResult, matchResult.Player1Win)} *****");
            Console.WriteLine($" ***** {matchResult.Player1Score} - {matchResult.Player2Score} *****");
            Console.WriteLine();
            Console.WriteLine();
            foreach (var set in matchResult.Sets)
            {
                WriteSet(set, GetNameFromResult(matchResult, set.Player1Win));
                foreach (var game in set.Games)
                {
                    WriteGame(game, GetNameFromResult(matchResult, game.Player1Win));
                }
            }
        }

        private string GetNameFromResult(MatchResult matchResult, bool player1Name)
        {
            return player1Name ? matchResult.Player1.Name : matchResult.Player2.Name;
        }

    }
}
