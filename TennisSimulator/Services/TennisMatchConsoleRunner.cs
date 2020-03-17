using TennisSimulator.Data;
using TennisSimulator.Infrastructure;

namespace TennisSimulator.Services
{
    public class TennisMatchConsoleRunner : ITennisMatchRunner
    {
        private readonly ITennisServiceFactory _serviceProvider;
        private readonly IUserInterface _userInterface;

        public TennisMatchConsoleRunner(ITennisServiceFactory serviceProvider, IUserInterface userInterface)
        {
            _serviceProvider = serviceProvider;
            _userInterface = userInterface;
        }

        public void RunMatch(Player player1, Player player2)
        {
            var matchService = _serviceProvider.GetMatchService();
            var matchResult = matchService.PlayMatch();
            matchResult.Player1 = player1;
            matchResult.Player2 = player2;
            _userInterface.WriteMatch(matchResult);
            _userInterface.WaitForUserInput();
        }
    }
}
