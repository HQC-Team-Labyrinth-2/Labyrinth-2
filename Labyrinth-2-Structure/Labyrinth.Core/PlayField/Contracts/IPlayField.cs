//TODO: SOme of this methods shuld be moved in PlayFieldGenerator interface!

using Labyrinth.Core.Player.Contracts;

namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;

    public interface IPlayField:IMemorizable
    {
        //ICell[,] PlayFieldMatrix { get; }

        int NumberOfRows { get; }

        int NumberOfCols { get; }

        IPosition PlayerPosition { get; }

        ICell GetCell(IPosition position);

        void InitializePlayFieldCells(IRandomGenerator generator);

        void RemovePlayer(IPlayer player);

        void AddPlayer(IPlayer player,IPosition position);

        //bool TryMove(ICell cell, Direction direction);
    }
}
