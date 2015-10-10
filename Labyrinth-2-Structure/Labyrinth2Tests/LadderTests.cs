using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.Score.Contracts;
using Labyrinth.Core.Score;
using System.Text;

namespace Labyrinth2Tests
{
    [TestClass]
    public class LadderTest
    {
        private ScoreLadder ladder;

        [TestInitialize]
        public void Initialize()
        {
            ladder = ScoreLadder.Instance;
        }

        [TestMethod]
        public void TestAddResultInLadderOneRecord()
        {
            var movesCount = 1;
            var playerName = "toni";

            ladder.AddResultInLadder(movesCount, playerName);

            Assert.AreEqual(1, ladder.CurrentCount());
        }

        [TestMethod]
        public void TestAddResultInLadderTwoRecords()
        {
            ladder.RestartLadder();
            ladder = ScoreLadder.Instance;
            var movesCount = 1;
            var playerName = "toni";

            ladder.AddResultInLadder(movesCount, playerName);
            ladder.AddResultInLadder(movesCount, playerName);

            Assert.AreEqual(2, ladder.CurrentCount());
        }


        [TestMethod]
        public void TestAddResultInLadderMoreThanCapacity()
        {
            var movesCount = 1;
            var playerName = "toni";
            var capacity = ladder.Capacity;
            var maxCount = capacity;

            for (int i = 0; i < capacity + 1; i++)
            {
                ladder.AddResultInLadder(movesCount, playerName);
            }

            Assert.AreEqual(maxCount, ladder.CurrentCount());
        }

        [TestMethod]
        public void TestResultQualifiesInLadderCountLessThanCapacity()
        {
            var playerName = "toni";
            var capacity = ladder.Capacity;

            for (int i = 1; i <= ladder.Capacity - 1; i++)
            {
                ladder.AddResultInLadder(i, playerName + i);
            }

            var resultQualifiesInLadder = ladder.ResultQualifiesInLadder(1);
            Assert.IsTrue(resultQualifiesInLadder);
        }

        [TestMethod]
        public void TestResultQualifiesInLadderArgumentResultLessThanMovesCountOfLastItemInList()
        {
            var playerName = "toni";
            var capacity = ladder.Capacity;
            var count = 0;

            for (count = 1; count <= ladder.Capacity; count++)
            {
                ladder.AddResultInLadder(count, playerName + count);
            }

            count--;

            var resultQualifiesInLadder = ladder.ResultQualifiesInLadder(count - 1);
            Assert.IsTrue(resultQualifiesInLadder);
        }

        [TestMethod]
        public void TestResultQualifiesInLadderAssertFalse()
        {
            var playerName = "toni";
            var capacity = ladder.Capacity;
            var count = 0;

            for (count = 1; count <= ladder.Capacity; count++)
            {
                ladder.AddResultInLadder(count, playerName + count);
            }
            count--;
            var resultQualifiesInLadder = ladder.ResultQualifiesInLadder(count);
            Assert.IsFalse(resultQualifiesInLadder);
        }

        //This method is similar to PrintLadder, but instead of writing to console, it returns result.
        [TestMethod]
        public void TestReturnLadderNotEmptyList()
        {
            ladder.RestartLadder();
            ladder = ScoreLadder.Instance;
            var playerName = "toni";
            StringBuilder expectedResult = new StringBuilder();

            for (int i = 1; i <= 2; i++)
            {
                ladder.AddResultInLadder(i, playerName);
            }

            var result = ladder.ProvideContent();
            expectedResult.AppendLine("1. toni --> 1 moves");
            expectedResult.AppendLine("2. toni --> 2 moves");

            Assert.AreEqual(expectedResult.ToString(), result);

        }

    }
}
