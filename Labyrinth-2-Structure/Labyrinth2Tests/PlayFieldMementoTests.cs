using System;
using Labyrinth.Core.Common;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth2Tests
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
    }
}
