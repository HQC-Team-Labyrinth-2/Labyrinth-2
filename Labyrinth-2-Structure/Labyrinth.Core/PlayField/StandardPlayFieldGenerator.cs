namespace Labyrinth.Core.PlayField
{
    using System.Collections.Generic;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;

    public class StandardPlayFieldGenerator : IPlayFieldGenerator
    {
        private ICell[,] playField;
        private int rows;
        private int cols;
        private IPosition playerPosition;

        public StandardPlayFieldGenerator( IPosition playerPosition, int rows = Constants.StandardGameLabyrinthRows, int cols = Constants.StandardGameLabyrinthCols)
        {
            this.playField = new Cell[rows, cols];
            this.playerPosition = playerPosition;
            this.rows = rows;
            this.cols = cols;
        }

        public ICell[,] GeneratePlayField(IRandomGenerator rand)
        {
            this.playField = new Cell[rows, cols];

            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    int cellRandomValue = rand.GenerateNext(0, 2);

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

            this.playField[playerPosition.Row, this.playerPosition.Column].ValueChar = Constants.StandardGamePlayerChar;

            bool exitPathExists = ExitPathExists();
            if (!exitPathExists)
            {
                return GeneratePlayField(rand);
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
                if (ExitFound(currentCell))
                {


                    pathExists = true;
                    break;
                }
                //TODO: rename function
                Premestvane(currentCell, Direction.Down, cellsOrder, visitedCells);
                Premestvane(currentCell, Direction.Up, cellsOrder, visitedCells);



                Premestvane(currentCell, Direction.Left, cellsOrder, visitedCells);
                Premestvane(currentCell, Direction.Right, cellsOrder, visitedCells);
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

        //TODO: rename the method
        private void Premestvane(
           ICell cell,
           Direction direction,
           Queue<ICell> cellsOrder,
           HashSet<ICell> visitedCells)
        {
            int newRow;
            int newCol;
            FindNewCellCoordinates(
                cell.Position.Row,
                cell.Position.Column,
                direction,
                out newRow,
                out newCol);

            if (newRow < 0 || newCol < 0 ||
                newRow >= playField.GetLength(0) || newCol >= playField.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(playField[newRow, newCol]))
            {
                return;
            }

            if (playField[newRow, newCol].IsEmpty())
            {
                cellsOrder.Enqueue(playField[newRow, newCol]);
            }
        }

        private void FindNewCellCoordinates(
        int row,
        int col,
        Direction direction,
        out int newRow,
        out int newCol
        )
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
