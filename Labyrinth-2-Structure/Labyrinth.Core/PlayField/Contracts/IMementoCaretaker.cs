namespace Labyrinth.Core.PlayField.Contracts
{
    using System.Collections.Generic;

    public interface IMementoCaretaker
    {
        ICollection<IMemento> Memento { get; set; }
    }
}
