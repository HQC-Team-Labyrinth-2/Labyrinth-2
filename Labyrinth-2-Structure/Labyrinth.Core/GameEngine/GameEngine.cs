namespace Labyrinth.Core.GameEngine
{
    using System;
    using Labyrinth.Core.GameEngine.Contracts;
    using Labyrinth.Core.Input.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;
    using Labyrinth.Core.Players.Contracts;
    using System.Collections.Generic;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.PlayField;
    using Labyrinth.Core.Score;
    using Labyrinth.Core.Score.Contracts;
    using Labyrinth.Common.Contracts;
    using Labyrinth.Core.Common.Contracts;
  

    public class StandardGameEngine : IGameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider input;    
        private readonly ILadder ladder;
        private IPlayField playField;
        private IPlayFieldGenerator labyrinthGenerator;

        private ICharacter player;
        private IPosition CurrentPlayerPosition;

        public StandardGameEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.ladder = Ladder.Instance;
            this.ladder.Capacity = Constants.StandardGameTopResultCapacity;
            this.ladder.OutputRenderer = renderer;
        }

        public ICharacter Player
        {
            get
            {
                return this.player;
            }
            private set
            {
                if (value != null)
                {
                    this.player = value;
                }
                else
                {
                    throw new ArgumentNullException("Player can't be null!");
                }
            }
        }

        public void Initialize()
        {
            IRandomGenerator random = RandomGenerator.Instance;

            IPlayFieldGenerator labyrinthGenerator = new StandardPlayFieldGenerator(new Position(Constants.StandardGameLabyrinthRows / 2, Constants.StandardGameLabyrinthCols / 2));
            this.playField = new PlayField(labyrinthGenerator,new Position(Constants.StandardGameLabyrinthRows / 2, Constants.StandardGameLabyrinthCols / 2));
            this.playField.Initialize(random);
        }

        public void Start()
        {
            int movesCount = 0;

            string inputCommand = String.Empty;

            while (!this.IsGameOver(this.playField) && inputCommand != "restart")
            {
                this.renderer.PrintPlayField(this.playField);
                inputCommand = this.input.GetInput(this.renderer);
                ProccessInput(inputCommand, playField, ref movesCount, this.ladder);
            }

            if (inputCommand != "restart")
            {
                string congratulationMsg = String.Format(GlobalMessages.CongratulationMessage, movesCount);
                this.renderer.PrintMessage(congratulationMsg);

                if (ladder.ResultQualifiesInLadder(movesCount))
                {
                    this.renderer.PrintMessage(GlobalMessages.EnterNameForScoreBoardMessage);
                    string name = this.input.GetPlayerName();
                    ladder.AddResultInLadder(movesCount, name);
                }
            }

            Console.WriteLine();
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
            }

            return isGameOver;
        }

        private bool TryMove(string direction, IPlayField playField)
        {
            bool moveDone = false;
            switch (direction)
            {
                case "u":
                    moveDone =
                        playField.TryMove(playField.GetCell(playField.PlayerPosition), Direction.Up);
                    break;
                case "d":
                    moveDone =
                        playField.TryMove(playField.GetCell(playField.PlayerPosition), Direction.Down);
                    break;
                case "l":
                    moveDone =
                        playField.TryMove(playField.GetCell(playField.PlayerPosition), Direction.Left);
                    break;
                case "r":
                    moveDone =
                        playField.TryMove(playField.GetCell(playField.PlayerPosition), Direction.Right);
                    break;
                default:
                    this.renderer.PrintMessage(GlobalErrorMessages.InvalidMoveMessage);
                    break;
            }

            if (moveDone == false)
            {
                this.renderer.PrintMessage(GlobalErrorMessages.InvalidMoveMessage);
            }

            return moveDone;
        }

        //TODO: Implement a command pattern for processing input. 
        private void ProccessInput(
            string input,
            IPlayField playField,
            ref int movesCount,
            ILadder ladder)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    //fallthrough
                    bool moveDone =
                        this.TryMove(inputToLower, playField);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }

                    break;
                case "top":
                    renderer.Show((IContentProvider)ladder);
                    break;
                case "exit":
                    this.renderer.PrintMessage(GlobalMessages.GoodbyeMessage);
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    this.renderer.PrintMessage(GlobalErrorMessages.InvalidCommandMessage);
                    break;
            }
        }

        public IEnumerable<ICharacter> Players
        {
            get { throw new NotImplementedException(); }
        }
    }
}
