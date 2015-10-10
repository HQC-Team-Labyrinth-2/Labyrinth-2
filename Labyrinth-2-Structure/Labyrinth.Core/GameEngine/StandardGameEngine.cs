using Labyrinth.Core.GameEngine.Contracts;

namespace Labyrinth.Core.GameEngine
{
    using System.Collections.Generic;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.CommandFactory.Contracts;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Common.Logger;
    using Labyrinth.Core.Helpers;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Helpers.CustomExceptions;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.Player.Contracts;
    using Labyrinth.Core.PlayField;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score;
    using Labyrinth.Core.Score.Contracts;

    public class StandardGameEngine : IGameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IScoreLadder ladder;
        private ICommandFactory commandFactory;
        private ICommandContext commandContext;
        private ILogger logger;
        private MementoCaretaker memory;
        private IPlayer player;
        private IPlayField playField;

        public StandardGameEngine(
            IRenderer renderer,
            IInputProvider inputProvider,
            IPlayField playField,
            ICommandFactory commandFactory,
            ILogger logger,
            IPlayer player)
        {
            this.playField = playField;
            this.renderer = renderer;
            this.input = inputProvider;
            this.ladder = ScoreLadder.Instance;
            this.commandFactory = commandFactory;
            this.logger = logger;
            this.player = player;
            this.memory = new MementoCaretaker(new List<IMemento>());
        }

        public void Initialize(IRandomGenerator randomGenerator)
        {
            this.playField.InitializePlayFieldCells(randomGenerator);
        }

        public void Start()
        {
            string inputCommand = string.Empty;
            this.logger.Log("Start game");
            this.renderer.ShowInfoMessage(GlobalMessages.WellcomeMessage);

            while (true)
            {
                this.renderer.ShowPlayField(this.playField);
                inputCommand = this.input.GetCommand();
                try
                {
                    this.ProccessInput(inputCommand);
                }
                catch (InvalidPlayerPositionException e)
                {
                    this.renderer.ShowInfoMessage(e.Message);
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
                    this.renderer.ShowInfoMessage(e.Message);
                }

                if (this.PlayerWin())
                {
                    string congratulationMsg = string.Format(GlobalMessages.CongratulationMessage, this.player.MovesCount);
                    this.renderer.ShowInfoMessage(congratulationMsg);

                    if (this.ladder.ResultQualifiesInLadder(this.player.MovesCount))
                    {
                        this.renderer.ShowInfoMessage(GlobalMessages.EnterNameForScoreBoardMessage);
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
                currentRow == this.playField.NumberOfRows - 1 ||
                currentCol == this.playField.NumberOfCols - 1)
            {
                isGameOver = true;
                this.logger.Log("Game over");
            }

            return isGameOver;
        }

        private void ProccessInput(string input)
        {
            this.commandContext = new CommandContext(this.playField, this.renderer, this.memory, this.ladder, this.player);
            string inputToLower = input.ToLower();

            ICommand command = this.commandFactory.CreateCommand(inputToLower);

            command.Execute(this.commandContext);

            this.logger.Log("Executed command - " + command.GetName());
        }

        private bool PlayerWantNewGame()
        {
            this.renderer.ShowInfoMessage("Do you want to restart the game?y/n ");
            string inputCommand = this.input.GetCommand().ToLower();
            if (string.Equals(inputCommand, "y"))
            {
                return true;
            }

            return false;
        }
    }
}
