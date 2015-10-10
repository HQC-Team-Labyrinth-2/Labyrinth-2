namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public interface IRenderer
    {
        void ShowInfoMessage(string message);

        void ShowScoreLadder(IScoreLadderContentProvider scoreProvider);

        void ShowPlayField(IPlayField playField);

        void ClearPlayField();
    }
}
