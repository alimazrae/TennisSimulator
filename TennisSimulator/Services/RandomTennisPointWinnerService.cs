using System;

namespace TennisSimulator.Services
{
    public class RandomTennisPointWinnerService : ITennisPointWinnerService
    {
        private Random _random;

        public RandomTennisPointWinnerService()
        {
            _random = new Random();
        }

        public bool DecideIfPlayer1Winner()
        {
            return _random.Next(0, 2) == 0;
        }
    }
}
