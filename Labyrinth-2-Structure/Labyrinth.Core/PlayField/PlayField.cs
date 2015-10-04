using Labyrinth.Common.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.PlayField.Contracts;

namespace Labyrinth.Core.PlayField
{
    //TODO: Implement  a PlayField generator class that will keeps all methods for generating playfield.
    public class PlayField : IPlayField, IMemorizable
    {
        private ICell[,] playField;
        private IPlayFieldGenerator playFieldGenerator;

        public PlayField(IPlayFieldGenerator generator,
            IPosition playerPosition,
            int rows = Constants.StandardGameLabyrinthRows,
            int colums = Constants.StandardGameLabyrinthCols
                        )
        {
            this.playFieldGenerator = generator;
            this.NumberOfRows = rows;
            this.NumberOfCols = colums;
            this.PlayerPosition = playerPosition;
        }

        public void Initialize(IRandomGenerator random)
        {
            this.playField = this.playFieldGenerator.GeneratePlayField(random);
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

        public ICell[,] PlayFieldMatrix {
            get
            {
                return this.playField;
            }
        }

        public ICell GetCell(IPosition position)
        {
            return this.playField[position.Row, position.Column];
        }

        //TODO: this function should be in the player class
        //TODO: in this function missing validation  - if player hit in the wall the game should be over!
        public bool TryMove(ICell current, Direction direction)
        {
            int newRow;
            int newCol;
            FindNewCellCoordinates(
                current.Position.Row,
                current.Position.Column,
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
            this.playField[current.Position.Row, current.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
            this.PlayerPosition = new Position(newRow,newCol);
            return true;
        }

        public IMemento SaveMemento()
        {
            return new PlayFieldMemento(this);
        }

        public void RestoreMemento(IMemento memento)
        {
            this.playField = memento.PlayField;
            this.PlayerPosition = memento.PlayerPosition;
        }
    }
}
