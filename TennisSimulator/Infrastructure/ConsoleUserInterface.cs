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

        public void WriteGame(Result gameResult)
        {
            Console.WriteLine($"{gameResult.Winner.CurrentScore.Points} - {gameResult.Loser.CurrentScore.Points} {gameResult.Winner.Name}");
        }

        public void WriteSet(Result result)
        {
            Console.WriteLine();
            Console.WriteLine(" ----- SET WINNER ----");
            Console.WriteLine($" ----- {result.Winner.Name} ----");
            Console.WriteLine();
        }

        public void WriteMatch(Result matchResult)
        {
            Console.WriteLine();
            Console.WriteLine(" ***** WINNER *****");
            Console.WriteLine($" ***** {matchResult.Winner.Name} *****");
            Console.WriteLine($" ***** {matchResult.Winner.CurrentScore.Sets} - {matchResult.Loser.CurrentScore.Sets} *****");
            Console.WriteLine();
        }
    }
}
