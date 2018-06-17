using FellerProbability.MonteCarlo;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests
{
    public class SampleMetricCalculatorTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;
        private readonly IReadOnlyList<double> _uniformSample;

        public SampleMetricCalculatorTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            var rand = new Random(DateTime.UtcNow.Millisecond);
            _uniformSample = Enumerable.Range(0, 1000).Select(n => rand.NextDouble()).ToList();
        }

        [Fact]
        public void UniformMean_UniformOnZeroToOne_Half()
        {
            var mean = _uniformSample.UniformMean(0, 1);

            //mean.Should().Be(0);
        }

        [Fact]
        public void Mean_UniformOnZeroToOne_Half()
        {
            var mean = _uniformSample.Mean();

            var expected = 0.5;
            var precision = 0.01;
            mean.Should().BeInRange(expected - precision, expected + precision);
            _outputHelper.WriteLine($"mean of uniform distribution is {mean}");
        }

        [Fact]
        public void Variance_UniformOnZeroToOne_()
        {
            var variance = _uniformSample.Variance();

            //variance.Should().Be(1);
            _outputHelper.WriteLine($"variance of uniform distribution is {variance}");
            _outputHelper.WriteLine($"standard deviation of uniform distribution is {Math.Sqrt(variance)}");
        }

        [Fact]
        public void Asymmetry_UniformOnZeroToOne_()
        {
            var asymmetry = _uniformSample.Asymmetry();

            //variance.Should().Be(1);
            _outputHelper.WriteLine($"asymmetry of uniform distribution is {asymmetry}");
        }

        [Fact]
        public void Excess_UniformOnZeroToOne_()
        {
            var excess = _uniformSample.Excess();

            //variance.Should().Be(1);
            _outputHelper.WriteLine($"excess of uniform distribution is {excess}");
        }
    }
}
