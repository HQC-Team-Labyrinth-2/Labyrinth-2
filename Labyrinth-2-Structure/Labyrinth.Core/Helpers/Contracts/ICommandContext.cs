namespace Labyrinth.Core.Helpers.Contracts
{
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;

    public interface ICommandContext
    {
        IPlayField PlayField { get; set; }

        IRenderer Output { get; }

        IMementoCaretaker Memory { get; }

        IScoreLadder Ladder { get; }

        IPlayer Player { get; }
    }
}
