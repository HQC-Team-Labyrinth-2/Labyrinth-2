using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Labyrinth.Core.Common;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Helpers.Contracts;
using Labyrinth.Core.Helpers.CustomExceptions;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StandardPlayFieldGeneratorTests
    {
        [TestMethod]
        public void TestGeneratePlayField3X3ExitPathShouldExistFromTheCenter()
        {
            IPlayFieldGenerator generator = new StandardPlayFieldGenerator(new Position(1, 1), 3, 3);
            bool pathFound = true;
            ExitFounder pathFounder = new ExitFounder(new Position(1, 1), 3, 3);

            for (var i = 0; i < 10000; i++)
            {
                ICell[,] k = generator.GeneratePlayField(RandomNumberGenerator.Instance);
                if (!pathFounder.CheckForExit(k))
                {
                    pathFound = false;
                }
            }

            Assert.IsTrue(pathFound);
        }

        [TestMethod]
        public void TestGeneratePlayField5X5ExitPathShouldExistFromTheCenter()
        {
            IPlayFieldGenerator generator = new StandardPlayFieldGenerator(new Position(2,2),5,5);
            bool pathFound = true;
            ExitFounder pathFounder = new ExitFounder(new Position(2,2),5,5 );

            for (var i = 0; i < 7000; i++)
            {
                ICell[,] k = generator.GeneratePlayField(RandomNumberGenerator.Instance);
                if (!pathFounder.CheckForExit(k))
                {
                    pathFound = false;
                }
            }

            Assert.IsTrue(pathFound);
        }

        [TestMethod]
        public void TestGeneratePlayField10X10ExitPathShouldExistFromTheCenter()
        {
            IPlayFieldGenerator generator = new StandardPlayFieldGenerator(new Position(4, 4), 10, 10);
            bool pathFound = true;
            ExitFounder pathFounder = new ExitFounder(new Position(4, 4), 10, 10);

            for (var i = 0; i < 5000; i++)
            {
                ICell[,] k = generator.GeneratePlayField(RandomNumberGenerator.Instance);
                if (!pathFounder.CheckForExit(k))
                {
                    pathFound = false;
                }
            }

            Assert.IsTrue(pathFound);
        }

        [TestMethod]
        public void TestGeneratePlayField15X15ExitPathShouldExistFromTheCenter()
        {
            IPlayFieldGenerator generator = new StandardPlayFieldGenerator(new Position(7, 7), 15, 15);
            bool pathFound = true;
            ExitFounder pathFounder = new ExitFounder(new Position(7, 7), 15, 15);

            for (var i = 0; i < 3000; i++)
            {
                ICell[,] k = generator.GeneratePlayField(RandomNumberGenerator.Instance);
                if (!pathFounder.CheckForExit(k))
                {
                    pathFound = false;
                }
            }

            Assert.IsTrue(pathFound);
        }
    }

    public class ExitFounder
    {
        private ICell[,] playField;
        private IPosition playerPosition;
        private int rows;
        private int cols;

        public ExitFounder(IPosition playerPosition,int rows, int cols)
        {
            this.playerPosition = playerPosition;
            this.rows = rows;
            this.cols = cols;
        }

        public bool CheckForExit(ICell[,] playField)
        {
            this.playField = playField;
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = this.playField[this.playerPosition.Row, this.playerPosition.Column];
            cellsOrder.Enqueue(startCell);
            HashSet<ICell> visitedCells = new HashSet<ICell>();

            bool pathExists = false;
            while (cellsOrder.Count > 0)
            {
                ICell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);

                if (this.ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                this.Move(currentCell, Direction.Down, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Up, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Left, cellsOrder, visitedCells);
                this.Move(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return pathExists;
        }

        private bool ExitFound(ICell cell)
        {
            bool exitFound = false;
            if (cell.Position.Row == this.rows - 1 ||
                cell.Position.Column == this.cols - 1 ||
                cell.Position.Row == 0 ||
                cell.Position.Column == 0)
            {
                exitFound = true;
            }

            return exitFound;
        }

        private void Move(
           ICell cell,
           Direction direction,
           Queue<ICell> cellsOrder,
           HashSet<ICell> visitedCells)
        {
            int newRow;
            int newCol;
            this.FindNewCellCoordinates(
                cell.Position.Row,
                cell.Position.Column,
                direction,
                out newRow,
                out newCol);

            if (newRow < 0 ||
                newCol < 0 ||
                newRow >= this.playField.GetLength(0) ||
                newCol >= this.playField.GetLength(1) ||
                visitedCells.Contains(this.playField[newRow, newCol]))
            {
                return;
            }

            if (this.playField[newRow, newCol].IsEmpty())
            {
                cellsOrder.Enqueue(this.playField[newRow, newCol]);
            }
        }

        private void FindNewCellCoordinates(
        int row,
        int col,
        Direction direction,
        out int newRow,
        out int newCol)
        {
            newRow = row;
            newCol = col;

            if (direction == Direction.Up)
            {
                newRow = newRow - 1;
            }
            else if (direction == Direction.Down)
            {
                newRow = newRow + 1;
            }
            else if (direction == Direction.Left)
            {
                newCol = newCol - 1;
            }
            else if (direction == Direction.Right)
            {
                newCol = newCol + 1;
            }
        }
    }




}
