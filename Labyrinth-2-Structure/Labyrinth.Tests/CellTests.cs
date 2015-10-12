using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Common;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeNumberForRow()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.Position.Row = -1;
        }

        [TestMethod]
        public void TestValidValueForRow()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.Position.Row = 5;
            Assert.AreEqual(cell.Position.Row, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeNumberForCol()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.Position.Column = -1;
        }

        [TestMethod]
        public void TestValidValueForCol()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.Position.Column = 5;
            Assert.AreEqual(cell.Position.Column, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidCharInCell()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.ValueChar = '0';
        }

        [TestMethod]
        public void TestValidCharInCell()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.ValueChar = Constants.StandardGameCellEmptyValue;
            cell.ValueChar = Constants.StandardGameCellWallValue;
        }

        [TestMethod]
        public void TestCheckCellIsEmptyWhenIsEmpty()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.ValueChar = Constants.StandardGameCellEmptyValue;
            Assert.IsTrue(cell.IsEmpty());
        }

        [TestMethod]
        public void TestCheckCellIsEmptyWhenIsNotEmpty()
        {
            Cell cell = new Cell(new Position(1, 1));
            cell.ValueChar = Constants.StandardGameCellWallValue;
            Assert.IsFalse(cell.IsEmpty());
        }

        [TestMethod]
        public void TestCloneShouldReturDifferentReference()
        {
            Cell cell1 = new Cell(new Position(1,1));
            ICell cell2 = cell1.Clone();
            Assert.AreNotSame(cell1,cell2);
        }

        [TestMethod]
        public void TestCloneShouldReturCellWithDifferentPositionReference()
        {
            Cell cell1 = new Cell(new Position(1, 1));
            ICell cell2 = cell1.Clone();
            Assert.AreNotSame(cell1.Position, cell2.Position);
        }

        [TestMethod]
        public void TestCloneShouldReturnCellWithSameCharValue()
        {
            Cell cell1 = new Cell(new Position(1, 1));
            ICell cell2 = cell1.Clone();
            Assert.AreEqual(cell1.ValueChar, cell2.ValueChar);
        }

        [TestMethod]
        public void TestCloneShouldReturnCellWithSamePositionValues()
        {
            Cell cell1 = new Cell(new Position(1, 1));
            ICell cell2 = cell1.Clone();
            Assert.AreEqual(cell1.Position.Column, cell2.Position.Column);
            Assert.AreEqual(cell1.Position.Row,cell2.Position.Row);
        }
    }
}
