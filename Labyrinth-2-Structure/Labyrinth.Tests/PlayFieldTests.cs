namespace Labyrinth.Tests
{
    using System;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.CustomExceptions;
    using Labyrinth.Core.Player;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.PlayField;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Helpers;

    [TestClass]
    public class PlayFieldTests
    {
        [TestMethod]
        public void TestPlayFieldWithCorrectData()
        {
            var position = new Position(0, 2);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            PlayField field = new PlayField(generator, position, 4, 4);
            field.InitializePlayFieldCells(RandomNumberGenerator.Instance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPlayFieldWithIncorrectData()
        {
            var position = new Position(55, 55);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            PlayField field = new PlayField(generator, position, 4, 4);
            field.InitializePlayFieldCells(RandomNumberGenerator.Instance);
        }

        [TestMethod]
        public void CheskPlayFieldRowsGetter()
        {
            var position = new Position(0, 2);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            int row = 4;
            int col = 5;
            PlayField field = new PlayField(generator, position, row, col);
            Assert.AreEqual(row, field.NumberOfRows);
        }

        [TestMethod]
        public void CheskPlayFieldCollsGetter()
        {
            var position = new Position(0, 2);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            int row = 4;
            int col = 5;
            PlayField field = new PlayField(generator, position, row, col);
            Assert.AreEqual(col, field.NumberOfCols);
        }

        [TestMethod]
        public void TestAddPlayerOnCorrectPosition()
        {
            IPlayField playField = new PlayField(new PlayFldGen(new Position(1, 1)), new Position(1, 1));
            playField.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            ICell cell = playField.GetCell(new Position(1, 1));
            Assert.AreEqual(cell.ValueChar, Constants.StandardGamePlayerChar);
        }

        [TestMethod]
        public void TestMovePlayerOnCorrectPosition()
        {

            IPlayField playField = new PlayField(new PlayFldGen(new Position(1, 1)), new Position(1, 1));
            playField.InitializePlayFieldCells(RandomNumberGenerator.Instance);
            IPlayer player = new Player("Test", playField.GetCell(new Position(1, 1)));
            playField.RemovePlayer(player);
            playField.AddPlayer(player, new Position(1,2));

            Assert.AreEqual(player.CurentCell.Position.Row,playField.PlayerPosition.Row);
            Assert.AreEqual(player.CurentCell.Position.Column, playField.PlayerPosition.Column);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerPositionException))]
        public void TestMovePlayerOnIncorrectPositionShouldThrow()
        {
            PlayFldGen generator = new PlayFldGen(new Position(1, 1));
              
            IPlayField playField = new PlayField(generator, new Position(1, 1));
            playField.InitializePlayFieldCells(RandomNumberGenerator.Instance);

            generator.ChangeCellAtPosition(new Position(1, 2), Constants.StandardGameCellWallValue);

            IPlayer player = new Player("Test", playField.GetCell(new Position(1, 1)));
            playField.RemovePlayer(player);
            playField.AddPlayer(player, new Position(1, 2));
        }
    }

    public class PlayFldGen : IPlayFieldGenerator
    {
        ICell[,] cells = new ICell[3, 3];
        private IPosition playerPosition;

        public PlayFldGen(IPosition player)
        {
            this.playerPosition = player;
        }
        public ICell[,] GeneratePlayField(Labyrinth.Common.Contracts.IRandomNumberGenerator rand)
        {
            for (int i = 0; i < this.cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.cells.GetLength(1); j++)
                {
                    this.cells[i, j] = new Cell(new Position(i, j), Constants.StandardGameCellEmptyValue);
                }
            }

            this.cells[this.playerPosition.Row, this.playerPosition.Column].ValueChar = Constants.StandardGamePlayerChar;
            return this.cells;
        }

        public ICell[,] ChangeCellAtPosition(IPosition position, char cellChar)
        {
            this.cells[position.Row, position.Column].ValueChar = cellChar;
            return this.cells;
        }
    }

}
