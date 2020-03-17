using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TennisSimulator.Data;

namespace TennisSimulatorTests.Data
{
    [TestFixture]
    public class PlayerScoreTests
    {
        private PlayerScore sut;
        [SetUp]
        public void SetUp()
        {
            sut = new PlayerScore();
        }

        [Test]
        public void ScorePoint_Should_IncrementPointCounter()
        {
            Assert.AreEqual(sut.Points, 0);
            sut.ScorePoint();
            Assert.AreEqual(sut.Points, 1);
        }

        [Test]
        public void ScoreGame_Should_IncrementGameCounter_And_ResetPoints()
        {
            sut.ScorePoint();
            Assert.AreEqual(sut.Points, 1);
            Assert.AreEqual(sut.Games, 0);
            sut.ScoreGame();
            Assert.AreEqual(sut.Games, 1);
            Assert.AreEqual(sut.Points, 0);
        }

        [Test]
        public void ScoreSet_Should_IncrementSetCounter_And_ResetPointsAndGames()
        {
            sut.ScoreGame();
            sut.ScorePoint();
            Assert.AreEqual(sut.Points, 1);
            Assert.AreEqual(sut.Games, 1);
            Assert.AreEqual(sut.Sets, 0);
            sut.ScoreSet();
            Assert.AreEqual(sut.Sets, 1);
            Assert.AreEqual(sut.Games, 0);
            Assert.AreEqual(sut.Points, 0);
        }

        //Further tests for reset methods 
    }
}
