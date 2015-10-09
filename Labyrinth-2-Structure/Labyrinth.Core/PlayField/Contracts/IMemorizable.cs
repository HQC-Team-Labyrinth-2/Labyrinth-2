
namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IMemorizable
    {
        IMemento SaveMemento();

        void RestoreMemento(IMemento memento);
    }
}
