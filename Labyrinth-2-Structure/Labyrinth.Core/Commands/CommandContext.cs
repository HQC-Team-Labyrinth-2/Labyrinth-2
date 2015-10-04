namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;

    public class CommandContext : ICommandContext
    {
        public CommandContext(IPlayField playField, IRenderer output, IMementoCaretaker memory, ILadder ladder)
        {
            this.PlayField = playField;
            this.Output = output;
            this.Memory = memory;
            this.Ladder = ladder;
        }

        public IPlayField PlayField { get; set; }

        public IRenderer Output { get; private set; }

        public IMementoCaretaker Memory { get; private set; }

        public ILadder Ladder { get; private set; }
    }
}
