using FluentAssertions;
using System;
using Xunit;

namespace MonteCarlo.UnitTests
{
    public class HeirBirthSimulationTests
    {
        [InlineData(1000)]
        [InlineData(10_000)]
        [InlineData(100_000)]
        [InlineData(1_000_000)]
        [Theory]
        public void Simulate_Many_FiftyFifty(int amountOfFamilies)
        {
            var simulation = new HeirBirthSimulation(50, 20);
            var rate = simulation.Simulate(amountOfFamilies);

            var precision = 3 / Math.Sqrt(amountOfFamilies);
            rate.Should().BeApproximately(1.0, precision);
        }
    }
}
