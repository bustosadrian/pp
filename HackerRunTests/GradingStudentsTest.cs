using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HackerRunTests
{
    internal class GradingStudentsTest : BaseHackerRankTest
    {
        [Test]
        [TestCase("4 73 67 38 33", TestName = "Test case 0")]
        public void Test(string input)
        {
            List<int> grades = ParseAll<int>(input).ToList();
            var result = GradingStudents.Result.gradingStudents(grades);

            result.Should().HaveCount(5);
            result.Should().Contain(4);
            result.Should().Contain(75);
            result.Should().Contain(67);
            result.Should().Contain(40);
            result.Should().Contain(33);
        }
    }
}
