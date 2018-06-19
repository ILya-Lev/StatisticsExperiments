using FellerProbability.DataStructures;
using FluentAssertions;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace FellerProbabilityTests.HeapTests
{
    public class MinHeapTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public MinHeapTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Push_Sample_ShouldBeAsExpected()
        {
            var heap = new MinHeap<int>();
            var vals = new[] { 4, 4, 8, 9, 4, 12, 9, 13, 11 };
            for (int i = 0; i < vals.Length; i++)
            {
                heap.Push(vals[i]);
                heap.Peek().Should().Be(4, $"after inserting {i}th value {vals[i]}");
            }
        }

        [Fact]
        public void Push_OrderedSample_ShouldBeAsExpected()
        {
            var heap = new MinHeap<int>();
            var vals = new[] { 4, 4, 8, 9, 4, 12, 9, 13, 11 }.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < vals.Length; i++)
            {
                heap.Push(vals[i]);
            }

            heap.Peek().Should().Be(4);
        }

        [Fact]
        public void Pop_Sample_ShouldBeAsExpected()
        {
            var heap = new MinHeap<int>();
            var vals = new[] { 4, 4, 8, 9, 4, 12, 9, 13, 11 };
            foreach (var val in vals)
            {
                heap.Push(val);
            }

            for (var head = heap.Pop(); ; head = heap.Pop())
            {
                _outputHelper.WriteLine($"{head}");
                if (heap.Count == 0)
                    break;
            }
        }

    }
}
