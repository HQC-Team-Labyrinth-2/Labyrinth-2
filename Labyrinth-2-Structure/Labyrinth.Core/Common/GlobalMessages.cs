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

        public const string GetInputMessage = "Enter your move (l for left," +
            "r  for right, u for up, d for down and undo): ";

        public const string WellcomeMessage = "Welcome to “Labirinth” game." +
            " Your task is to escape from the labyrinth with as few moves as possible." +
            " Use 'top' to view the top scoreboard," +
            " 'restart' to start a new game and 'exit' to quit the game.";

        public const string CongratulationMessage = "Congratulations! You escaped in {0} moves.";
    }
}
