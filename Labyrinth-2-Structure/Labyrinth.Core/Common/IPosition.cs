using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Common
{
    public interface IPosition
    {
        int Row { get; set; }

        int Column { get; set; }
    }
}
