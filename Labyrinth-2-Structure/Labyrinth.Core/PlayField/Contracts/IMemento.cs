namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;

    public interface IMemento
    {
        ICell[,] PlayField { get; set; }

        IPosition PlayerPosition { get; set; }
    }
}
