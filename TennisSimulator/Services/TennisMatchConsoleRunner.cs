using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisMatchConsoleRunner : ITennisMatchRunner
    {
        private readonly ITennisMatch _matchFactory;
        private readonly IUserInterface _userInterface;

        public TennisMatchConsoleRunner(ITennisMatch matchFactory, IUserInterface userInterface)
        {
            _matchFactory = matchFactory;
            _userInterface = userInterface;
        }

        public void RunMatch(Player player1, Player player2)
        {
            var matchResult = _matchFactory.PlayMatch();
            matchResult.Player1 = player1;
            matchResult.Player2 = player2;
            _userInterface.WriteMatch(matchResult);
            _userInterface.WaitForUserInput();
        }
    }
}
