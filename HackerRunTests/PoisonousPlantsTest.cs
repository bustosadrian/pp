using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRunTests
{
    internal class PoisonousPlantsTest : BaseHackerRankTest
    {
        
        [Test]
        [TestCase("7", "6 5 8 4 7 10 9 8",
            ExpectedResult = 3, TestName = "Custom case 0")]
        [TestCase("7", "6 5 8 4 7 10 8 9",
            ExpectedResult = 2, TestName = "Custom case 1")]
        [TestCase("7", "6 5 10 4 9 12 10 7 1",
            ExpectedResult = 3, TestName = "Custom case 2")]
        [TestCase("7", "6 5 8 4 7 10 9",
            ExpectedResult = 2, TestName = "Test case 0")]
        [TestCase("4", "3 2 5 4",
            ExpectedResult = 2, TestName = "Test case 1")]
        [TestCase("7", "4 3 7 5 6 4 2",
            ExpectedResult = 3, TestName = "Test case 2")]
        [TestCase("5", "1 1 1 1 1",
            ExpectedResult = 0, TestName = "Submit case 1")]
        public int Test(string length, string plants)
        {
            List<int> p = ParseAll<int>(plants).ToList();

            return PoisonousPlants.Result.poisonousPlantsV4(p);
        }

        //[Ignore("Timeout")]
        [TestCase(@"PoisonousPlants\Inputs\Test case X.txt",
            ExpectedResult = 49999, TestName = "Test case X")]
        public long TestFileInput(string fileName)
        {
            string[] input = ReadFromFile(fileName);
            List<int> p = ParseAll<int>(input[0]).ToList();

            return PoisonousPlants.Result.poisonousPlantsV4(p);
        }
    }
}
