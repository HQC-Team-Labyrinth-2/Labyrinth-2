namespace Labyrinth.Core.PlayField
{
    using System.Collections.Generic;
    using Labyrinth.Core.PlayField.Contracts;

    /// <summary>
    /// Memory that store all play field memento objects.
    /// </summary>
    public class MementoCaretaker : IMementoCaretaker
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mementos">Collection of mementos</param>
        public MementoCaretaker(ICollection<IMemento> mementos)
        {
            this.Memento = mementos;
        }

        /// <summary>
        /// Collection of memento objects.
        /// </summary>
        public ICollection<IMemento> Memento { get; set; }
    }
}
