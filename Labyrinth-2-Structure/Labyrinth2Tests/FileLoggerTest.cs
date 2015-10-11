using System;
using System.IO;
using System.Reflection;
using Labyrinth.Core.Common.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth2Tests
{
    [TestClass]
    public class FileLoggerTest
    {
        private ILogger logger;

        [TestMethod]
        public void ValidateFileOutput()
        {
            logger = FileLogger.Instance();
            logger.Log("test");
            var isFileExists = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "log.txt");
            Assert.IsTrue(isFileExists);
        }
    }
}
