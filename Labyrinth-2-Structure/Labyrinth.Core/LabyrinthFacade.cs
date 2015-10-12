namespace Labyrinth.Core
{
    using System;
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

    /// <summary>
    /// Facade class for the main logic
    /// </summary>
    public class LabyrinthFacade
    {
        /// <summary>
        /// Method that start the main logic of the game.
        /// </summary>
        /// <param name="output">Output renderer</param>
        /// <param name="input">Iput provider</param>
        /// <param name="cmmandLogger">Command logger</param>
        public static void Start(IRenderer output, IInputProvider input, ILogger cmmandLogger)
        {
            output.ShowInfoMessage("Please ente your name: ");
            string playerName = input.GetPlayerName();

            output.ShowInfoMessage("Please enter a dimension for the board the standard is 9x9");
            int dimension = input.GetPlayFieldDimensions();

            ICell playerCell = new Cell(new Position(dimension / 2, dimension / 2));
            IPlayField playField = null;
            var player = new Player.Player(playerName, playerCell);

            try
            {
                var playFieldGenerator = new StandardPlayFieldGenerator(player.CurentCell.Position, dimension, dimension);
                playField = new PlayField.PlayField(playFieldGenerator, player.CurentCell.Position, dimension, dimension);
            }
            catch (ArgumentOutOfRangeException e)
            {
                output.ShowInfoMessage(e.Message);
            }

            var commandFactory = new SimpleCommandFactory();
            IGameEngine gameEngine = new StandardGameEngine(output, input, playField, commandFactory, cmmandLogger, player);
            gameEngine.Initialize(RandomNumberGenerator.Instance);
            gameEngine.Start();
        }
    }
}
