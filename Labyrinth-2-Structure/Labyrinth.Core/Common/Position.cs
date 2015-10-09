namespace Labyrinth.Core.Common
{
    using Labyrinth.Core.Commands.Contracts;

    public class Position : IPosition, ICloneablePosition
    {
        public Position(int row = Constants.StandardGameLabyrinthRows / 2, int col = Constants.StandardGameLabyrinthCols / 2)
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
