using System.Collections.Generic;
using System.Text;
using Xunit;
using yesenin.algs.Strings;

namespace yesenin.algs.Tests.Strings
{
    public class TwoStringsTests
    {
        [Theory]
        [InlineData("and now ", "now something", "and now something")]
        [InlineData("and now", " now something", "and now something")]
        [InlineData("and now", "now something", "and now something")]
        [InlineData("and now", "ow something", "and now something")]
        [InlineData("and ", "now", "and now")]
        public void MergeTest(string a, string b, string expected)
        {
            var actual = TwoStrings.Merge(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeLinesTest()
        {
            var lines = new List<string>()
            {
                "etely different",
                "something completely ",
                "And now so",
            };
            var expected = "And now something completely different";

            var result = "";
            for (var i = 0; i < lines.Count; i++)
            {
                result = TwoStrings.Merge(lines[i], result);
            }
            
            Assert.Equal(expected, result);
        }
    }
}