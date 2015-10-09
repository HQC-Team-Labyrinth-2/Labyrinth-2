namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class MoveRight : MoveCommand,ICommand
    {
        public MoveRight():base(Direction.Right)
        {
        }

        public override string GetName()
        {
            return "Move Right";
        }
    }
}
