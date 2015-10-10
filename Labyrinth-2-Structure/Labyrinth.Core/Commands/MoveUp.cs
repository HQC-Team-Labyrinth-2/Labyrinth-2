namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class MoveUp : MoveCommand, ICommand
    {
        public MoveUp()
            : base(Direction.Up)
        {
        }

        public override string GetName()
        {
            return "Move Up";
        }
    }
}
