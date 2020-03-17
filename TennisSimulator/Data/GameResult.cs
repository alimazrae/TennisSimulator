namespace TennisSimulator.Data
{
    public class GameResult
    {
        public GameResult(int player1Score, int player2Score)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
            Player1Win = Player1Score > Player2Score;
        }

        public int Player1Score { get; }
        public bool Player1Win { get; }

        public int Player2Score { get; }
    }
}
