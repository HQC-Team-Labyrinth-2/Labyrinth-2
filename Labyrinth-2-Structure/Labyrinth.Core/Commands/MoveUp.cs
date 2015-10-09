namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Commands.Contracts;

    public class MoveUp:MoveCommand, ICommand
    {
        public MoveUp() : base(Direction.Up)
        {
            
        }

        public override string GetName()
        {
            return "Move Up";
        }
    }
}
