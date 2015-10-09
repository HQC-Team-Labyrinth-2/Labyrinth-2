namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Core.Common;

    public interface IMemento
    {
        ICell[,] PlayField { get; set; }

        IPosition PlayerPosition { get; set; }
    }
}
