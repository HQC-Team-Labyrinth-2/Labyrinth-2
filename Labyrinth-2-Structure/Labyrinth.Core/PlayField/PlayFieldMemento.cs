namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// Play field memento class that store the state of the play field.
    /// </summary>
    public class PlayFieldMemento : IMemento
    {
        private ICell[,] playField;

        /// <summary>
        /// Constructor for the play field memento.
        /// </summary>
        /// <param name="playField">Matrix of ICell objects.</param>
        /// <param name="playerPosition">Position of the player.</param>
        public PlayFieldMemento(ICell[,] playField, IPosition playerPosition)
        {
            this.playField = new ICell[playField.GetLength(0), playField.GetLength(1)];
            this.PlayField = playField;
            this.PlayerPosition = playerPosition;
        }

        /// <summary>
        /// Matrix of ICell objects
        /// </summary>
        public ICell[,] PlayField
        {
            get
            {
                return this.playField;
            }

            set
            {
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    for (int j = 0; j < value.GetLength(1); j++)
                    {
                        if (value[i, j] != null)
                        {
                            this.playField[i, j] = value[i, j].Clone();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Position of the player on the play field.
        /// </summary>
        public IPosition PlayerPosition { get; set; }
    }
}
