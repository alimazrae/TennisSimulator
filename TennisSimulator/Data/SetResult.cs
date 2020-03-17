using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TennisSimulator.Data
{
    public class SetResult
    {
        public SetResult(List<GameResult> games)
        {
            Games = games;
            Player1Score = games.Count(x => x.Player1Win);
            Player2Score = games.Count(x => !x.Player1Win);
            Player1Win = Player1Score > Player2Score;
        }

        public List<GameResult> Games { get; }

        public int Player1Score { get; }
        public bool Player1Win { get; }

        public int Player2Score { get; }
    }
}
