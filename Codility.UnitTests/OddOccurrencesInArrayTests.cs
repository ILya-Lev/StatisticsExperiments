using FluentAssertions;
using Xunit;

namespace Codility.UnitTests
{
    public class OddOccurrencesInArrayTests
    {
        [Fact]
        public void GetUnpairedOddInteger_UnpairedNumberPresent_Find()
        {
            var solver = new OddOccurrencesInArray();
            var source = new[] { 1, 5, 1, 3, 1, 7, 3, 5, 1 };

            var unpairedNumber = solver.GetUnpairedOddInteger(source);

            unpairedNumber.Should().Be(7);
        }

        [Fact]
        public void GetUnpairedOddInteger_Triplet_Find()
        {
            var solver = new OddOccurrencesInArray();
            var source = new[] { 1, 5, 1, 3, 3, 5, 1 };

            var unpairedNumber = solver.GetUnpairedOddInteger(source);

            unpairedNumber.Should().Be(1);
        }
    }
}
