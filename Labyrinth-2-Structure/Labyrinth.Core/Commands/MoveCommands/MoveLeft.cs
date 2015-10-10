namespace Labyrinth.Core.Commands.MoveCommands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class MoveLeft : MoveCommand, ICommand
    {
        public MoveLeft()
            : base(Direction.Left)
        {
        }

        public override string GetName()
        {
            return "Move Left";
        }
    }
}
