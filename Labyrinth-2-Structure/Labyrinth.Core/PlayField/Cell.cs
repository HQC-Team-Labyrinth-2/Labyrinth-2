using System;

namespace Labyrinth.Core.PlayField
{

    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField.Contracts;

    public class Cell : ICell, ICloneableCell
    {
        public Cell(IPosition position, char value = Constants.StandardGameCellEmptyValue)
        {
            this.Position = position;
            this.ValueChar = value;
        }

        public IPosition Position { get;  set; }

        public char ValueChar { get; set; }

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