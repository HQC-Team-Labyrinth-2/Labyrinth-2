namespace Labyrinth.Core.Player
{
    using System;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class Player : IPlayer
    {
        private string name;

        public Player(string name, ICell cell)
        {
            this.MovesCount = 0;
            this.Name = name;
            this.CurentCell = cell;
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
                    throw new ArgumentException("Player name can't be null or empty string!");
                }

                this.name = value;
            }
        }

        public ICell CurentCell { get; set; }
    }
}
