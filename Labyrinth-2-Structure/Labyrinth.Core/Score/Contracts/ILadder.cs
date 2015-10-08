namespace Labyrinth.Core.Score.Contracts
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;

    public interface ILadder : IContentProvider
    {
        IRenderer OutputRenderer { set; }

        int Capacity { set; }

        void AddResultInLadder(int movesCount, string playerName);

        bool ResultQualifiesInLadder(int result);
    }
}
