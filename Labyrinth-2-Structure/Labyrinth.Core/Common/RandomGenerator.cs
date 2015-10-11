namespace Labyrinth.Core.Common
{
    using System;
    using Labyrinth.Common.Contracts;

    /// <summary>
    /// This class creates an instance of a RandomGenerator, when such is needed
    /// </summary>
    public class RandomGenerator : IRandomNumberGenerator
    {
        private static volatile RandomGenerator instance;
        private static object syncRoot = new object();
        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        /// <summary> RandomGenerator Instance is a property in the RandomGenartor class
        /// This property ensures the implementation of the Singleton design pattern.
        /// </summary>
        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null) 
                        { 
                            instance = new RandomGenerator();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Method for generating random number in given range.
        /// </summary>
        /// <param name="from">Minimum value for generation number.</param>
        /// <param name="to">Maximum value for generation number.</param>
        /// <returns>Random generated number in given range.</returns>
        public int GenerateNext(int from, int to)
        {
            return this.random.Next(from, to);
        }
    }
}
