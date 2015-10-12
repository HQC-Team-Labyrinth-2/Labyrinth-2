using System;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Player;
using Labyrinth.Core.Player.Contracts;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestPlayerWithCorrectNameAndCell()
        {
            IPlayer player = new Player("Test",new Cell(new Position(1,3)));        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerWithNullNameShouldThrow()
        {
            IPlayer player = new Player(null,new Cell(new Position(1,3)));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestPlayerWithEmptyStringNameShouldThrow()
        {
            IPlayer player = new Player("",new Cell(new Position(1,3)));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TestPlayerWithNullCellShouldThrow()
        {
            IPlayer player = new Player("Test1",null);
        }

        [TestMethod]
        public void TestPlayerNameGetterShouldReturnCorrectName()
        {
            IPlayer player = new Player("Test",new Cell(new Position(1,4)));
            string expected = "Test";
            Assert.AreEqual(player.Name,expected);
        }

        [TestMethod]
        public void TestPlayerCurrentCellGetterShouldReturnCorrectCell()
        {
            ICell cell = new Cell(new Position(1,3));
            IPlayer player = new Player("Test", cell);
            ICell actualCell = player.CurentCell;
            Assert.AreSame(cell,actualCell);
        }

    }
}
