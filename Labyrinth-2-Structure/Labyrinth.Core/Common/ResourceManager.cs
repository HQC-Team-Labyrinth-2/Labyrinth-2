using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Common
{
    public class ResourceManager
    {
        private static volatile ResourceManager instance;

        private readonly char StandardGameCellEmptyValue = '-';
        private readonly char StandardGameCellWallValue = 'X';

        private readonly char StandardGamePlayerChar = '*';

        private readonly int StandardGameLabyrinthRows = 9;
        private readonly int StandardGameLabyrinthCols = 9;

        private readonly int StandardGameNumberOfPlayers = 1;

        private readonly int StandardGameTopResultCapacity = 5;


        private ResourceManager()
        {
        }

        private ResourceManager GetInstance()
        {

            if (instance == null)
            {
                instance = new ResourceManager();
            }

            return instance;
        }
    }
}
