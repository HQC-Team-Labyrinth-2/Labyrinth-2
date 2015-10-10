﻿namespace Labyrinth.Core.CommandFactory
{
    using System.Collections.Generic;
    using Labyrinth.Core.CommandFactory.Contracts;
    using Labyrinth.Core.Commands;
    using Labyrinth.Core.Commands.Contracts;
    using Labyrinth.Core.Commands.MoveCommands;
    using Labyrinth.Core.Common;
    using Labyrinth.Core.Helpers.CustomExceptions;

    public class SimpleCommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, ICommand> commandDictionary;

        public SimpleCommandFactory()
        {
            this.commandDictionary = new Dictionary<string, ICommand>();
        }

        public ICommand CreateCommand(string command)
        {
            ICommand resultCommand;

            if (this.commandDictionary.ContainsKey(command))
            {
                return this.commandDictionary[command];
            }

            switch (command)
            {
                case "u":
                    resultCommand = new MoveUp();
                    break;
                case "d":
                    resultCommand = new MoveDown();
                    break;
                case "l":
                    resultCommand = new MoveLeft();
                    break;
                case "r":
                    resultCommand = new MoveRight();
                    break;
                case "restart":
                    resultCommand = new RestartCommand();
                    break;
                case "top":
                    resultCommand = new ScoreCommand();
                    break;
                case "exit":
                    resultCommand = new ExitCommand();
                    break;
                case "undo":
                    resultCommand = new UndoCommand();
                    break;
                default:
                    throw new InvalidCommandException(GlobalErrorMessages.InvalidCommandMessage);
            }

            this.commandDictionary.Add(command, resultCommand);
            return resultCommand;
        }
    }
}
