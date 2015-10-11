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
                if (value < 0)
                {
                    throw new ArgumentException(
                        string.Format("Column value must be larger or equal to 1"));
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
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("Row value must be larger or equal to 0"));
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
