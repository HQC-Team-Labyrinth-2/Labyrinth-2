namespace Labyrinth.Core.Score.Contracts
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;

    public interface IScoreLadder : IScoreLadderContentProvider
    {
        int Capacity { set; }

        void AddResultInLadder(int movesCount, string playerName);

        bool ResultQualifiesInLadder(int result);
    }
}
