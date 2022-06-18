using NUnit.Framework;
using System.Collections.Generic;

namespace HackerRunTests
{
    public class QueensAttackTest : BaseHackerRankTest
    {
        private List<List<int>> ParseObstables(string[] obstacles)
        {
            List<List<int>> retval = new List<List<int>>();

            foreach (string o in obstacles)
            {
                if (o.Trim().Length == 0) continue;

                string[] ar = Split(o);
                List<int> obstacle = new List<int>()
                {
                    int.Parse(ar[0]),
                    int.Parse(ar[1])
                };
                retval.Add(obstacle);
            }

            return retval;
        }

        [Test]
        [TestCase("4 0", "4 4", "",
            ExpectedResult = 9, TestName = "Test case 0")]
        [TestCase("5 3", "4 3", "5 5", "4 2", "2 3",
            ExpectedResult = 10, TestName = "Test case 1")]
        [TestCase("88587 9", "20001 20003",
            "20001 20002", "20001 20004", "20000 20003",
            "20002 20003", "20000 20004", "20000 20002",
            "20002 20004", "20002 20002", "564 323",
            ExpectedResult = 0, TestName = "Test case 20")]
        public int Test(string boardDimensions, string queenPosition, params string[] obstables)
        {
            var n = Parse<int>(boardDimensions, 0);
            var k = Parse<int>(boardDimensions, 1);
            var r_q = Parse<int>(queenPosition, 0);
            var c_q = Parse<int>(queenPosition, 1);
            var obstacles = ParseObstables(obstables);

            return QueensAttack.Result.queensAttack(n, k, r_q, c_q, obstacles);
        }
    }
}
