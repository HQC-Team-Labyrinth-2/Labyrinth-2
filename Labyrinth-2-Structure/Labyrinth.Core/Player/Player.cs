namespace Labyrinth.Core.Player
{
    using System;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class Player : IPlayer
    {
        private string name;
        private ICell currentCell;
        
        public Player(string name, ICell cell)
        {
            this.MovesCount = 0;
            this.Name = name;
            this.CurentCell = cell;
            this.StartPosition = cell.Position;
        }

        public int MovesCount { get; set; }

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

        public IPosition StartPosition { get; private set; }
    }
}
