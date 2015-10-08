namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Core.Common;

    public interface ICell
    {
        IPosition Position { get; }

        char ValueChar { get; set; }

        bool IsEmpty();
    }
}
