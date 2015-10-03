using Labyrinth.Common.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Labyrinth.Core.Score;
using Labyrinth.Core.Score.Contracts;

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
                IPosition playerPosition = new Position(Constants.StandardGameLabyrinthRows / 2, Constants.StandardGameLabyrinthCols / 2);

                IPlayFieldGenerator generator = new StandardPlayFieldGenerator(playerPosition);

                IPlayField playField = new PlayField.PlayField(generator, playerPosition);

                ILadder ladder = Ladder.Instance;
                
                ladder.Capacity = Constants.StandardGameTopResultCapacity;

                ladder.OutputRenderer = output;

                StandardGameEngine gameEngine = new StandardGameEngine(output, input, playField, ladder);

                IRandomGenerator random = RandomGenerator.Instance;

                gameEngine.Initialize(random);

                gameEngine.Start();
            }
        }
    }
}
