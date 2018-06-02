using FellerProbability;
using FluentAssertions;
using Xunit;

namespace FellerProbabilityTests
{
    public class SmokingSampleFactory
    {
        public FourNumbersSum FourNumbersSum { get; }

        public SmokingSampleFactory()
        {
            FourNumbersSum = new FourNumbersSum(100);
        }
    }

    public class FourNumbersSumTests : IClassFixture<SmokingSampleFactory>
    {
        private readonly FourNumbersSum _fourNumbersSum;

        public FourNumbersSumTests(SmokingSampleFactory sampleFactory)
        {
            _fourNumbersSum = sampleFactory.FourNumbersSum;
        }

        [Fact]
        public void GetAmount_UpToHundred_176851()
        {
            var amount = _fourNumbersSum.GetAmount();
            amount.Should().Be(176851);
        }

        [Fact]
        public void SmokingManMoreThanWomanAmount_100_HalfOfAll()
        {
            var all = _fourNumbersSum.GetAmount();
            var amount = _fourNumbersSum.SmokingManMoreThanWomanAmount();
            amount.Should().Be(all / 2);
        }
    }
}
