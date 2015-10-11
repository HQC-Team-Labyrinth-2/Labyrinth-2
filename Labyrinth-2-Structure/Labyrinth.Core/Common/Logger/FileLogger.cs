namespace Labyrinth.Core.Common.Logger
{
    using System;
    using System.IO;

    /// <summary>
    /// File logger class.
    /// </summary>
    public sealed class FileLogger : ILogger
    {
        /// <summary>
        /// Singleton file logger class.
        /// </summary>
        private static FileLogger logger = null;

        /// <summary>
        /// Private constructor for FileLogger class.
        /// </summary>
        private FileLogger()
        {
        }

        /// <summary>
        /// Method that returns the instance of the FileLogger.
        /// </summary>
        /// <returns>FileLogger instance.</returns>
        public static FileLogger Instance()
        {
            if (logger == null)
            {
                logger = new FileLogger();
            }

            return logger;
        }

        /// <summary>
        /// Method for logging message in file.
        /// </summary>
        /// <param name="message">Message that wants to be logged.</param>
        public void Log(string message)
        {
            string fileName = "log.txt";

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, message);
            }

            string textToLog = string.Format("Time:{0} Message:{1}" + System.Environment.NewLine, DateTime.Now, message);
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + fileName, textToLog);
        }
    }
}
