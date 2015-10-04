using Labyrinth.Core.Common;
using Labyrinth.Common.Contracts;

//TODO: SOme of this methods shuld be moved in PlayFieldGenerator interface!
namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IPlayField
    {
        void Initialize(IRandomGenerator generator);

        ICell[,] PlayFieldMatrix { get; }

        int NumberOfRows { get; }

        int NumberOfCols { get; }

        ICell GetCell(IPosition position);

        IPosition PlayerPosition { get; }

        bool TryMove(ICell cell, Direction direction);
    }
}
