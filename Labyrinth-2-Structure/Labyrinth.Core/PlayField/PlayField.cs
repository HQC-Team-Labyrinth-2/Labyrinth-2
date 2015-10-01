using Labyrinth.Common.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.Players.Contracts;
using Labyrinth.Core.PlayField.Contracts;
using System;
using System.Collections.Generic;


namespace Labyrinth.Core.PlayField
{   
    //TODO: Implement  a PlayField generator class that will keeps all methods for generating playfield.
    public class PlayField : IPlayField
    {
        private ICell[,] playField;

        public PlayField(
            IPosition playerPosition,
            int rows = Constants.StandardGameLabyrinthRows,
            int colums = Constants.StandardGameLabyrinthCols
                        )
        {
            this.NumberOfRows = rows;
            this.NumberOfCols = colums;
            this.PlayerPosition = playerPosition;
            RandomGenerator random = RandomGenerator.Instance;
            GenerateLabyrinth(random);
        }

        public IPosition PlayerPosition { get; private set; }

        //TODO: validation
        public int NumberOfRows
        {
            get;
            private set;
        }

        //TODO: validation
        public int NumberOfCols
        {
            get;
            private set;
        }

        private void GenerateLabyrinth(IRandomGenerator rand)
        {
            this.playField = new Cell[this.NumberOfRows, this.NumberOfCols];

            for (int row = 0; row < this.NumberOfRows; row++)
            {
                for (int col = 0; col < this.NumberOfCols; col++)
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

            this.playField[this.PlayerPosition.Row, this.PlayerPosition.Column].ValueChar = Constants.StandardGamePlayerChar;

            bool exitPathExists = ExitPathExists();
            if (!exitPathExists)
            {
                GenerateLabyrinth(rand);
            }
        }

        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = this.playField[this.PlayerPosition.Row, this.PlayerPosition.Column];
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
            if (cell.Position.Row == this.NumberOfRows - 1 ||



                cell.Position.Column == this.NumberOfCols - 1 ||
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
        //TODO: implement method
        public void AddPlayer(ICharacter player, IPosition position)
        {
            throw new NotImplementedException();
        }

        //TODO: implement method
        public void RemovePlayer(ICharacter player, IPosition position)
        {
            throw new NotImplementedException();
        }

        public ICell GetCell(IPosition position)
        {
            return playField[position.Row,position.Column];
        }

        //TODO: this function should be in the player class
        //TODO: in this function missing validation  - if player hit in the wall the game should be over!
        public bool TryMove(ICell cell, Direction direction)
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
                return false;
            }

            if (!playField[newRow, newCol].IsEmpty())
            {
                return false;
            }

            this.playField[newRow, newCol].ValueChar = Constants.StandardGamePlayerChar;
            this.playField[cell.Position.Row, cell.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
            this.PlayerPosition = playField[newRow, newCol].Position;
            return true;
        }
    }
}
