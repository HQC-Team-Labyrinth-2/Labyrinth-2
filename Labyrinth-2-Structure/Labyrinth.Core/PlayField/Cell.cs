namespace Labyrinth.Core.PlayField
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField.Contracts;
    
    public class Cell:ICell
    {
        public Cell(IPosition position, char value)
        {
            this.Position = position;
            this.ValueChar = value;
        }

        public IPosition Position { get; private set; }

        public char ValueChar { get; set; }

        public bool IsEmpty()
        {
            if (this.ValueChar == Constants.StandardGameCellEmptyValue)
            {
                return true;
            }

            return false;
        }
    }
}
