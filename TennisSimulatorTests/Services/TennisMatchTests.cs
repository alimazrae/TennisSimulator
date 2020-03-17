using Moq;
using NUnit.Framework;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;
using TennisSimulator.Services;

namespace TennisSimulatorTests.Services
{
    [TestFixture]
    public class TennisMatchTests
    {
        private TennisMatch sut;

        private Player player1;
        private Player player2;
        private Mock<IUserInterface> userInterface;

        [SetUp]
        public void SetUp()
        {
            userInterface = new Mock<IUserInterface>();

            player1 = new Player("Player1");
            player2 = new Player("Player2");
             
            sut = new TennisMatch(userInterface.Object, player1, player2);
        }

        [Test]
        public void PlayMatch_Should_WriteToUserInterface()
        {
            sut.PlayMatch();

            userInterface.Verify(x => x.WriteMatch(It.IsAny<Result>()), Times.Once);
        }
    }
}
