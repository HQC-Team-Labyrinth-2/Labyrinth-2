namespace Labyrinth.Core.Common
{
    /// <summary>
    /// This class contains the global error messages as constants
    /// </summary>
    public class GlobalErrorMessages
    {
        public const string InvalidMoveMessage = "Invalid move!You lost";
        public const string InvalidCommandMessage = "Invalid command!";
        public const string ScoreBoardEmptyMessage = "The scoreboard is empty.";

        public const string StandardGameInvalidNumberOfPlayers = "Standard Start Game Initialization Strategy needs exactly one player!";
        public const string StandardGameInvalidPlayFieldSize = "Standard Start Game Initialization Strategy needs 7x7 play field!";
    }
}
