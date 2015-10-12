using System;
using Labyrinth.Core.Common;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Tests
{
    [TestClass]
    public class PlayFieldMementoTests
    {
        [TestMethod]
        public void TestPlayFieldProperyMustReturnCopyOfPlayfield()
        {
            var playField = new Cell[9, 9];
            var position = new Position(3, 3);
            var playFieldMemento = new PlayFieldMemento(playField, position);
            Assert.AreNotEqual(playFieldMemento, playFieldMemento.PlayField);
        }
		
	  [TestMethod]
      public void TestMemmentoWithCorrectData()
      {
          var position = new Position(0,1);       
          var cell = new Cell[2,2];
          var mementoField = new PlayFieldMemento(cell, position);
      }

      [TestMethod]

      public void TestMementoPlayFieldRowSize()
      {
          var position = new Position(0, 1);
          var cell = new Cell[2, 2];
          var mementoField = new PlayFieldMemento(cell, position);
          Assert.AreEqual(cell.GetLength(0),mementoField.PlayField.GetLength(0));
      }

      [TestMethod]
      public void TestMementoPlayFieldColSize()
      {
          var position = new Position(0, 1);
          var cell = new Cell[2, 2];
          var mementoField = new PlayFieldMemento(cell, position);
          Assert.AreEqual(cell.GetLength(1), mementoField.PlayField.GetLength(1));
      }
		
		
    }
}
