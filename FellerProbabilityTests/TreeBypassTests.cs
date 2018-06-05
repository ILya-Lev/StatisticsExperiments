using FellerProbability;
using FluentAssertions;
using Xunit;

namespace FellerProbabilityTests
{
    public class TreeBypassTests
    {
        [Fact]
        public void CalculateHeight_NullTree_Zero()
        {
            var bypass = new TreeBypass<int>();
            bypass.Init(null);

            var maxDepth = bypass.CalculateHeight();

            maxDepth.Should().Be(0);
        }
        [Fact]
        public void CalculateHeight_EmptyTree_Zero()
        {
            var bypass = new TreeBypass<int>();
            bypass.Init(new Node<int>());

            var maxDepth = bypass.CalculateHeight();

            maxDepth.Should().Be(0);
        }
        [Fact]
        public void CalculateHeight_MaxDepthIsFive_Five()
        {
            var tree = new Node<int>()
            {
                Data = 1,
                Left = new Node<int>()
                {
                    Data = 2,
                    Left = new Node<int>() { Data = 3, Left = new Node<int>() },
                    Right = new Node<int>()
                },
                Right = new Node<int>()
                {
                    Data = 4,
                    Left = new Node<int>() { Data = 5, Right = new Node<int>() },
                    Right = new Node<int>()
                    {
                        Data = 6,
                        Left = new Node<int>()
                        {
                            Data = 7,
                            Left = new Node<int>(),
                            Right = new Node<int>() { Data = 8, Right = new Node<int>() }
                        }
                    }
                }
            };
            var bypass = new TreeBypass<int>();
            bypass.Init(tree);

            var maxDepth = bypass.CalculateHeight();

            maxDepth.Should().Be(5);
        }
    }
}
