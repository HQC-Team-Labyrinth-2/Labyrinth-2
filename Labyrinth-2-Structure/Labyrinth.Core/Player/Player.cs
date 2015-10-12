namespace Labyrinth.Core.Player
{
    using System;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// Class that represents the player
    /// </summary>
    public class Player : IPlayer
    {
        private string name;
        private ICell currentCell;
        
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="name">String that represents the name of the player</param>
        /// <param name="cell">Object of type ICell that represents the current position of the player</param>
        public Player(string name, ICell cell)
        {
            this.MovesCount = 0;
            this.Name = name;
            this.CurentCell = cell;
            this.StartPosition = cell.Position;
        }

        /// <summary>
        /// Property of type int
        /// </summary>
        public int MovesCount { get; set; }

        /// <summary>
        /// Property of type string
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //TODO: custom exception for invalid name
                    throw new ArgumentException("Player name can't be null or empty string!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Property of type ICell
        /// </summary>
        public ICell CurentCell
        {
            get
            {
                return this.currentCell;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Current player cell can't be null!");
                }

                this.currentCell = value;

            }
        }

        /// <summary>
        /// Property of type IPosition
        /// </summary>
        public IPosition StartPosition { get; private set; }
    }
}
