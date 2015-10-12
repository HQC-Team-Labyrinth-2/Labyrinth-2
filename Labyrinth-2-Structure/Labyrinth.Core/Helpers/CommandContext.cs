namespace Labyrinth.Core.Helpers
{
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;

    /// <summary>
    /// Class for command context
    /// </summary>
    public class CommandContext : ICommandContext
    {
        /// <summary>
        /// Constructor with 5 parameters
        /// </summary>
        /// <param name="playField">Parameter of type IPlayField </param>
        /// <param name="output">Parameter of type IRenderer</param>
        /// <param name="memory">Parameter of type IMementoCaretaker</param>
        /// <param name="ladder">Parameter of type IScoreLadder</param>
        /// <param name="player">Parameter of type IPlayer</param>
        public CommandContext(IPlayField playField, IRenderer output, IMementoCaretaker memory, IScoreLadder ladder, IPlayer player)
        {
            this.PlayField = playField;
            this.Output = output;
            this.Memory = memory;
            this.Ladder = ladder;
            this.Player = player;
        }

        /// <summary>
        /// Property of type IPlayField
        /// </summary>
        public IPlayField PlayField { get; set; }

        /// <summary>
        /// Property of type IRenderer
        /// </summary>
        public IRenderer Output { get; private set; }

        /// <summary>
        /// Property of type IMementoCaretaker
        /// </summary>
        public IMementoCaretaker Memory { get; set; }

        /// <summary>
        /// Property of type IScoreLadder
        /// </summary>
        public IScoreLadder Ladder { get; private set; }

        /// <summary>
        /// Property of type IPlayer
        /// </summary>
        public IPlayer Player { get; private set; }
    }
}
