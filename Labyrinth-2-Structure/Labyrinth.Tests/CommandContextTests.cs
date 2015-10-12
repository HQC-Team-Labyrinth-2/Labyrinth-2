using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Labyrinth.ConsoleUI.Output;
using Labyrinth.Core.Helpers;
using Labyrinth.Core.Helpers.Contracts;
using Labyrinth.Core.PlayField;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.Output.Contracts;
using Labyrinth.Core.Player;
using Labyrinth.Core.Player.Contracts;
using Labyrinth.Core.PlayField.Contracts;
using Labyrinth.Core.Score;
using Labyrinth.Core.Score.Contracts;

namespace Labyrinth.Tests
{
    [TestClass]
    public class CommandContextTests
    {
        private IPlayFieldGenerator generator;
        private IPosition playerPosition;
        private IPlayField playField;

        private IInfoRenderer infoPanel;
        private IPlayFieldRenderer PlayFieldPanel;
        private ILadderRenderer topScoresPanel;

        private IRenderer output;

        private IMementoCaretaker memory;

        private IScoreLadder ladder;

        private IPlayer player;

        private ICommandContext context;

        [TestInitialize]
        public void ClassInitialize()
        {
            playerPosition = new Position(3, 3);
            generator = new StandardPlayFieldGenerator(playerPosition, 9, 9);
            playField = new PlayField(generator, playerPosition, 9, 9);

            IInfoRenderer infoPanel = new InfoPanel();
            IPlayFieldRenderer playFieldPanel = new PlayFieldPanel();
            ILadderRenderer topScoresPanel = new TopScoresPanel();
            output = new ConsoleRender(infoPanel, playFieldPanel, topScoresPanel);
            
            memory = new MementoCaretaker(new List<IMemento>());

            ladder = ScoreLadder.Instance;

            player = new Player("test", new Cell(playerPosition));

            context = new CommandContext(playField, output, memory, ladder, player);
        }

        [TestMethod]
        public void TestPlayFieldGet()
        {
            Assert.AreEqual(playField, context.PlayField);
        }

        [TestMethod]
        public void TestOutputGet()
        {
            Assert.AreEqual(output, context.Output);
        }

        [TestMethod]
        public void TestMemoryGet()
        {
            Assert.AreEqual(memory, context.Memory);
        }

        [TestMethod]
        public void TestLadderGet()
        {
            Assert.AreEqual(ladder, context.Ladder);
        }

        [TestMethod]
        public void TestPlayerGet()
        {
            Assert.AreEqual(player, context.Player);
        }
    }
}
