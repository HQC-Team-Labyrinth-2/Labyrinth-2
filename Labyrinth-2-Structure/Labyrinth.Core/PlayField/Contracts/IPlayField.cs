//TODO: SOme of this methods shuld be moved in PlayFieldGenerator interface!
namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;

    public interface IPlayField : IMemorizable
    {
        ICell[,] PlayFieldMatrix { get; }

        int NumberOfRows { get; }

        int NumberOfCols { get; }

        IPosition PlayerPosition { get; }

        ICell GetCell(IPosition position);

        void Initialize(IRandomGenerator generator);

        bool TryMove(ICell cell, Direction direction);
    }
}
