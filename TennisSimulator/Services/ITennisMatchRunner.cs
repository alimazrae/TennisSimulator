using TennisSimulator.Data;

namespace TennisSimulator.Services
{
    public interface ITennisMatchRunner
    {
        void RunMatch(Player player1, Player player2);
    }
}
