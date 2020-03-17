using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisMatch : ITennisMatch
    {
        private readonly IUserInterface _userInterface;

        private List<SetResult> _setResults;

        public TennisMatch(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public MatchResult PlayMatch()
        {
            _setResults = new List<SetResult>();

            _userInterface.Clear();

            while (!HasMatchBeenWon())
            {
                PlaySet();
            }

            return new MatchResult(_setResults);
        }

        private void PlaySet()
        {
            var set = new TennisSet(_userInterface);
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
