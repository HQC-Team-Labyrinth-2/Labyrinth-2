namespace Labyrinth.Core.PlayField.Contracts
{
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Player.Contracts;

    /// <summary>
    /// Interface that represents the playfield
    /// </summary>
    public interface IPlayField : IMemorizable
    {
        /// <summary>
        /// Property of type int
        /// </summary>
        int NumberOfRows { get; }

        /// <summary>
        /// Property of type int
        /// </summary>
        int NumberOfCols { get; }

        /// <summary>
        /// Property of type IPosition
        /// </summary>
        IPosition PlayerPosition { get; }

        /// <summary>
        /// Method that gets the current cell 
        /// </summary>
        /// <param name="position">Parameter of type IPosition</param>
        /// <returns>Returns the current position as a cell</returns>
        ICell GetCell(IPosition position);

        /// <summary>
        /// Method that initializes the playfield
        /// </summary>
        /// <param name="generator">Parameter of type IRandomNumberGenerator</param>
        void InitializePlayFieldCells(IRandomNumberGenerator generator);

        /// <summary>
        /// Method that removes the player
        /// </summary>
        /// <param name="player">Parameter of type IPlayer</param>
        void RemovePlayer(IPlayer player);

        /// <summary>
        /// Method that adds the player
        /// </summary>
        /// <param name="player">Parameter of type IPlayer</param>
        /// <param name="position">Parameter of type IPositin</param>
        void AddPlayer(IPlayer player, IPosition position);
    }
}
