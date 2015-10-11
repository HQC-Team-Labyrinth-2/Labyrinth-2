using System;

namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Helpers.CustomExceptions;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class PlayField : IPlayField, IMemorizable
    {
        private ICell[,] playField;
        private IPlayFieldGenerator playFieldGenerator;
        private int rows;
        private int colums;
        private IPosition playerPosition;

        public PlayField(
            IPlayFieldGenerator generator,
            IPosition playerPosition,
            int rows = Constants.StandardGameLabyrinthRows,
            int colums = Constants.StandardGameLabyrinthCols)
        {
            this.playFieldGenerator = generator;
            this.NumberOfRows = rows;
            this.NumberOfCols = colums;
            this.PlayerPosition = playerPosition;
        }

        public IPosition PlayerPosition
        {
            get
            {
                return this.playerPosition;
            }
            private set
            {
                if (value.Column > this.NumberOfCols - 1 ||
                    value.Column < 0 ||
                    value.Row > this.NumberOfRows - 1 ||
                    value.Row < 0)
                {
                    throw new ArgumentOutOfRangeException("Player position can't be out of the play field!");
                }

                this.playerPosition = value;
            }
        }

        public int NumberOfRows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value < 3)
                {
                    throw new ArgumentOutOfRangeException("Number of rows must be grather than 3!");
                }

                this.rows = value;
            }
        }

        public int NumberOfCols
        {
            get
            {
                return this.colums;
            }
            private set
            {
                if (value < 3)
                {
                    throw new ArgumentOutOfRangeException("Number of colums must be grather than 3!");
                }

                this.colums = value;
            }
        }

        public void InitializePlayFieldCells(IRandomNumberGenerator random)
        {
            this.playField = this.playFieldGenerator.GeneratePlayField(random);
        }

        public ICell GetCell(IPosition position)
        {
            return this.playField[position.Row, position.Column];
        }

        public void RemovePlayer(IPlayer player)
        {
            if (player.CurentCell.Position.Row == this.PlayerPosition.Row &&
                player.CurentCell.Position.Column == this.PlayerPosition.Column)
            {
                this.playField[player.CurentCell.Position.Row, player.CurentCell.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
            }
        }

        public void AddPlayer(IPlayer player, IPosition position)
        {
            if (!this.playField[position.Row, position.Column].IsEmpty())
            {
                throw new InvalidPlayerPositionException(GlobalErrorMessages.InvalidMoveMessage);
            }

            player.CurentCell = this.playField[position.Row, position.Column];
            this.playField[position.Row, position.Column].ValueChar = Constants.StandardGamePlayerChar;
            this.PlayerPosition = position;
        }

        public IMemento SaveMemento()
        {
            return new PlayFieldMemento(this.playField, this.PlayerPosition);
        }

        public void RestoreMemento(IMemento memento)
        {
            this.playField = memento.PlayField;
            this.PlayerPosition = memento.PlayerPosition;
        }
    }
}
