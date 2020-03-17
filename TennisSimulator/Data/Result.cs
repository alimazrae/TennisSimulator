namespace TennisSimulator.Data
{
    public class Result
    {
        public Result(Player winner, Player loser)
        {
            Winner = winner;
            Loser = loser;
        }

        public Player Winner { get; }
        public Player Loser { get; }
    }
}
