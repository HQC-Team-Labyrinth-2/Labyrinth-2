namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.Common.Contracts;

    /// <summary>
    /// Interface for rendering ladder
    /// </summary>
    public interface ILadderRenderer
    {
        /// <summary>
        /// Method that shows the top 5 players
        /// </summary>
        /// <param name="score">Parameter of type IScoreLadderContentProvider</param>
        void ShowTopScores(IScoreLadderContentProvider score);
    }
}
