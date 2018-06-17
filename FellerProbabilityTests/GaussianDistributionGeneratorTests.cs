using FellerProbability.MonteCarlo;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests
{
    public class GaussianDistributionGeneratorTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public GaussianDistributionGeneratorTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void GetStandardSample_EvZeroDevOne()
        {
            var generator = new GaussianDistributionGenerator();

            var sample = generator.GetStandardSample(10000);

            var precision = 0.01;

            var mean = sample.Mean();
            mean.Should().BeInRange(0.0 - precision, 0.0 + precision);

            var variance = sample.Variance();
            variance.Should().BeInRange(1 - precision, 1 + precision);

            var asymmetry = sample.Asymmetry();
            var skewness = sample.Skewness();
            var excess = sample.Excess();
            var kurtosis = sample.Kurtosis();

            _outputHelper.WriteLine($"mean is {mean}");
            _outputHelper.WriteLine($"variance is {variance}");
            _outputHelper.WriteLine($"asymmetry is {asymmetry}");
            _outputHelper.WriteLine($"skewness is {skewness}");
            _outputHelper.WriteLine($"excess is {excess}");
            _outputHelper.WriteLine($"kurtosis is {kurtosis}");
        }

        [Fact]
        public void GetSample_Ev10Dev3()
        {
            var generator = new GaussianDistributionGenerator();

            var sample = generator.GetSample(100000, 10, 3);

            var precision = 0.1;

            var mean = sample.Mean();
            mean.Should().BeInRange(10 - precision, 10 + precision);

            var variance = sample.Variance();
            variance.Should().BeInRange(9 - precision, 9 + precision);

            var asymmetry = sample.Asymmetry();
            var skewness = sample.Skewness();
            var excess = sample.Excess();
            var kurtosis = sample.Kurtosis();

            _outputHelper.WriteLine($"mean is {mean}");
            _outputHelper.WriteLine($"variance is {variance}");
            _outputHelper.WriteLine($"asymmetry is {asymmetry}");
            _outputHelper.WriteLine($"skewness is {skewness}");
            _outputHelper.WriteLine($"excess is {excess}");
            _outputHelper.WriteLine($"kurtosis is {kurtosis}");
        }
    }
}
