using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TheCoinChange;

namespace Tests
{
    public class TheCoinChangeTests
    {

        [Test]
        [TestCase("4  3", "1 2 3", 
            ExpectedResult = 4, TestName = "Test case 0")]
        [TestCase("10 4", "2 5 3 6", 
            ExpectedResult = 5, TestName = "Test case 1")]
        [TestCase("166 23", "5 37 8 39 33 17 22 32 13 7 10 35 40 2 43 49 46 19 41 1 12 11 28", 
            ExpectedResult = 96190959, TestName = "Test case 2")]
        [TestCase("15 24", "49 22 45 6 11 20 30 10 46 8 32 48 2 41 43 5 39 16 28 44 14 4 27 36", 
            ExpectedResult = 10, TestName = "Test case 6")]
        [TestCase("1 25", "48 6 34 50 49 36 30 35 40 41 17 43 39 13 4 20 19 2 46 7 38 33 28 18 21", 
            ExpectedResult = 0, TestName = "Test case 7")]
        [TestCase("2 27", "44 5 9 39 6 25 3 28 16 19 4 49 40 22 2 12 45 33 23 42 34 15 46 26 13 31 8", 
            ExpectedResult = 1, TestName = "Test case 8")]
        [TestCase("245 26", "16 30 9 17 40 13 42 5 25 49 7 23 1 44 4 11 33 12 27 2 38 24 28 32 14 50",
            ExpectedResult = 64027917156, TestName = "Test case 14")]
        public long Test(string sHeader, string sCoins)
        {
            string[] splittedHeader = sHeader.Split(" ");
            string[] splittedCoins = sCoins.Split(" ");

            int n = int.Parse(splittedHeader[0]);
            List<long> c = splittedCoins.Select(x => long.Parse(x)).ToList();

            return Result.getWays(n, c);
        }
    }
}
