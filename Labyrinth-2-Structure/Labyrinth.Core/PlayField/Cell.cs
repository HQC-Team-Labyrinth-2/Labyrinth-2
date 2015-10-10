namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using System;

    public class Cell : ICell, ICloneableCell
    {
        private char valueChar;

        public Cell(IPosition position, char value = Constants.StandardGameCellEmptyValue)
        {
            this.Position = position;
            this.ValueChar = value;
        }

        public IPosition Position { get;  set; }

        public char ValueChar
        {
            get
            {
                return this.valueChar;
            }

            set
            {
                if(
                    value != Constants.StandardGameCellEmptyValue &&
                    value != Constants.StandardGameCellWallValue &&
                    value != Constants.StandardGamePlayerChar
                    )
                {
                    throw new ArgumentException("The value char must be in already defined ones!");
                }
                this.valueChar = value;
            }
        }

        public bool IsEmpty()
        {
            if (this.ValueChar == Constants.StandardGameCellEmptyValue)
            {
                return true;
            }

            return false;
        }

        public ICell Clone()
        {
            Cell newCell = (Cell)this.MemberwiseClone();
            newCell.Position = newCell.Position.Clone();
            return newCell;
        }
    }
}