using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Data;

namespace TennisSimulator.Services
{
    public class TennisSet : ITennisService
    {
        private readonly ITennisServiceFactory _serviceFactory;
        private List<GameResult> gameResults;
        
        public TennisSet(ITennisServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
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
            var game = _serviceFactory.GetGameService();
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
