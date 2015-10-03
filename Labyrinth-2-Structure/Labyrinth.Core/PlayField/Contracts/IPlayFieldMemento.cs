using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Core.Common;

namespace Labyrinth.Core.PlayField.Contracts
{
    public interface IMemento
    {
        ICell[,] PlayField { get; set; }

        IPosition PlayerPosition { get; set; }
    }
}
