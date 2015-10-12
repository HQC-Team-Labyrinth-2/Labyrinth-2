namespace Labyrinth.Core.Helpers.Contracts
{
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;

    /// <summary>
    /// Interface for Command context
    /// </summary>
    public interface ICommandContext
    {
        /// <summary>
        /// Property of type IPlayField
        /// </summary>
        IPlayField PlayField { get; set; }

        /// <summary>
        /// Property of type IRenderer
        /// </summary>
        IRenderer Output { get; }

        /// <summary>
        /// Property of type IMementoCaretaker
        /// </summary>
        IMementoCaretaker Memory { get; }

        /// <summary>
        /// Property of type IScoreLadder
        /// </summary>
        IScoreLadder Ladder { get; }

        /// <summary>
        /// Property of type IPlayer
        /// </summary>
        IPlayer Player { get; }
    }
}
