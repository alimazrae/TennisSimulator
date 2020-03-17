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

        private Mock<ITennisPointWinnerService> pointWinnerService;

        [SetUp]
        public void SetUp()
        {
            pointWinnerService = new Mock<ITennisPointWinnerService>();
             
            sut = new TennisGame(pointWinnerService.Object);
        }

        [Test]
        public void PlayGame_Should_CallPointWinnerService()
        {
            sut.PlayGame();

            pointWinnerService.Verify(x => x.DecideIfPlayer1Winner(), Times.AtLeastOnce);
        }


        [Test]
        public void PlayGame_Should_FinishAfter4Points()
        {
            pointWinnerService.Setup(x => x.DecideIfPlayer1Winner()).Returns(true);

            var result = sut.PlayGame();

            Assert.True(result.Player1Win);
            pointWinnerService.Verify(x => x.DecideIfPlayer1Winner(), Times.Exactly(4));
        }

        [Test]
        public void PlayGame_Should_EnsureWinIs2Ahead()
        {
            pointWinnerService.SetupSequence(x => x.DecideIfPlayer1Winner())
                .Returns(true)
                .Returns(true)
                .Returns(true)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(false);

            var result = sut.PlayGame();

            Assert.False(result.Player1Win);
            pointWinnerService.Verify(x => x.DecideIfPlayer1Winner(), Times.Exactly(8));
        }
    }
}
