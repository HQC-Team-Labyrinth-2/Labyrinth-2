namespace Labyrinth.Core.Helpers
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using System;

    public class Position : IPosition, ICloneablePosition
    {
        private int column;
        private int row;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                if (value > Constants.StandardGameLabyrinthCols || value < 0)
                {
                    throw new ArgumentException(
                        string.Format("Column value must be between {0} and {1}", 1, Constants.StandardGameLabyrinthCols));
                }
                this.column = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value > Constants.StandardGameLabyrinthRows || value < 0)
                {
                    throw new ArgumentException(
                        string.Format("Row value must be between {0} and {1}", 1, Constants.StandardGameLabyrinthRows));
                }
                this.row = value;
            }
        }

        public IPosition Clone()
        {
            return (Position)this.MemberwiseClone();
        }
    }
}
