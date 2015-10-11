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
        public IPosition PlayerPosition { get; private set; }

        //TODO: validation

        /// <summary>
        /// Property of type int
        /// </summary>
        public int NumberOfRows
        {
            get;
            private set;
        }

        //TODO: validation

        /// <summary>
        /// Property of type int
        /// </summary>
        public int NumberOfCols
        {
            get;
            private set;
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
        /// Method that ???
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public ICell GetCell(IPosition position)
        {
            return this.playField[position.Row, position.Column];
        }

        //TODO Validate Remove player position
        public void RemovePlayer(IPlayer player)
        {
            this.playField[player.CurentCell.Position.Row, player.CurentCell.Position.Column].ValueChar = Constants.StandardGameCellEmptyValue;
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
