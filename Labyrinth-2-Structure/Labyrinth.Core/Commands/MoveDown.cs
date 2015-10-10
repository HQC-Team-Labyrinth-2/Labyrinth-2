namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class MoveDown : MoveCommand, ICommand
    {
        public MoveDown()
            : base(Direction.Down)
        {
        }

        public override string GetName()
        {
            return "Move Down";
        }
    }
}
