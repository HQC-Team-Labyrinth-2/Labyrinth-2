namespace Labyrinth.Core.Helpers.Contracts
{
    using Labyrinth.Core.Common;

    /// <summary>
    /// Interface for cloning the player's position
    /// </summary>
    public interface ICloneablePosition
    {
        /// <summary>
        /// Method that clones the player's position
        /// </summary>
        IPosition Clone();
    }
}
