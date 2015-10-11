namespace Labyrinth.Core.Player.Contracts
{
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// Interface that represents the player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Property of type int
        /// </summary>
        int MovesCount { get; set; }

        /// <summary>
        /// Property of type string
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Property of type ICell
        /// </summary>
        ICell CurentCell { get; set; }

        /// <summary>
        /// Property of type IPosition
        /// </summary>
        IPosition StartPosition { get; }
    }
}
