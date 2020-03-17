using Moq;
using NUnit.Framework;
using TennisSimulator.Services;

namespace TennisSimulatorTests.Services
{
    [TestFixture]
    public class TennisSetTests
    {
        private TennisSet _sut;

        private Mock<ITennisServiceFactory> _serviceFactory;
        private Mock<ITennisPointWinnerService> _tennisPointWinnerService;
        private Mock<TennisGame> _gameService;

        [SetUp]
        public void SetUp()
        {
            _tennisPointWinnerService = new Mock<ITennisPointWinnerService>();
            _serviceFactory = new Mock<ITennisServiceFactory>(_tennisPointWinnerService.Object);
            _gameService = new Mock<TennisGame>(_serviceFactory.Object);

            _sut = new TennisSet(_serviceFactory.Object);
            
            _serviceFactory.Setup(x => x.GetGameService()).Returns(_gameService.Object);
        }

        [Test]
        public void PlayMatch_Should_CallGetService()
        {
            _sut.PlaySet();

            _serviceFactory.Verify(x => x.GetGameService(), Times.AtLeastOnce);
        }
    }
}
