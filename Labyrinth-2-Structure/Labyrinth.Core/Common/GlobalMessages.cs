namespace Labyrinth.Core.Common
{
    /// <summary>
    /// This class contains the global messages as constants
    /// </summary>
    public class GlobalMessages
    {
        public const string EnterNameForScoreBoardMessage = "Please enter" +
           "your name for the top scoreboard: ";

        public const string GoodbyeMessage = "Good Bye";

        public const string GetInputMessage = "Enter your move (use the arrow keys and 'u' for undo): ";

        public const string WellcomeMessage = "Welcome to “Labirinth” game." +
            " The dashes are the cells that you can step on" +
            " and the X-es are the walls of the labyrinth." +
            " Your task is to escape with as few moves as possible." +
            " Good luck, fellow! " +
            " Use 't' to view the top scoreboard," +
            " 'r' to start a new game and 'e' to quit the game.";

        public const string CongratulationMessage = "Congratulations! You escaped in {0} moves.";
    }
}
