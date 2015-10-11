using System;
using System.IO;
using Labyrinth.Core.Common.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth2Tests
{
    [TestClass]
    public class ConsoleLoggerTests
    {
        private ILogger logger;

        [TestMethod]
        public void ValidateConsoleOutput()
        {
            logger = ConsoleLogger.Instance();
            string message = "test";
            string splitter = "Message:";
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                logger.Log(message);
                string messageFromLog = sw.ToString().Split(new string[] { splitter }, StringSplitOptions.None)[1];
                string expected = string.Format(message + Environment.NewLine);
                Assert.AreEqual<string>(expected, messageFromLog.ToString());
            }
        }
    }
}
