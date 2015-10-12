using System.Collections.Generic;
using System.Collections.ObjectModel;
using Labyrinth.ConsoleUI.Output;
using Labyrinth.Core.CommandFactory;
using Labyrinth.Core.CommandFactory.Contracts;
using Labyrinth.Core.Commands.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.Common.Contracts;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Helpers.Contracts;
using Labyrinth.Core.Output.Contracts;
using Labyrinth.Core.Player;
using Labyrinth.Core.Player.Contracts;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Labyrinth.Core.Score.Contracts;
using Moq;

namespace Labyrinth.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void TestScoreCommandCorrect()
        {
            IPlayFieldGenerator pg = new PlayFieldGenerator();
            IPlayField playFld = new PlayField(pg, new Position(1, 1), 3, 3);
            playFld.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            Mock<IRenderer> mockRenderer = new Mock<IRenderer>();
            IMementoCaretaker mockMemento = new MementoCaretaker(new List<IMemento>());
            Mock<IScoreLadder> mockScoreLader = new Mock<IScoreLadder>();
            IPlayer player = new Player("Test", new Cell(new Position(1, 1), Constants.StandardGamePlayerChar));

            ICommandContext cmdContext = new CommandContext(playFld, mockRenderer.Object, mockMemento, mockScoreLader.Object, player);

            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("top");

            command.Execute(cmdContext);

            mockRenderer.Verify(x => x.ShowScoreLadder(It.IsAny<IScoreLadderContentProvider>()), Times.Once);
        }

        [TestMethod]
        public void TestMoveDownCommandCorrect()
        {
            IPlayFieldGenerator pg = new PlayFieldGenerator();
            IPlayField playFld = new PlayField(pg, new Position(1, 1), 3, 3);
            playFld.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            Mock<IRenderer> mockRenderer = new Mock<IRenderer>();
            IMementoCaretaker mockMemento = new MementoCaretaker(new List<IMemento>());
            Mock<IScoreLadder> mockScoreLader = new Mock<IScoreLadder>();
            IPlayer player = new Player("Test",new Cell(new Position(1,1),Constants.StandardGamePlayerChar));

            ICommandContext cmdContext = new CommandContext(playFld, mockRenderer.Object, mockMemento, mockScoreLader.Object, player);

            ICommandFactory factory  =new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("d");

            command.Execute(cmdContext);

            Assert.AreEqual(2,player.CurentCell.Position.Row);
            Assert.AreEqual(1,player.CurentCell.Position.Column);
        }

        [TestMethod]
        public void TestMoveLeftCommandCorrect()
        {
            IPlayFieldGenerator pg = new PlayFieldGenerator();
            IPlayField playFld = new PlayField(pg, new Position(1, 1), 3, 3);
            playFld.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            Mock<IRenderer> mockRenderer = new Mock<IRenderer>();
            IMementoCaretaker mockMemento = new MementoCaretaker(new List<IMemento>());
            Mock<IScoreLadder> mockScoreLader = new Mock<IScoreLadder>();
            IPlayer player = new Player("Test", new Cell(new Position(1, 1), Constants.StandardGamePlayerChar));

            ICommandContext cmdContext = new CommandContext(playFld, mockRenderer.Object, mockMemento, mockScoreLader.Object, player);

            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("l");

            command.Execute(cmdContext);

            Assert.AreEqual(1, player.CurentCell.Position.Row);
            Assert.AreEqual(0, player.CurentCell.Position.Column);
        }

        [TestMethod]
        public void TestMoveRightCommandCorrect()
        {
            IPlayFieldGenerator pg = new PlayFieldGenerator();
            IPlayField playFld = new PlayField(pg, new Position(1, 1), 3, 3);
            playFld.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            Mock<IRenderer> mockRenderer = new Mock<IRenderer>();
            IMementoCaretaker mockMemento = new MementoCaretaker(new List<IMemento>());
            Mock<IScoreLadder> mockScoreLader = new Mock<IScoreLadder>();
            IPlayer player = new Player("Test", new Cell(new Position(1, 1), Constants.StandardGamePlayerChar));

            ICommandContext cmdContext = new CommandContext(playFld, mockRenderer.Object, mockMemento, mockScoreLader.Object, player);

            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("r");

            command.Execute(cmdContext);

            Assert.AreEqual(1, player.CurentCell.Position.Row);
            Assert.AreEqual(2, player.CurentCell.Position.Column);
        }

        [TestMethod]
        public void TestMoveUpCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("u");
            Assert.AreEqual("Move Up",command.GetName());
        }

        [TestMethod]
        public void TestMoveDownCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("d");
            Assert.AreEqual("Move Down", command.GetName());
        }

        [TestMethod]
        public void TestMoveLeftCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("l");
            Assert.AreEqual("Move Left", command.GetName());
        }

        [TestMethod]
        public void TestMoveRightCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("r");
            Assert.AreEqual("Move Right", command.GetName());
        }

        [TestMethod]
        public void TestScoreCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("top");
            Assert.AreEqual("Score", command.GetName());
        }

        [TestMethod]
        public void TestExitCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("exit");
            Assert.AreEqual("Exit", command.GetName());
        }

        [TestMethod]
        public void TestRestartCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("restart");
            Assert.AreEqual("Restart", command.GetName());
        }

        [TestMethod]
        public void TestUndoCommandGetCorrectName()
        {
            ICommandFactory factory = new SimpleCommandFactory();
            ICommand command = factory.CreateCommand("undo");
            Assert.AreEqual("Undo", command.GetName());
        }
    }

    public class PlayFieldGenerator : IPlayFieldGenerator
    {
        ICell[,] cells = new ICell[3, 3];

        public ICell[,] GeneratePlayField(Labyrinth.Common.Contracts.IRandomNumberGenerator rand)
        {
            for (int i = 0; i < this.cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.cells.GetLength(1); j++)
                {
                    this.cells[i, j] = new Cell(new Position(i, j), '-');
                }
            }
            return this.cells;
        }

        public ICell[,] ChangeCellAtPosition(IPosition position, char cellChar)
        {
            this.cells[position.Row, position.Column].ValueChar = cellChar;
            return this.cells;
        }
    }
}
