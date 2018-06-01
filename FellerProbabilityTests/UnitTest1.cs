using FellerProbability;
using FluentAssertions;
using Xunit;

namespace FellerProbabilityTests
{
    public class FourNumbersSumTests
    {
        [Fact]
        public void GetAmount_UpToHundred_176851()
        {
            var alg = new FourNumbersSum();
            var amount = alg.GetAmount(100);
            amount.Should().Be(176851);
        }
    }
}
