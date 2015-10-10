using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Core.CommandFactory;
using Labyrinth.Core.Commands.MoveCommands;
using Labyrinth.Core.Commands;
using Labyrinth.Core.Helpers.CustomExceptions;

namespace Labyrinth2Tests
{
    [TestClass]
    public class CommandFactoryTests
    {

        [TestMethod]
        public void TestCreateCommandShouldReturnMoveUP()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("u");
            Assert.AreEqual(typeof(MoveUp), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnMoveDown()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("d");
            Assert.AreEqual(typeof(MoveDown), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnMoveRight()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("r");
            Assert.AreEqual(typeof(MoveRight), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnMoveLeft()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("l");
            Assert.AreEqual(typeof(MoveLeft), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnRestart()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("restart");
            Assert.AreEqual(typeof(RestartCommand), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnTop()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("top");
            Assert.AreEqual(typeof(ScoreCommand), received.GetType());
        }

        [TestMethod]
        public void TestCreateCommandShouldReturnExit()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("exit");
            Assert.AreEqual(typeof(ExitCommand), received.GetType());
        }
        [TestMethod]
        public void TestCreateCommandShouldReturnUndo()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("undo");
            Assert.AreEqual(typeof(UndoCommand), received.GetType());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void TestCreateCommandShouldReturnException()
        {
            var commandFactory = new SimpleCommandFactory();
            var received = commandFactory.CreateCommand("dsadsadas");
        }
    }
}
