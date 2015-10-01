namespace Labyrinth.Core.Common
{
    using System;
    using Labyrinth.Common.Contracts;

    public class RandomGenerator : IRandomGenerator
    {
        private Random random;
        private static volatile RandomGenerator instance;
        private static object syncRoot = new Object();

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RandomGenerator();
                    }
                }

                return instance;
            }
        }

        public int GenerateNext(int from, int to)
        {
            return this.random.Next(from, to);
        }
    }
}
