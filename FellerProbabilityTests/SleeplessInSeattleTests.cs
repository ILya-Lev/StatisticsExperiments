using FellerProbability.MonteCarlo;
using System;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests
{
    public class SleeplessInSeattleTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public SleeplessInSeattleTests(TestOutputHelper outputHelper)
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
        [Theory]
        public void EvaluateProbabilityAnnieComesBeforeSam_TellUs(int sampleSize)
        {
            var calculator = new SleeplessInSeattle(10.5, 12, 10, 11.5, sampleSize);
            calculator.Initialize();

            var p = calculator.EvaluateProbabilityAnnieComesBeforeSam();

            _outputHelper.WriteLine($"for sample size {sampleSize} probability is {p}");
            _outputHelper.WriteLine($"and standard error is sqrt(p(1-p)/N) = {Math.Sqrt(p * (1 - p) / sampleSize)}");
        }

        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10_000)]
        [InlineData(100_000)]
        [InlineData(1_000_000)]
        [InlineData(10_000_000)]
        [Theory]
        public async void EvaluateDifferenceInArrival_TellUs(int sampleSize)
        {
            var calculator = new SleeplessInSeattle(10.5, 12, 10, 11.5, sampleSize);
            calculator.Initialize();

            var expectedDifference = await calculator.EvaluateDifferenceInArrival();

            //should be expectedDifference but I already know it tends to 0.5 for given time ranges
            var stdError = await calculator.EvaluateErrorForArrivalDifference(0.5);

            _outputHelper.WriteLine($"for sample size {sampleSize} difference is {expectedDifference}");
            _outputHelper.WriteLine($"and estimated standard error is {stdError}");
        }


    }
}
