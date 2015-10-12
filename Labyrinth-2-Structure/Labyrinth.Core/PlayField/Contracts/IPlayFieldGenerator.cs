namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;

    /// <summary>
    /// Interface that represents the playfield generator
    /// </summary>
    public interface IPlayFieldGenerator
    {
        /// <summary>
        /// Method that generates the playfield
        /// </summary>
        /// <param name="rand">Parameter of type IRandomNumberGenerator</param>
        /// <returns>Returns the playfield as a two dimensional array</returns>
        ICell[,] GeneratePlayField(IRandomNumberGenerator rand);
    }
}
