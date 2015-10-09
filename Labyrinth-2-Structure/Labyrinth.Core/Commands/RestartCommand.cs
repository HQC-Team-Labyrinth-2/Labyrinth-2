namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;

    public class RestartCommand:ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.PlayField.InitializePlayFieldCells(RandomGenerator.Instance);
            
            context.Memory.Memento.Clear();

            context.Player.MovesCount = 0;
            context.Player.CurentCell = context.PlayField.GetCell(new Position(4,4));
        }

        public string GetName()
        {
            return "Restart";
        }
    }
}
