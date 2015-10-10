namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;

    public interface ICell : ICloneableCell
    {
        IPosition Position { get; set; }

        char ValueChar { get; set; }

        bool IsEmpty();
    }
}
