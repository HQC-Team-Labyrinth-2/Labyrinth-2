namespace Labyrinth.Core.Common
{
    public class ResourceManager
    {
        //TODO: Implement menu
        private static volatile ResourceManager instance;

        private readonly char standardGameCellEmptyValue = '-';
        private readonly char standardGameCellWallValue = 'X';

        private readonly char standardGamePlayerChar = '*';

        private readonly int standardGameLabyrinthRows = 9;
        private readonly int standardGameLabyrinthCols = 9;

        private readonly int standardGameNumberOfPlayers = 1;

        private readonly int standardGameTopResultCapacity = 5;

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
