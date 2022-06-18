using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRunTests
{
    internal class AppleAndOrangeTest : BaseHackerRankTest
    {
        
        [Test]
        [TestCase("7 11", "5 15", "3 2", 
            "-2 2 1",
            "5 -6", 
            TestName = "Test case 0")]
        [TestCase("2 3", "1 5", "1 1",
            "2",
            "-2",
            TestName = "Test case 1")]
        public void Test(string samsHouse, string treesLocation, string fruitCount, string applesPosition, string orangesPosition)
        {
            var s = Parse<int>(samsHouse, 0);
            var t = Parse<int>(samsHouse, 1);
            var a = Parse<int>(treesLocation, 0);
            var b = Parse<int>(treesLocation, 1);
            List<int> apples = ParseAll<int>(applesPosition).ToList();
            List<int> oranges = ParseAll<int>(orangesPosition).ToList();
            
            AppleAndOrange.Result.countApplesAndOranges(s, t, a, b, apples, oranges);
        }
    }
}
