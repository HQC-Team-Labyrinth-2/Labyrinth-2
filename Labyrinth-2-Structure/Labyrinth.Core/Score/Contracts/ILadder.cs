using Labyrinth.Core.Output.Contracts;
namespace Labyrinth.Core.Score.Contracts
{
    public interface ILadder
    {
        void AddResultInLadder(int movesCount, string playerName);

        bool ResultQualifiesInLadder(int result);

        IRenderer OutputRenderer { set; }

        int Capacity { set; }
    }
}
