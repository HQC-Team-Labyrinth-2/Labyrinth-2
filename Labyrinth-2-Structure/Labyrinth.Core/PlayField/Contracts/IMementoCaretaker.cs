using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IMementoCaretaker
    {
        ICollection<IMemento> Memento { get; set; }
    }
}
