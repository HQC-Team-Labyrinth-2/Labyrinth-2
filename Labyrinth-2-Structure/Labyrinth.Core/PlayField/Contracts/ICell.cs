using Labyrinth.Core.Common;
namespace Labyrinth.Core.PlayField.Contracts
{
    public interface ICell
    {
        IPosition Position { get; }

        char ValueChar { get; set; }

        bool IsEmpty();
    }
}
