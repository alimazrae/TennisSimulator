using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using TennisSimulator.Data;
using TennisSimulator.Infrastructure;
using TennisSimulator.Services;

namespace TennisSimulatorTests.Services
{
    [TestFixture]
    public class TennisMatchConsoleRunnerTests
    {
        TennisMatchConsoleRunner _sut;
        Mock<IUserInterface> _userInterface;
        Mock<ITennisServiceFactory> _serviceFactory;
        Mock<TennisMatch> _tennisMatch;

        [SetUp]
        public void SetUp()
        {
            _serviceFactory = new Mock<ITennisServiceFactory>();
            _userInterface = new Mock<IUserInterface>();
            _tennisMatch = new Mock<TennisMatch>();
            _sut = new TennisMatchConsoleRunner(_serviceFactory.Object, _userInterface.Object); 

            //unfinished setup for tests
        }

        [Test]
        public void RunMatch_Should_GetMatchService()
        {
            _sut.RunMatch(new Player("test"), new Player("test"));

            _serviceFactory.Verify(x => x.GetMatchService(), Times.Once);
        }

        [Test]
        public void RunMatch_Should_CallPlayMatch()
        {
            _sut.RunMatch(new Player("test"), new Player("test"));

            _tennisMatch.Verify(x => x.PlayMatch(), Times.Once);
        }
    }
}
