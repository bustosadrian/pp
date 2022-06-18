using NUnit.Framework;

namespace HackerRunTests
{
    internal class NumberLineJumpsTest : BaseHackerRankTest
    {
        [Test]
        [TestCase("0 2 5 3", 
            ExpectedResult = "NO", TestName = "Test case 0")]
        [TestCase("21 6 47 3",
            ExpectedResult = "NO", TestName = "Test case 1")]
        public string Test(string text)
        {
            int x1 = Parse<int>(text, 0);
            int v1 = Parse<int>(text, 1);
            int x2 = Parse<int>(text, 2);
            int v2 = Parse<int>(text, 2);

            return NumberLineJumps.Result.kangaroo(x1, v1, x2, v2);
        }
    }
}
