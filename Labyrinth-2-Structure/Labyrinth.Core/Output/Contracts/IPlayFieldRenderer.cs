namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.PlayField.Contracts;

    public interface IPlayFieldRenderer
    {
        void ShowPlayField(IPlayField playField);

        void ClearPlayField();
    }
}
