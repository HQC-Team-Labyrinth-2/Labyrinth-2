namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.PlayField.Contracts;
    /// <summary>
    /// Interface that renders the playfield
    /// </summary>
    public interface IPlayFieldRenderer
    {
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
