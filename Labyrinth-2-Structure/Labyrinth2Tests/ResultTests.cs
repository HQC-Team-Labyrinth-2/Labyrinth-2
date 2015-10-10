using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.Score;

namespace Labyrinth2Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void TestResultCorrectState()
        {
            Result result = new Result(4, "Goran");
            Assert.AreEqual(4, result.MovesCount, "Result constructor failed to set correct state for 'MovesCount'!");
            Assert.AreEqual("Goran", result.PlayerName, "Result constructor failed to set correct state for 'PlayerName'!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResultNegativResultShouldThrow()
        {
            Result result = new Result(-4, "Goran");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResultEmptyStringPlayerNameShouldThrow()
        {
            Result result = new Result(5, "");
        }

        [TestMethod]
        public void TestCompareToEqualResults()
        {
            Result result1 = new Result(5, "Goran");
            Result result2 = new Result(5, "Alex");
            int actual = result1.CompareTo(result2);
            Assert.AreEqual(0, actual, "Compare equal results failed!");
        }

        [TestMethod]
        public void TestCompareToThisGreaterThanArgument()
        {
            Result result1 = new Result(5, "Goran");
            Result result2 = new Result(4, "Alex");
            int actual = result1.CompareTo(result2);
            Assert.AreEqual(1, actual, "Compare first result greater than second should return 1!");
        }

        [TestMethod]
        public void TestCompareToArgumentGreaterThanThis()
        {
            Result result1 = new Result(2, "Goran");
            Result result2 = new Result(4, "Alex");
            int actual = result1.CompareTo(result2);
            Assert.AreEqual(-1, actual, "Compare second result greater than first should return -1!");
        }
    }
}
