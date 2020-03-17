using Moq;
using NUnit.Framework;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;
using TennisSimulator.Services;

namespace TennisSimulatorTests.Services
{
    [TestFixture]
    public class TennisGameTests
    {
        private TennisGame sut;

        private Player player1;
        private Player player2;
        private Mock<IUserInterface> userInterface;
        private Mock<ITennisPointWinnerService> pointWinnerService;

        [SetUp]
        public void SetUp()
        {
            userInterface = new Mock<IUserInterface>();
            pointWinnerService = new Mock<ITennisPointWinnerService>();

            player1 = new Player("Player1");
            player2 = new Player("Player2");
             
            sut = new TennisGame(userInterface.Object, pointWinnerService.Object, player1, player2);
            pointWinnerService.Setup(x => x.DecideWinner(It.IsAny<Player>(), It.IsAny<Player>())).Returns(player1);
        }

        [Test]
        public void PlayGame_Should_CallPointWinnerService()
        {
            sut.PlayGame();

            pointWinnerService.Verify(x => x.DecideWinner(player1, player2), Times.AtLeastOnce);
        }

        [Test]
        public void PlayGame_Should_WriteToUserInterface()
        {
            sut.PlayGame();

            userInterface.Verify(x => x.WriteGame(It.IsAny<Result>()), Times.Once);
        }

        [TestCase(4, 0, "Player1")]
        [TestCase(3, 4, "Player2")]
        [TestCase(4, 4, "Player2")]
        public void PlayGame_Should_CorrectlyCalculateWinner(int player1Points, int player2Points, string expectedWinner)
        {
            for (int i = 0; i < player1Points; i++)
            {
                player1.CurrentScore.ScorePoint();
            }
            for (int i = 0; i < player2Points; i++)
            {
                player2.CurrentScore.ScorePoint();
            }

            pointWinnerService.Setup(x => x.DecideWinner(It.IsAny<Player>(), It.IsAny<Player>())).Returns(player2);

            var result = sut.PlayGame();

            Assert.AreEqual(result.Winner.Name, expectedWinner);
        }
    }
}
