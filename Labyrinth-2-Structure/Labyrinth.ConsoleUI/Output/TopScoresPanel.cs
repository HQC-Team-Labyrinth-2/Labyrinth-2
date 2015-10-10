namespace Labyrinth.ConsoleUI.Output
{
    using System;
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;

    public class TopScoresPanel : ILadderRenderer
    {
        public void ShowTopScores(IScoreLadderProvider score)
        {
            Console.WriteLine(score.ProvideContent());
        }
    }
}
