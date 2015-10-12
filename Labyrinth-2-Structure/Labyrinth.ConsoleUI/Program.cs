namespace Labyrinth.ConsoleUI
{
    using Labyrinth.ConsoleUI.Input;
    using Labyrinth.ConsoleUI.Output;
    using Labyrinth.Core;
    using Labyrinth.Core.Common.Logger;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    
    public class Program
    {
        private static void Main()
        {
            ICommandInputProvider commandInput = new CommandReader();
            IInfoInputProvider menuInput = new Menu();
            IInputProvider inputProvider = new ConsoleInputProvider(commandInput, menuInput);

            IInfoRenderer infoPanel = new InfoPanel();
            IPlayFieldRenderer playFieldPanel = new PlayFieldPanel();
            ILadderRenderer topScoresPanel = new TopScoresPanel();
            IRenderer consoleRenderer = new ConsoleRender(infoPanel, playFieldPanel, topScoresPanel);

            LabyrinthFacade.Start(consoleRenderer, inputProvider, FileLogger.Instance());
        }
    }
}
