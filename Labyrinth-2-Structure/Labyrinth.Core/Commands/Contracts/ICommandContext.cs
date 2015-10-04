using Labyrinth.Core.Score.Contracts;

namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public interface ICommandContext
    {
        IPlayField PlayField { get; set; }

        IRenderer Output { get; }

        IMementoCaretaker Memory { get; }

        ILadder Ladder { get; }
    }
}
