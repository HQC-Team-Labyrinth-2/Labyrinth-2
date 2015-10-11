namespace Labyrinth.Core.Common.Logger
{
    using System;

    /// <summary>
    /// Singleton console logger class.
    /// </summary>
    public sealed class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Instance of the ConsoleLogger class.
        /// </summary>
        private static ConsoleLogger logger = null;

        /// <summary>
        /// Private constructor for ConsoleLogger class.
        /// </summary>
        private ConsoleLogger()
        {
        }

        /// <summary>
        /// Method that returns the instance of the ConsoleLoger.
        /// </summary>
        /// <returns>ConsoleLogger instance.</returns>
        public static ConsoleLogger Instance()
        {
            if (logger == null)
            {
                logger = new ConsoleLogger();
            }

            return logger;
        }

        /// <summary>
        /// Method that log time and message on the console.
        /// </summary>
        /// <param name="message">Message that want to be log on the console.</param>
        public void Log(string message)
        {
            Console.WriteLine("Time:{0} Message:{1}", DateTime.Now, message);
        }
    }
}
