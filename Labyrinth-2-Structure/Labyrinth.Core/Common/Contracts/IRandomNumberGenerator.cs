namespace Labyrinth.Common.Contracts
{
    /// <summary>
    ///Interface for random number generator.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Method for generating random number in given range.
        /// </summary>
        /// <param name="from">Minimum value for generation number.</param>
        /// <param name="to">Maximum value for generation number.</param>
        /// <returns>Random generated number in given range.</returns>
        int GenerateNext(int from, int to);
    }
}
