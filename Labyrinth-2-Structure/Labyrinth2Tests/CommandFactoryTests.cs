using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.CommandFactory;
using Labyrinth.Core.Commands.MoveCommands;
using Labyrinth.Core.Commands;

namespace Labyrinth2Tests
{
    [TestClass]
    public class CommandFactoryTests
    {

        [TestMethod]
        public void CreateCommandShouldReturnMoveUP()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("u");
            Assert.AreEqual(typeof(MoveUp), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnMoveDown()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("d");
            Assert.AreEqual(typeof(MoveDown), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnMoveRight()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("r");
            Assert.AreEqual(typeof(MoveRight), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnMoveLeft()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("l");
            Assert.AreEqual(typeof(MoveLeft), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnRestart()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("restart");
            Assert.AreEqual(typeof(RestartCommand), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnTop()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("top");
            Assert.AreEqual(typeof(ScoreCommand), received.GetType());
        }

        [TestMethod]
        public void CreateCommandShouldReturnExit()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("exit");
            Assert.AreEqual(typeof(ExitCommand), received.GetType());
        }
        [TestMethod]
        public void CreateCommandShouldReturnUndo()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("undo");
            Assert.AreEqual(typeof(UndoCommand), received.GetType());
        }
    }
}
