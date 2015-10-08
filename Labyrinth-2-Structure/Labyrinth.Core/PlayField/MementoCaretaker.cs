namespace Labyrinth.Core.PlayField
{
    using System.Collections.Generic;
    using Labyrinth.Core.PlayField.Contracts;

    public class MementoCaretaker : IMementoCaretaker
    {
        public MementoCaretaker(ICollection<IMemento> mementoes)
        {
            this.Memento = mementoes;
        }

        public ICollection<IMemento> Memento { get; set; }
    }
}
