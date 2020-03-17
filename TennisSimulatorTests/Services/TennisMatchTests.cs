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
        private TennisMatch _sut;
 
        private Mock<ITennisServiceFactory> _serviceFactory;
        private Mock<TennisSet> _setService;


        [SetUp]
        public void SetUp()
        {
            _serviceFactory = new Mock<ITennisServiceFactory>();
            _setService = new Mock<TennisSet>(_serviceFactory.Object);

            _sut = new TennisMatch(_serviceFactory.Object);

            _serviceFactory.Setup(x => x.GetSetService()).Returns(_setService.Object);
        }

        [Test]
        public void PlayMatch_Should_CallGetService()
        {
            _sut.PlayMatch();

            _serviceFactory.Verify(x => x.GetSetService(), Times.AtLeastOnce);
        }
    }
}
