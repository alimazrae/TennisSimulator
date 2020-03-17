using TennisSimulator.Data;

namespace TennisSimulator.Services
{
    public interface ITennisPointWinnerService
    {
        Player DecideWinner(Player player1, Player player2);
    }
}
