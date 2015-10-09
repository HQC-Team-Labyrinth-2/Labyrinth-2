namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;

    public class ScoreCommand:ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Output.Show(context.Ladder);
        }

        public string GetName()
        {
            return "Score";
        }
    }
}
