using System.Runtime.Serialization.Formatters.Binary;
using Labyrinth.Core.Player.Contracts;

namespace Labyrinth.Core
{
    using System.Collections.Generic;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.CommandFactory;
    using Labyrinth.Core.CommandFactory.Contracts;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score.Contracts;
    using Labyrinth.Core.Score;
    using Labyrinth.Core.Commands;
    using Labyrinth.Core.GameEngine;
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.Common.Logger;
    using Ninject.Modules;

    public class Bindings:NinjectModule
    {
        public override void Load()
        {
            //Bind<IPlayer>().To<Player.Player>();
            //Bind<IPosition>().To<Position>();
            //Bind<IPlayFieldGenerator>().To<StandardPlayFieldGenerator>();
            //Bind<IPlayField>().To<PlayField.PlayField>();
            //Bind<ICell>().To<Cell>();
            //Bind<IRandomGenerator>().ToConstant(RandomGenerator.Instance);
            //Bind<ILadder>().ToConstant(Ladder.Instance);
            //Bind<ICommandFactory>().To<SimpleCommandFactory>();
            //// Bind<IMemento>().To<PlayFieldMemento>();
            //Bind<ICollection<IMemento>>().To<List<IMemento>>();
            //Bind<IMementoCaretaker>().To<MementoCaretaker>();
            //Bind<ICommandContext>().To<CommandContext>();
            //Bind<ILogger>().ToConstant(FileLogger.Instance());
            //Bind<IGameEngine>().To<StandardGameEngine>();
            
        }
    }
}
