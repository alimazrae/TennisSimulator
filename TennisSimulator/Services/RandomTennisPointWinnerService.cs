using System;
using TennisSimulator.Data;

namespace TennisSimulator.Services
{
    public class RandomTennisPointWinnerService : ITennisPointWinnerService
    {
        private Random _random;

        public RandomTennisPointWinnerService()
        {
            _random = new Random();
        }

        public Player DecideWinner(Player player1, Player player2)
        {
            return _random.Next(0, 2) == 0 ? player1 : player2;
        }
    }
}
