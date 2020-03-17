using System;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisMatch : ITennisMatch
    {
        private readonly IUserInterface _userInterface;
        private Player _player1;
        private Player _player2;

        public TennisMatch(IUserInterface userInterface, Player player1, Player player2)
        {
            this._player1 = player1;
            this._player2 = player2;
            _userInterface = userInterface;
        }

        public void PlayMatch()
        {
            _userInterface.Clear();

            Result matchResult = null;
            while (matchResult == null)
            {
                PlaySet();
                matchResult = GetState();
            }
            _userInterface.WriteMatch(matchResult);
        }

        private void PlaySet()
        {
            var set = new TennisSet(_userInterface, _player1, _player2);
            set.PlaySet();
        }

        private Result GetState()
        {
            if (PlayerWins(_player1.CurrentScore.Sets, _player2.CurrentScore.Sets))
            {
                return new Result(_player1, _player2);
            }
            if (PlayerWins(_player2.CurrentScore.Sets, _player1.CurrentScore.Sets))
            {
                return new Result(_player2, _player1);
            }
            return null;
        }

        private static bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
            => (scoreToCheck - scoreToCompareAgainst > 0) && (scoreToCheck >= 2);
    }
}
