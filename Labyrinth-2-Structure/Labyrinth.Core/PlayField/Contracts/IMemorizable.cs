using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IMemorizable
    {
        IMemento SaveMemento();

        void RestoreMemento(IMemento memento);
    }
}
