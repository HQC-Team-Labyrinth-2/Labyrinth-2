using System.Collections.Generic;
using Labyrinth.Common.Contracts;
using Labyrinth.ConsoleUI.Input;
using Labyrinth.ConsoleUI.Output;
using Labyrinth.Core.CommandFactory;
using Labyrinth.Core.Common;
using Labyrinth.Core.Common.Contracts;
using Labyrinth.Core.Common.Logger;
using Labyrinth.Core.GameEngine;
using Labyrinth.Core.GameEngine.Contracts;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Input.Contracts;
using Labyrinth.Core.Output.Contracts;
using Labyrinth.Core.Player;
using Labyrinth.Core.Player.Contracts;
using Labyrinth.Core.PlayField;
using Labyrinth.Core.PlayField.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Labyrinth2Tests
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void TestGameEngineInitializeProperly()
        {
            Mock<IPlayField> mockPlayField = new Mock<IPlayField>();

            IGameEngine gameEngine = new StandardGameEngine(new ConsoleRender(new InfoPanel(),new PlayFieldPanel(),new TopScoresPanel()),new ConsoleInputProvider(new CommandReader(),new Menu()),mockPlayField.Object,new SimpleCommandFactory(), ConsoleLogger.Instance(), new Player("Test",new Cell(new Position(3,3))));

           gameEngine.Initialize(RandomNumberGenerator.Instance);

            mockPlayField.Verify(x=>x.InitializePlayFieldCells(It.IsAny<IRandomNumberGenerator>()),Times.Once);
        }
    }
}
