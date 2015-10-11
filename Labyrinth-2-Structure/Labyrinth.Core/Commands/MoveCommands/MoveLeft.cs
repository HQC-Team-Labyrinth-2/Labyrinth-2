namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    /// <summary>
    /// Move left command.
    /// </summary>
    public class MoveLeft : MoveCommand, ICommand
    {
        /// <summary>
        /// Constructor for move left command.
        /// </summary>
        public MoveLeft()
            : base(Direction.Left)
        {
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns> Name of the  command.</returns>
        public override string GetName()
        {
            return "Move Left";
        }
    }
}
