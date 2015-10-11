using System;
using System.Collections.Generic;
using Labyrinth.Common.Contracts;
using Labyrinth.Core.Common;
using Moq;

namespace Labyrinth2Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RandomNumberGeneratorTests
    {
        [TestMethod]
        public void TestGenerateNextShouldNoProduceNumberLessThanMinValue()
        {
            IRandomNumberGenerator numberGenerator = RandomNumberGenerator.Instance;
            int min = 1;
            int generatedNumber;

            for (int i = 0; i < 10000; i++)
            {
                generatedNumber = numberGenerator.GenerateNext(1, 10);
                if (generatedNumber < min)
                {
                    min = generatedNumber;
                }
            }

            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void TestRandNumberGeneratorNotProduceNumberGreaterThanMaxValue()
        {
             IRandomNumberGenerator numberGenerator = RandomNumberGenerator.Instance;
            int max = 10;
            int generated;

            for (int i = 0; i < 10000; i++)
            {
                generated = numberGenerator.GenerateNext(1,10);
                if (generated > max)
                {
                    max = generated;
                }
            }

            Assert.AreEqual(10, max);
        }

        [TestMethod]
        public void TestRandNumberGeneratorShouldAlwaysReturnRandomNumbers()
        {
            var hashSet = new HashSet<int>();
            IRandomNumberGenerator numberGenerator = RandomNumberGenerator.Instance;

            for (int i = 0; i < 10000; i++)
            {
                hashSet.Add(numberGenerator.GenerateNext(1, 10));
            }

            Assert.AreEqual(10, hashSet.Count);
        }     
    }
}
