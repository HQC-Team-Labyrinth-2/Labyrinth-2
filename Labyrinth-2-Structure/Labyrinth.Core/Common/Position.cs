namespace Labyrinth.Core.Common
{
    using System;

    public class Position : IPosition, ICloneable
    {
        public Position(int row = Constants.StandardGameLabyrinthRows / 2, int col = Constants.StandardGameLabyrinthCols / 2)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public object Clone()
        {
            return (Position)this.MemberwiseClone();
        }
    }
}
