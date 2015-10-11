namespace Labyrinth.Core.Common.Contracts
{
    /// <summary>
    /// Interface for score ladder content provider.
    /// </summary>
    public interface IScoreLadderContentProvider
    {
        /// <summary>
        /// Method that provide the score ladder.
        /// </summary>
        /// <returns>Top scores in the score ladder.</returns>
        string ProvideContent();
    }
}
