using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace MonteCarlo.UnitTests
{
    public class NeedleThrowingSimulationTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public NeedleThrowingSimulationTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [InlineData(10_000)]
        [InlineData(100_000)]
        [Theory]
        public void Simulate_Many_PiDividedByTen(int amount)
        {
            var simulation = new NeedleThrowingSimulation();

            var probability = simulation.Simulate(amount);


            _outputHelper.WriteLine($"{probability * 10}");
            var precision = 1 / Math.Sqrt(amount);
            probability.Should().BeInRange(Math.PI / 10 - precision, Math.PI / 10 + precision);
        }
    }
}
