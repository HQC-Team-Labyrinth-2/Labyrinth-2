namespace Labyrinth.Core.Common
{
    public class Position:IPosition
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Column { get; set; }

        public int Row { get; set; }
    }
}
