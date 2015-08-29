using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Labyrinth;

namespace Labyrinth_temp2_Tests
{
    [TestClass]
   public class CellTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeNumberForRow()
        {
            Cell cell = new Cell();
            cell.Row = -1;

        }

        [TestMethod]
        public void TestValidValueForRow()
        {
            Cell cell = new Cell();
            cell.Row = 5;
            Assert.AreEqual(cell.Row, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMaxNumberRowsOfLabyrinth()
        {
            Cell cell= new Cell();
            cell.Row = int.MaxValue;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeNumberForCol()
        {
            Cell cell = new Cell();
            cell.Col = -1;

        }

        [TestMethod]
        public void TestValidValueForCol()
        {
            Cell cell = new Cell();
            cell.Col = 5;
            Assert.AreEqual(cell.Col, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMaxNumberColsOfLabyrinth()
        {
            Cell cell = new Cell();
            cell.Col = int.MaxValue;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidCharInCell()
        {
            Cell cell = new Cell();
            cell.ValueChar = '0';
        }

        [TestMethod]
        public void TestValidCharInCell()
        {
            Cell cell = new Cell();
            cell.ValueChar = 'X';
            cell.ValueChar = '-';
        }

         [TestMethod]
        public void TestCheckCellIsEmptyWhenIsEmpty()
        {
            Cell cell = new Cell();
            cell.ValueChar = '-';
            Assert.IsTrue(cell.IsEmpty());
        }

         [TestMethod]
         public void TestCheckCellIsEmptyWhenIsNotEmpty()
         {
             Cell cell = new Cell();
             cell.ValueChar = 'X';
             Assert.IsFalse(cell.IsEmpty());
         }
    }
}
