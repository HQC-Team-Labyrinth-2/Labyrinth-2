namespace Labyrinth.Core
{
    using Labyrinth.Core.GameEngine;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
  
    public class LabyrinthFacade
    {
        public static void Start(IRenderer output, IInputProvider input)
        {
            while (true)
            {
                StandardGameEngine gameEngine = new StandardGameEngine(output, input);

                gameEngine.Initialize();

                gameEngine.Start();
            }
        }
    }
}
