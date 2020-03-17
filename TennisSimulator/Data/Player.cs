namespace TennisSimulator.Data
{
    public class Player
    {
        public string Name { get; }

        //public List<MatchResults> MatchResults
        
        public PlayerScore CurrentScore { get; }

        public Player(string name)
        {
            Name = name;
            CurrentScore = new PlayerScore();
        }
    }
}
