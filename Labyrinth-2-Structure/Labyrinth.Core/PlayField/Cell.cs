namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using System;

    /// <summary>
    /// This class represents the game cell
    /// </summary>
    public class Cell : ICell, ICloneableCell
    {
        private char valueChar;

        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="position">Parameter of type IPosition</param>
        /// <param name="value">Parameter of type char</param>
        public Cell(IPosition position, char value = Constants.StandardGameCellEmptyValue)
        {
            this.Position = position;
            this.ValueChar = value;
        }

        /// <summary>
        /// Property of type IPosition
        /// </summary>
        public IPosition Position { get;  set; }

        /// <summary>
        /// Property of type char
        /// </summary>
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

        /// <summary>
        /// Method that checks if a cell is empty
        /// </summary>
        /// <returns>Bool value</returns>
        public bool IsEmpty()
        {
            if (this.ValueChar == Constants.StandardGameCellEmptyValue)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method that clones the cell
        /// </summary>
        /// <returns>Returns value of type ICell</returns>
        public ICell Clone()
        {
            Cell newCell = (Cell)this.MemberwiseClone();
            newCell.Position = newCell.Position.Clone();
            return newCell;
        }
    }
}