namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Helpers.Contracts;

    public class ScoreCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Output.ShowScoreLadder(context.Ladder);
        }

        public string GetName()
        {
            return "Score";
        }
    }
}
