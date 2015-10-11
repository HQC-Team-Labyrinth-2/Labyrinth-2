namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    /// <summary>
    /// Move right command.
    /// </summary>
    public class MoveRight : MoveCommand, ICommand
    {
        /// <summary>
        /// Constructor for MoveRight command.
        /// </summary>
        public MoveRight()
            : base(Direction.Right)
        {
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Name of the command.</returns>
        public override string GetName()
        {
            return "Move Right";
        }
    }
}
