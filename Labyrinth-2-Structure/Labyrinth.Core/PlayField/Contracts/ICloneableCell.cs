namespace Labyrinth.Core.PlayField.Contracts
{
    /// <summary>
    /// Interface that allows the game cells to be cloneable
    /// </summary>
    public interface ICloneableCell
    {
        /// <summary>
        /// Method that clones the cell
        /// </summary>
        /// <returns>Returns value of type ICell</returns>
        ICell Clone();
    }
}
