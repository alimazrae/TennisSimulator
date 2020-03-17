using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisMatch : ITennisService
    {
        private readonly ITennisServiceFactory _serviceFactory;
        private List<SetResult> _setResults;

        public TennisMatch(ITennisServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public MatchResult PlayMatch()
        {
            _setResults = new List<SetResult>();
            
            while (!HasMatchBeenWon())
            {
                PlaySet();
            }

            return new MatchResult(_setResults);
        }

        private void PlaySet()
        {
            var set = _serviceFactory.GetSetService();
            _setResults.Add(set.PlaySet());
        }

        private bool HasMatchBeenWon()
        {
            var player1Sets = _setResults.Count(x => x.Player1Win);
            var player2Sets = _setResults.Count(x => !x.Player1Win);
            return PlayerWins(player1Sets, player2Sets)
                   || PlayerWins(player2Sets, player1Sets);
        }

        private static bool PlayerWins(int scoreToCheck, int scoreToCompareAgainst)
            => (scoreToCheck - scoreToCompareAgainst > 0) && (scoreToCheck >= 2);
    }
}
