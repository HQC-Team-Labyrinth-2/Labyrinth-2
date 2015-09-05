using System;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth;
namespace Labyrinth_temp2_Tests
{
    [TestClass]
    public class LadderTest
    {
        private Ladder ladder;

        [TestInitialize]
        public void Initialize()
        {
            ladder = new Ladder();
        }

        [TestMethod]
        public void TestAddResultInLadderOneRecord()
        {
            var movesCount = 1;
            var playerName = "toni";

            ladder.AddResultInLadder(movesCount, playerName);

            Assert.AreEqual(1, ladder._TopResults().Count);
        }

        [TestMethod]
        public void TestAddResultInLadderTwoRecords()
        {
            var movesCount = 1;
            var playerName = "toni";

            ladder.AddResultInLadder(movesCount, playerName);
            ladder.AddResultInLadder(movesCount, playerName);

            Assert.AreEqual(2, ladder._TopResults().Count);
        }


        [TestMethod]
        public void TestAddResultInLadderMoreThanCapacity()
        {
            var movesCount = 1;
            var playerName = "toni";
            var capacity = ladder.GetTopResultsCapacity();
            var maxCount = capacity;

            for (int i = 0; i < capacity + 1; i++)
            {
                ladder.AddResultInLadder(movesCount, playerName);
            }

            Assert.AreEqual(maxCount, ladder._TopResults().Count);
        }

        [TestMethod]
        public void TestAddResultInLadderRecordsWhenCountIsEqualToCapacity()
        {
            var movesCount = 1;
            var playerName = "toni";
            var capacity = ladder.GetTopResultsCapacity();

            for (int i = 0; i < capacity -1; i++)
            {
                ladder.AddResultInLadder(movesCount, playerName);
            }

            var testMovesCount = 2;
            var testPlayerName = "test";

            ladder.AddResultInLadder(testMovesCount, testPlayerName);

            var topResultCount = ladder._TopResults().Count;
            var lastELement = ladder._TopResults()[topResultCount-1];

            Assert.AreEqual(testMovesCount, lastELement.MovesCount);
            Assert.AreEqual(testPlayerName, lastELement.PlayerName);
        }

        [TestMethod]
        public void TestSortResults()
        {
            var playerName = "toni";
            var capacity = ladder.GetTopResultsCapacity();

            for (int i = capacity-1; i >= 0; i--)
            {
                ladder.AddResultInLadder(i, playerName+i);
            }

            ladder.SortResults();

            var firstElement = ladder._TopResults()[0];

            Assert.AreEqual(0, firstElement.MovesCount);
            Assert.AreEqual("toni0", firstElement.PlayerName);
        }

        [TestMethod]
        public void TestResultQualifiesInLadderCountLessThanCapacity()
        {
            var playerName = "toni";
            var capacity = ladder.GetTopResultsCapacity();

            for (int i = 0; i < ladder.GetTopResultsCapacity() - 1; i++)
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
            var capacity = ladder.GetTopResultsCapacity();
            var count = 0;

            for (count = 0; count < ladder.GetTopResultsCapacity(); count++)
            {
                ladder.AddResultInLadder(count, playerName + count);
            }

            count--;

            var resultQualifiesInLadder = ladder.ResultQualifiesInLadder(count-1);
            Assert.IsTrue(resultQualifiesInLadder);
        }

        [TestMethod]
        public void TestResultQualifiesInLadderAssertFalse()
        {
            var playerName = "toni";
            var capacity = ladder.GetTopResultsCapacity();
            var count = 0;

            for (count = 0; count < ladder.GetTopResultsCapacity(); count++)
            {
                ladder.AddResultInLadder(count, playerName + count);
            }
            count--;
            var resultQualifiesInLadder = ladder.ResultQualifiesInLadder(count);
            Assert.IsFalse(resultQualifiesInLadder);
        }

        //This method is similar to PrintLadder, but instead of writing to console, it returns result.
        [TestMethod]
        public void TestReturnLadderCountEqualToZero()
        {
            var expectedResult = UserInputAndOutput.SCOREBOARD_EMPTY_MSG;
            Assert.AreEqual(expectedResult, ladder.ReturnLadder());
        }

        //This method is similar to PrintLadder, but instead of writing to console, it returns result.
        [TestMethod]
        public void TestReturnLadderNotEmptyList()
        {
            var playerName = "toni";
            StringBuilder expectedResult = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                ladder.AddResultInLadder(i, playerName);
            }

            var result = ladder.ReturnLadder();
            expectedResult.AppendLine("1. toni --> 0 moves");
            expectedResult.AppendLine("2. toni --> 1 moves");

            Assert.AreEqual(expectedResult.ToString(), result);

        }

    }
}
