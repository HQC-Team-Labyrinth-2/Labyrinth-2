using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Common.Logger
{
    public sealed class FileLogger
    {
        private static FileLogger logger = null;

        private FileLogger()
        {
        }

        public static FileLogger Instance()
        {
            if (logger == null)
            {
                logger = new FileLogger();
            }
            return logger;
        }

        public void Log(string message)
        {
            String textToLog = String.Format("Time:{0} Message:{1}\n", DateTime.Now, message);
            File.AppendAllText("log.txt", textToLog);
        }
    }
}
