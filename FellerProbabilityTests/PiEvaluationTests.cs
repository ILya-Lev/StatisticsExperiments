using FellerProbability.MonteCarlo;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests
{
    public class PiEvaluationTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public PiEvaluationTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10_000)]
        [InlineData(100_000)]
        [InlineData(1_000_000)]
        [InlineData(10_000_000)]
        [InlineData(100_000_000)]
        [Theory]
        public void Evaluate_TriesN_Pi(int n)
        {
            var evaluator = new PiEvaluator();

            var pi = evaluator.Evaluate(n);

            _outputHelper.WriteLine($"for '{n}' tries pi = '{pi}'");

            pi.Should().BeInRange(LowerBoundary(n), UpperBoundary(n));
        }

        private double UpperBoundary(int n) => Math.PI * (1 + Precision(n));
        private double LowerBoundary(int n) => Math.PI * (1 - Precision(n));

        /// <summary>
        /// expected precision of the monte-carlo method is sqrt(variance/N)
        /// variance in this case is about 0.25
        /// </summary>
        private double Precision(int n) => 0.5 / Math.Sqrt(n);
    }
}
