using NUnit.Framework;

namespace HackerRunTests
{
    internal class SuperReducedStringTest
    {
        [Test]
        [TestCase("aaabccddd",
           ExpectedResult = "abd", TestName = "Test case 0")]
        [TestCase("abba",
           ExpectedResult = "Empty String", TestName = "Test case 1")]
        [TestCase("aaabccddd",
           ExpectedResult = "abd", TestName = "Test case 2")]
        [TestCase("abbceaa",
           ExpectedResult = "ace", TestName = "Test case 3")]
        public string Test(string input)
        {
            return SuperReducedString.Result.superReducedString(input);
        }
    }
}
