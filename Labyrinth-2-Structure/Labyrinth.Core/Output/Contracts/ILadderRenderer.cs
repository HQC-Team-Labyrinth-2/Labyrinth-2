namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.Common.Contracts;

    public interface ILadderRenderer
    {
        void ShowTopScores(IScoreLadderProvider score);
    }
}
