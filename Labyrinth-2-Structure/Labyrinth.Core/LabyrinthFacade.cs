namespace Labyrinth.Core
{
    using System.Collections.Generic;
    using Labyrinth.Core.CommandFactory;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Logger;
    using Labyrinth.Core.GameEngine;
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField;

    public class LabyrinthFacade
    {
        public static void Start(IRenderer output, IInputProvider input, ILogger logger)
        {
            IList<IPlayer> players = new List<IPlayer>();

            var player = new Player.Player("goran", new Cell(new Position()));
            var player2 = new Player.Player("hhhh", new Cell(new Position()));
            players.Add(player);
            players.Add(player2);
            var playFieldGenerator = new StandardPlayFieldGenerator(player.CurentCell.Position);
            var playField = new PlayField.PlayField(playFieldGenerator, player.CurentCell.Position);
            var commandFactory = new SimpleCommandFactory();
            IGameEngine gameEngine = new StandardGameEngine(output, input, playField, commandFactory, logger, player);
            gameEngine.Initialize(RandomGenerator.Instance);
            gameEngine.Start();
        }
    }
}
