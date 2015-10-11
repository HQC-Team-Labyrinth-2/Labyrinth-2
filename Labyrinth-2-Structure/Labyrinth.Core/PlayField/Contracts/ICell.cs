namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Interface that represents game cell
    /// </summary>
    public interface ICell : ICloneableCell
    {
        /// <summary>
        /// Property of type IPosition
        /// </summary>
        IPosition Position { get; set; }

        /// <summary>
        /// Property of type char
        /// </summary>
        char ValueChar { get; set; }

        /// <summary>
        /// Method that checks if a cell is empty
        /// </summary>
        /// <returns>Bool value</returns>
        bool IsEmpty();
    }
}
