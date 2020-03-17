namespace TennisSimulator.Data
{
    public class PlayerScore
    {
        public int Sets { get; private set; }
        public int Games { get; private set; }
        public int Points { get; private set; }

        public void ResetPoints()
        {
            Points = 0;
        }

        public void ResetGames()
        {
            Games = 0;
            ResetPoints();
        }

        public void ResetSets()
        {
            Sets = 0;
            ResetGames();
        }

        public void ScoreSet()
        {
            Sets += 1;
            ResetGames();
        }

        public void ScoreGame()
        {
           Games += 1;
           ResetPoints();
        }

        public void ScorePoint()
        {
            Points += 1;
        }
    }
}
