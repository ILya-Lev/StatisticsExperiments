using FellerProbability.MonteCarlo;
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
            var probability = calculator.EvaluateProbabilityAnnieComesBeforeSam();

            _outputHelper.WriteLine($"for sample size {sampleSize} probability is {probability}");
        }

        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10_000)]
        [InlineData(100_000)]
        [InlineData(1_000_000)]
        [InlineData(10_000_000)]
        [Theory]
        public void EvaluateDifferenceInArrival_TellUs(int sampleSize)
        {
            var calculator = new SleeplessInSeattle(10.5, 12, 10, 11.5, sampleSize);
            calculator.Initialize();
            var expectedDifference = calculator.EvaluateDifferenceInArrival();

            _outputHelper.WriteLine($"for sample size {sampleSize} difference is {expectedDifference}");
        }


    }
}
