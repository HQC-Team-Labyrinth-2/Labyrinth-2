using System;
using Labyrinth.Core.Helpers;

namespace Labyrinth.Core.GameEngine
{
    using System.Collections.Generic;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.CommandFactory.Contracts;
    using Labyrinth.Core.Commands;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Logger;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score;
    using Labyrinth.Core.Score.Contracts;

    public class StandardGameEngine : GameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly ILadder ladder;
        private ICommandFactory commandFactory;
        private ICommandContext commandContext;
        private ILogger logger;
        private MementoCaretaker memory;
        private ICommandContext context;
        private IPlayer player;

        public StandardGameEngine(
            IRenderer renderer,
            IInputProvider inputProvider,
            IPlayField playField,
            ICommandFactory commandFactory,
           ILogger logger, IPlayer player)
            : base(playField)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.ladder = Ladder.Instance;
            this.commandFactory = commandFactory;
            this.logger = logger;
            this.player = player;
            this.memory = new MementoCaretaker(new List<IMemento>());
        }

        public override void Initialize(IRandomGenerator randomGenerator)
        {
            this.PlayField.InitializePlayFieldCells(randomGenerator);
        }

        public override void Start()
        {
            string inputCommand = string.Empty;
            this.logger.Log("Start game");
            this.renderer.PrintMessage(GlobalMessages.WellcomeMessage);

            while (true)
            {
                this.renderer.PrintPlayField(this.PlayField);
                inputCommand = this.input.GetInput(this.renderer);
                try
                {
                    this.ProccessInput(inputCommand);
                }
                catch (InvalidPlayerPositionException e)
                {
                    this.renderer.PrintMessage(e.Message);
                    if (this.PlayerWantNewGame())
                    {
                        this.ProccessInput("restart");
                    }
                    else
                    {
                       this.ProccessInput("exit");
                    }

                }
                catch (InvalidCommandException e)
                {
                    this.renderer.PrintMessage(e.Message);
                }

                if (PlayerWin())
                {
                    string congratulationMsg = string.Format(GlobalMessages.CongratulationMessage, this.player.MovesCount);
                    this.renderer.PrintMessage(congratulationMsg);

                    if (this.ladder.ResultQualifiesInLadder(this.player.MovesCount))
                    {
                        this.renderer.PrintMessage(GlobalMessages.EnterNameForScoreBoardMessage);
                        string name = this.input.GetPlayerName();
                        this.ladder.AddResultInLadder(this.player.MovesCount, name);
                    }

                    if (this.PlayerWantNewGame())
                    {
                        this.ProccessInput("restart");
                    }
                    else
                    {
                       this.ProccessInput("exit");
                    }
                }


            }
        }

        private bool PlayerWin()
        {
            bool isGameOver = false;
            int currentRow = this.player.CurentCell.Position.Row;
            int currentCol = this.player.CurentCell.Position.Column;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Constants.StandardGameLabyrinthRows - 1 ||
                currentCol == Constants.StandardGameLabyrinthCols - 1)
            {
                isGameOver = true;
                this.logger.Log("Game over");
            }

            return isGameOver;
        }

        private void ProccessInput(string input)
        {
            this.commandContext = new CommandContext(this.PlayField, this.renderer, this.memory, this.ladder, this.player);
            string inputToLower = input.ToLower();

            ICommand command = this.commandFactory.CreateCommand(inputToLower);

            command.Execute(this.commandContext);

            this.logger.Log("Executed command - " + command.GetName());
        }

        private bool PlayerWantNewGame()
        {
            this.renderer.PrintMessage("Do you want to restart the game?y/n ");
            string inputCommand = this.input.GetCommand().ToLower();
            if (string.Equals(inputCommand, "y"))
            {
                return true;
            }
            return false;
        }
    }
}
