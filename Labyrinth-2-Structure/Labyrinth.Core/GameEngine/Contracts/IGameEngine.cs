namespace Labyrinth.Core.GameEngine.Contracts
{
    using Labyrinth.Common.Contracts;

    /// <summary>
    /// Interface for game engine.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Initialize the playfield.
        /// </summary>
        /// <param name="random">Random number generator</param>
        void Initialize(IRandomNumberGenerator random);

        /// <summary>
        /// Method that run the main game logic.
        /// </summary>
        void Start();
    }
}
