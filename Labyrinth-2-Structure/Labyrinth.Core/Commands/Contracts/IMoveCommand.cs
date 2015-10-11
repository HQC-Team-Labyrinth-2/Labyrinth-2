namespace Labyrinth.Core.Commands.Contracts
{
    using Labyrinth.Core.Common;

    /// <summary>
    /// Interface for commands that execute some  movements
    /// </summary>
    public interface IMoveCommand
    {
        /// <summary>
        /// Property that contains the direction to the movement.
        /// </summary>
        Direction Direction { get; set; }
    }
}
