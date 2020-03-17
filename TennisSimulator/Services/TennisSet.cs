using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisSet : ITennisSet
    {
        private readonly IUserInterface _userInterface;
        private Player _player1;
        private Player _player2;

        public TennisSet(IUserInterface userInterface, Player player1, Player player2)
        {
            _userInterface = userInterface;
            this._player1 = player1;
            this._player2 = player2;
        }
        
        public Result PlaySet()
        {
            Result setResult = null;
            while (setResult == null)
            {
                PlayGame();
                setResult = GetState();
            }

            _userInterface.WriteSet(setResult);

            setResult.Winner.CurrentScore.ScoreSet();
            setResult.Loser.CurrentScore.ResetGames();

            return setResult;
        }

        private void PlayGame()
        {
            var game = new TennisGame(_userInterface, new RandomTennisPointWinnerService(), _player1, _player2);
            game.PlayGame();
        }

        private Result GetState()
        {
            if (PlayerWins(_player1.CurrentScore.Games, _player2.CurrentScore.Games))
            {
                return new Result(_player1, _player2);
            }
            if (PlayerWins(_player2.CurrentScore.Games, _player1.CurrentScore.Games))
            {
                return new Result(_player2, _player1);
            }
            return null;
        }

        private static bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
            => ((scoreToCheck - scoreToCompareAgainst) >= 2) && (scoreToCheck >= 6);
    }
}
