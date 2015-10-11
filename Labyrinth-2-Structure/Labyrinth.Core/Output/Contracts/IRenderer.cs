namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// Interface that is responsible for rendering
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Method that displays a given message on the console
        /// </summary>
        /// <param name="infoMesage">String that represents the information to be displayed</param>
        void ShowInfoMessage(string message);

        /// <summary>
        /// Method that shows the top 5 players
        /// </summary>
        /// <param name="score">Parameter of type IScoreLadderContentProvider</param>
        void ShowScoreLadder(IScoreLadderContentProvider scoreProvider);

        /// <summary>
        /// Method that shows the playfield
        /// </summary>
        /// <param name="playField">Parameter of type IPlayField</param>
        void ShowPlayField(IPlayField playField);

        /// <summary>
        /// Method that clears the playfield
        /// </summary>
        void ClearPlayField();
    }
}
