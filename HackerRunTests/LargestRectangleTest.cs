using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRunTests
{
    internal class LargestRectangleTest : BaseHackerRankTest
    {
        [Test]
        [TestCase("5",
            "1 2 3 4 5",
            ExpectedResult = 9, TestName = "Test case 0")]
        [TestCase("6",
            "2 3 1 2 1 3",
            ExpectedResult = 6, TestName = "Test case Custom 1")]
        [TestCase("6",
            "12 3 2 2 4 4 1 1 1",
            ExpectedResult = 12, TestName = "Test case Custom 2")]
        [TestCase("38",
            "9 8 8 2 3 2 1 6 4 5 1 2 4 5 7 7 7 3 7 7 2 1 1 1 1 1 1 1 2 4 5 9 9 9 3 7 7 2",
            ExpectedResult = 38, TestName = "Test case Custom 3")]
        public long Test(params string[] input)
        {
            List<int> heights = input[1].Split(" ").Select(x => int.Parse(x)).ToList();

            return LargestRectangle.Result.largestRectangle(heights);
        }

        [TestCase(@"LargestRectangle\Inputs\Test case 6.txt",
            ExpectedResult = 10558350, TestName = "Test case 6")]
        public long TestFileInput(string fileName)
        {
            string[] input = ReadFromFile(fileName);
            List<int> heights = input[1].Split(" ").Select(x => int.Parse(x)).ToList();

            return LargestRectangle.Result.largestRectangle(heights);
        }
    }
}
