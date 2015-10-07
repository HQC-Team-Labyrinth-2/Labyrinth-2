﻿namespace Labyrinth.Core.Commands
{
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common.Contracts;

    public class ScoreCommand:ICommand
    {
        public int Execute(ICommandContext context)
        {
            context.Output.Show(context.Ladder);

            return 0;
        }

        public string GetName()
        {
            return "Score";
        }
    }
}
