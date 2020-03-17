using System;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisGame : ITennisGame
    {
        private readonly IUserInterface _userInterface;
        private readonly ITennisPointWinnerService _pointWinnerService;

        private Player _player1;
        private Player _player2;
        
        public TennisGame(IUserInterface userInterface, ITennisPointWinnerService pointWinnerService, Player player1, Player player2)
        {
            _userInterface = userInterface;
            _pointWinnerService = pointWinnerService;
            this._player1 = player1;
            this._player2 = player2;
        }

        public Result PlayGame()
        {
            Result result = null;
            while (result == null)
            {
                PlayPoint();
                result = GetState();
            }

            _userInterface.WriteGame(result);

            result.Winner.CurrentScore.ScoreGame();
            result.Loser.CurrentScore.ResetPoints();

            return result;
        }

        private void PlayPoint()
        {
            var winner = _pointWinnerService.DecideWinner(_player1, _player2).Name;

            if (_player1.Name == winner)
            {
                _player1.CurrentScore.ScorePoint();
                return;
            }

            if (_player2.Name == winner)
            {
                _player2.CurrentScore.ScorePoint();
            }
        }

        private Result GetState()
        {
            if (PlayerWins(_player1.CurrentScore.Points, _player2.CurrentScore.Points))
            {
                return new Result(_player1, _player2);
            }
            if (PlayerWins(_player2.CurrentScore.Points, _player1.CurrentScore.Points))
            {
                return new Result(_player2, _player1);
            }
            return null;
        }

        private static bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
             => ((scoreToCheck - scoreToCompareAgainst) >= 2) && (scoreToCheck >= 4);
        
    }
}
