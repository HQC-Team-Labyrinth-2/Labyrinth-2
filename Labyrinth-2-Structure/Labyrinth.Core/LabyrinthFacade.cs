using System;

namespace Labyrinth.Core
{
    using System.Collections.Generic;
    using Labyrinth.Core.CommandFactory;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Logger;
    using Labyrinth.Core.GameEngine;
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField;
    using Labyrinth.Core.PlayField.Contracts;

    public class LabyrinthFacade
    {
        public static void Start(IRenderer output, IInputProvider input, ILogger logger)
        {
            output.ShowInfoMessage("Please ente your name: ");
            string playerName = input.GetPlayerName();

            output.ShowInfoMessage("Please enter a dimension for the board the standard is 9x9");
            int dimension = input.GetPlayFieldDimensions();

            ICell playerCell = new Cell(new Position(dimension / 2, dimension / 2));
            IPlayField playField=null;
            var player = new Player.Player(playerName, playerCell);
            try
            {
                var playFieldGenerator = new StandardPlayFieldGenerator(player.CurentCell.Position, dimension, dimension);
                playField = new PlayField.PlayField(playFieldGenerator, player.CurentCell.Position, dimension, dimension);
            }
            catch (ArgumentOutOfRangeException)
            {
                output.ShowInfoMessage("Please enter a play field dimension greater than 2!");
            }
            var commandFactory = new SimpleCommandFactory();
            IGameEngine gameEngine = new StandardGameEngine(output, input, playField, commandFactory, logger, player);
            gameEngine.Initialize(RandomNumberGenerator.Instance);
            gameEngine.Start();
        }
    }
}
