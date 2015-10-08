using System.Collections.ObjectModel;
using System.Reflection;
using Labyrinth.Common.Contracts;
using Labyrinth.Core.CommandFactory;
using Labyrinth.Core.CommandFactory.Contracts;
using Labyrinth.Core.Commands;
using Labyrinth.Core.Commands.Contracts;
using Labyrinth.Core.Common;
using Labyrinth.Core.Common.Logger;
using Labyrinth.Core.GameEngine.Contracts;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Labyrinth.Core.Score;
using Labyrinth.Core.Score.Contracts;
namespace Labyrinth.Core
{
    using Ninject;

    public class LabyrinthFacade
    {
        public static void Start(IKernel kernel)
        {
            while (true)
            {
                //all this things done by Ninject IoC

                //IPosition playerPosition = new Position(Constants.StandardGameLabyrinthRows / 2, Constants.StandardGameLabyrinthCols / 2);

                //IPlayFieldGenerator generator = new StandardPlayFieldGenerator(playerPosition);

                //IPlayField playField = new PlayField.PlayField(generator, playerPosition);

                //ILadder ladder = Ladder.Instance;
                
                //ladder.Capacity = Constants.StandardGameTopResultCapacity;

                //ladder.OutputRenderer = output;

                //ICommandFactory commandFacory = new SimpleCommandFactory();

                //ICollection<IMemento> listOfStates = new List<IMemento>();

                //IMementoCaretaker memory = new MementoCaretaker(listOfStates);

                //ICommandContext commandContext = new CommandContext(playField,output,memory,ladder);

                //ILogger logger = ConsoleLogger.Instance(); 

                //IGameEngine gameEngine = new StandardGameEngine(output, input, playField, ladder,commandFacory,commandContext, logger);



                IRandomGenerator random = RandomGenerator.Instance;
                IGameEngine gameEngine = kernel.Get<IGameEngine>();
                gameEngine.Initialize(random);

                gameEngine.Start();
            }
        }
    }
}
