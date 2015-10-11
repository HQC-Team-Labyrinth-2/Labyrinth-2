namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Player.Contracts;

    public interface IPlayField : IMemorizable
    {
        int NumberOfRows { get; }

        int NumberOfCols { get; }

        IPosition PlayerPosition { get; }

        ICell GetCell(IPosition position);

        void InitializePlayFieldCells(IRandomNumberGenerator generator);

        void RemovePlayer(IPlayer player);

        void AddPlayer(IPlayer player, IPosition position);
    }
}
