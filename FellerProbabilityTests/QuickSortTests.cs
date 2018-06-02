using FellerProbability;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests
{
    public class QuickSortTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public QuickSortTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Sort_10To1_1To10()
        {
            var data = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var sorter = new QuickSort<int>();

            var sorted = sorter.Sort(data);

            sorted.Should().BeInAscendingOrder();
            sorted.Should().BeEquivalentTo(data);

            _outputHelper.WriteLine($"{sorter.Comparisons}");
        }
    }
}
