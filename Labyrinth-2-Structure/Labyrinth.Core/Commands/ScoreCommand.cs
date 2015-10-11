namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Helpers.Contracts;

    /// <summary>
    /// Score command class/
    /// </summary>
    public class ScoreCommand : ICommand
    {
        /// <summary>
        /// Method that execute score command(shows the top results.)
        /// </summary>
        /// <param name="context">Contains all parameters that command need for execution.</param>
        public void Execute(ICommandContext context)
        {
            context.Output.ShowScoreLadder(context.Ladder);
        }

        /// <summary>
        /// Method that returns the name of the command.
        /// </summary>
        /// <returns>Command name.</returns>
        public string GetName()
        {
            return "Score";
        }
    }
}
