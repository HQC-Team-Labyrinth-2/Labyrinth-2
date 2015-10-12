namespace Labyrinth.Core.Helpers.Contracts
{
    /// <summary>
    /// Interface for position, inherits ICloneablePosition
    /// </summary>
    public interface IPosition : ICloneablePosition
    {
        /// <summary>
        /// Property for row of type int
        /// </summary>
        int Row { get; set; }

        /// <summary>
        /// Property for column of type int
        /// </summary>
        int Column { get; set; }
    }
}
