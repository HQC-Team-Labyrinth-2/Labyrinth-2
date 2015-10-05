using Labyrinth.Core.Common.Logger;

namespace Labyrinth.Core.GameEngine
{
    using System;
    using Labyrinth.Core.CommandFactory.Contracts;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Score;
    using Labyrinth.Core.Score.Contracts;
    using Labyrinth.Common.Contracts;

    public class StandardGameEngine : GameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly ILadder ladder;
        private ICommandFactory commandFactory;
        private ICommandContext commandContext;
        private ILogger logger;
        private int movesCount;

        public StandardGameEngine(
            IRenderer renderer, 
            IInputProvider inputProvider,
            IPlayField playField, 
            ICommandFactory commandFactory,
            ICommandContext commandContext,
            ILogger logger)
            : base(playField)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.ladder = Ladder.Instance;
            this.commandFactory = commandFactory;
            this.commandContext = commandContext;
            this.commandContext.PlayField = this.playField;
            this.logger = logger;
        }

        public override void Initialize(IRandomGenerator randomGenerator)
        {
            this.playField.Initialize(randomGenerator);
            this.movesCount = 0;
        }

        public override void Start()
        {
            string inputCommand = String.Empty;
            logger.Log("Start game");

            while (!this.IsGameOver(this.playField) && inputCommand != "restart")
            {
                this.renderer.PrintPlayField(this.playField);
                inputCommand = this.input.GetInput(this.renderer);
                ProccessInput(inputCommand);
            }

            if (inputCommand != "restart")
            {
                string congratulationMsg = String.Format(GlobalMessages.CongratulationMessage, this.movesCount);
                this.renderer.PrintMessage(congratulationMsg);

                if (ladder.ResultQualifiesInLadder(this.movesCount))
                {
                    this.renderer.PrintMessage(GlobalMessages.EnterNameForScoreBoardMessage);
                    string name = this.input.GetPlayerName();
                    ladder.AddResultInLadder(this.movesCount, name);
                }
            }
        }

        //TODO: validation for wall hit missing. The  game  should over when player hit the wall.
        private bool IsGameOver(IPlayField playField)
        {
            bool isGameOver = false;
            int currentRow = playField.PlayerPosition.Row;
            int currentCol = playField.PlayerPosition.Column;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Constants.StandardGameLabyrinthRows - 1 ||
                currentCol == Constants.StandardGameLabyrinthCols - 1)
            {
                isGameOver = true;
                logger.Log("Game over");
            }

            return isGameOver;
        }

        private void ProccessInput(string input)
        {
            string inputToLower = input.ToLower();

            ICommand command = this.commandFactory.CreateCommand(inputToLower);

            int move = command.Execute(this.commandContext);

            logger.Log("Executed command - "+command.GetName());
            this.movesCount += move;
        }
    }
}
