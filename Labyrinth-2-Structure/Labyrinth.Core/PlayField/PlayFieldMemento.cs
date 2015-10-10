namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField.Contracts;

    public class PlayFieldMemento : IMemento
    {
        private ICell[,] playField;

        public PlayFieldMemento(ICell[,] playField, IPosition playerPosition)
        {
            this.playField = new ICell[playField.GetLength(0), playField.GetLength(1)];
            this.PlayField = playField;
            this.PlayerPosition = playerPosition;
        }

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

        public IPosition PlayerPosition { get; set; }
    }
}
