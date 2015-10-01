namespace Labyrinth.Core.Output.Contracts
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public interface IRenderer
    {
        void PrintPlayField(IPlayField playField);

        void PrintMessage(string msg);

        void Show(IContentProvider content);
    }
}
