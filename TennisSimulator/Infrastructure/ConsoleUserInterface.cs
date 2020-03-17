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

        public void WriteGame(GameResult gameResult)
        {
            Console.WriteLine($"{gameResult.Player1Score} - {gameResult.Player2Score} {gameResult.Player1Win}");
        }

        public void WriteSet(SetResult result)
        {
            Console.WriteLine();
            Console.WriteLine(" ----- SET WINNER ----");
            Console.WriteLine($" ----- {result.Player1Win} ----");
            Console.WriteLine();
        }

        public void WriteMatch(MatchResult matchResult)
        {
            Console.WriteLine();
            Console.WriteLine(" ***** WINNER *****");
            Console.WriteLine($" ***** {matchResult.Player1Win} *****");
            Console.WriteLine($" ***** {matchResult.Player1Score} - {matchResult.Player2Score} *****");
            Console.WriteLine();
        }
    }
}
