namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;

    public class RestartCommand:ICommand
    {
        public int Execute(ICommandContext context)
        {
            return 0;
        }
    }
}
