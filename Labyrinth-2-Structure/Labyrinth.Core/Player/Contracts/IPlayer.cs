namespace Labyrinth.Core.Player.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public interface IPlayer
    {
        int MovesCount { get; set; }

        string Name { get; set; }

        ICell CurentCell { get; set; }

        IPosition StartPosition { get; }
    }
}
