using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisGame : ITennisService
    {
        private readonly ITennisPointWinnerService _pointWinnerService;

        private int _player1Score = 0;
        private int _player2Score = 0;
        
        public TennisGame(ITennisPointWinnerService pointWinnerService)
        {
            _pointWinnerService = pointWinnerService;
        }

        public GameResult PlayGame()
        {
            while (!HasGameBeenWon())
            {
                PlayPoint();
            }

            return new GameResult(_player1Score, _player2Score);
        }

        private void PlayPoint()
        {
            if (_pointWinnerService.DecideIfPlayer1Winner())
            {
                _player1Score += 1;
                return;
            }

            _player2Score += 1;
        }

        private bool HasGameBeenWon()
        {
            return PlayerWins(_player1Score, _player2Score)
                   || PlayerWins(_player2Score, _player1Score);
        }

        private bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
             => ((scoreToCheck - scoreToCompareAgainst) >= 2) && (scoreToCheck >= 4);
        
    }
}
