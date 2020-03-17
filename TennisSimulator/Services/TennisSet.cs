using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisSet : ITennisSet
    {
        private readonly IUserInterface _userInterface;

        private List<GameResult> gameResults;
        
        public TennisSet(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        
        public SetResult PlaySet()
        {
            gameResults = new List<GameResult>();
            while (!HasSetBeenWon())
            {
                PlayGame();
            }

            return new SetResult(gameResults);
        }

        private void PlayGame()
        {
            var game = new TennisGame(_userInterface, new RandomTennisPointWinnerService());
            gameResults.Add(game.PlayGame());
        }

        private bool HasSetBeenWon()
        {
            var player1Games = gameResults.Count(x => x.Player1Win);
            var player2Games = gameResults.Count(x => !x.Player1Win);
            return PlayerWins(player1Games, player2Games)
                   || PlayerWins(player2Games, player1Games);
        }

        private static bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
            => ((scoreToCheck - scoreToCompareAgainst) >= 2) && (scoreToCheck >= 6);
    }
}
