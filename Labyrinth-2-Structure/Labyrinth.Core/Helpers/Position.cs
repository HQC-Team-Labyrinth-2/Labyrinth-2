namespace Labyrinth.Core.Helpers
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;

    public class Position : IPosition, ICloneablePosition
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public IPosition Clone()
        {
            return (Position)this.MemberwiseClone();
        }
    }
}
