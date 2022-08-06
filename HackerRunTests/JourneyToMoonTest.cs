using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HackerRunTests
{
    public class JourneyToMoonTest : BaseHackerRankTest
    {
        [Test]
        [TestCase("5 3", 
            "0 1", "2 3", "0 4",
            TestName = "Sample 0",
            ExpectedResult = 6)]
        [TestCase("4 1",
            "0 2",
            TestName = "Sample 1",
            ExpectedResult = 5)]
        [TestCase("4 1",
            "0 2", "1 1", "3 3",
            TestName = "Sample Custom 0",
            ExpectedResult = 5)]
        [TestCase("4 1",
            "0 2", "1 1",
            TestName = "Sample Custom 1",
            ExpectedResult = 5)]
        [TestCase("4 1",
            "0 1", "0 2", "0 3",
            TestName = "Sample Custom 2",
            ExpectedResult = 0)]
        public int InputTests(string header, params string[] astronauts)
        {
            int n = Parse<int>(header, 0);
            List<List<int>> astronaut = astronauts
                .Select(x => ParseAll<int>(x).ToList()).ToList();

            return JourneyToMoon.Result.journeyToMoon(n, astronaut);
        }
    }
}
