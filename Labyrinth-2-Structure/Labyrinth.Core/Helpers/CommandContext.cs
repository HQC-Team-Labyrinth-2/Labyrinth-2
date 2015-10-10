namespace Labyrinth.Core.Helpers
{
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;

    public class CommandContext : ICommandContext
    {
        public CommandContext(IPlayField playField, IRenderer output, IMementoCaretaker memory, IScoreLadder ladder, IPlayer player)
        {
            this.PlayField = playField;
            this.Output = output;
            this.Memory = memory;
            this.Ladder = ladder;
            this.Player = player;
        }

        public IPlayField PlayField { get; set; }

        public IRenderer Output { get; private set; }

        public IMementoCaretaker Memory { get; set; }

        public IScoreLadder Ladder { get; private set; }

        public IPlayer Player { get; private set; }
    }
}
