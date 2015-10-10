namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Helpers.Contracts;

    public class RestartCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.PlayField.InitializePlayFieldCells(RandomGenerator.Instance);

            context.Memory.Memento.Clear();

            context.Player.MovesCount = 0;
            context.Player.CurentCell = context.PlayField.GetCell(context.Player.StartPosition);
        }

        public string GetName()
        {
            return "Restart";
        }
    }
}
