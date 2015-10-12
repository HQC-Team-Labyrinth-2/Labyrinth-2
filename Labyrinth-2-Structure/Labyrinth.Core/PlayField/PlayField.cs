using System;

namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Helpers.CustomExceptions;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// This class represents the game playfield
    /// </summary>
    public class PlayField : IPlayField, IMemorizable
    {
        private ICell[,] playField;
        private IPlayFieldGenerator playFieldGenerator;
        private int rows;
        private int colums;
        private IPosition playerPosition;


        /// <summary>
        /// Constructor with 4 parameters
        /// </summary>
        /// <param name="generator">Parameter of type IPlayFieldGenerator</param>
        /// <param name="playerPosition">Parameter of type IPosition</param>
        /// <param name="rows">Parameter of type int</param>
        /// <param name="colums">Parameter of type int</param>
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

        /// <summary>
        /// Property of type int
        /// </summary>
        public IPosition PlayerPosition
        {
            get { return this.playerPosition; }
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

        /// <summary>
        /// Property of type int
        /// </summary>
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

        /// <summary>
        /// Property of type int
        /// </summary>
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

        /// <summary>
        /// Method that initializes the playfield
        /// </summary>
        /// <param name="random">Parameter of type IRandomNumberGenerator</param>
        public void InitializePlayFieldCells(IRandomNumberGenerator random)
        {
            this.playField = this.playFieldGenerator.GeneratePlayField(random);
        }

        /// <summary>
        /// Method that return cell on a givven position from the play field.
        /// </summary>
        /// <param name="position">Cell position.</param>
        /// <returns>Cell on the given position.</returns>
        public ICell GetCell(IPosition position)
        {
            return this.playField[position.Row, position.Column];
        }

        /// <summary>
        /// Removes the player from his position on the play field.
        /// </summary>
        /// <param name="player">Player that need to be removed.</param>
        public void RemovePlayer(IPlayer player)
        {
            if (player.CurentCell.Position.Row == this.PlayerPosition.Row &&
                player.CurentCell.Position.Column == this.PlayerPosition.Column)
            {
                this.playField[player.CurentCell.Position.Row, player.CurentCell.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
            }
        }

        /// <summary>
        /// Adds the player in given given position on the board.
        /// </summary>
        /// <param name="player">Player that want to be added.</param>
        /// <param name="position">Position on witch player should be move on.</param>
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

        /// <summary>
        /// Save the play field in the memory.
        /// </summary>
        /// <returns>Clone of the play field object</returns>
        public IMemento SaveMemento()
        {
            return new PlayFieldMemento(this.playField, this.PlayerPosition);
        }

        /// <summary>
        /// Restore the current play field from memento object. 
        /// </summary>
        /// <param name="memento"></param>
        public void RestoreMemento(IMemento memento)
        {
            this.playField = memento.PlayField;
            this.PlayerPosition = memento.PlayerPosition;
        }
    }
}
