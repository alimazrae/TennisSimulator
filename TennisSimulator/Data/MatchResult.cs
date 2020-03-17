using System.Collections.Generic;
using System.Linq;

namespace TennisSimulator.Data
{
    public class MatchResult
    {
        public List<SetResult> Sets { get; }

        public MatchResult(List<SetResult> sets)
        {
            Sets = sets;
            Player1Score = sets.Count(x => x.Player1Win);
            Player2Score = sets.Count(x => !x.Player1Win);
            Player1Win = Player1Score > Player2Score;
        }

        public int Player1Score { get; }
        public bool Player1Win { get; }

        public int Player2Score { get; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}
