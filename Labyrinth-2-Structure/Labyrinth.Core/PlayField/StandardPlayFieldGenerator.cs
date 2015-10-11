namespace Labyrinth.Core.PlayField
{
    using System.Collections.Generic;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class StandardPlayFieldGenerator : IPlayFieldGenerator
    {
        private ICell[,] playField;
        private int rows;
        private int cols;
        private IPosition playerPosition;

        public StandardPlayFieldGenerator(IPosition playerPosition, int rows = Constants.StandardGameLabyrinthRows, int cols = Constants.StandardGameLabyrinthCols)
        {
            this.playField = new ICell[rows, cols];
            this.playerPosition = playerPosition;
            this.rows = rows;
            this.cols = cols;
        }

        public ICell[,] GeneratePlayField(IRandomNumberGenerator rand)
        {
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    int cellRandomValue = rand.GenerateNext(0, 1);

                    char charValue;
                    if (cellRandomValue == 0)
                    {
                        charValue = Constants.StandardGameCellEmptyValue;
                    }
                    else
                    {
                        charValue = Constants.StandardGameCellWallValue;
                    }

                    this.playField[row, col] = new Cell(new Position(row, col), charValue);
                }
            }

            this.playField[this.playerPosition.Row, this.playerPosition.Column].ValueChar = Constants.StandardGamePlayerChar;

            bool exitPathExists = this.ExitPathExists();
            if (!exitPathExists)
            {
                return this.GeneratePlayField(rand);
            }
            else
            {
                return this.playField;
            }
        }

        private bool ExitPathExists()
        {
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
