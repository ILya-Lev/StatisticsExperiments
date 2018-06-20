using FellerProbability.DataStructures;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace FellerProbabilityTests.DataStructureTests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Insert_SmallSample_Ok()
        {
            var tree = new BinarySearchTree<int>();
            var values = new[] { 3, 1, 5, 2, 4 };

            foreach (var value in values)
            {
                tree.Insert(value);
                tree.Contains(value).Should().BeTrue();
            }
        }

        [Fact]
        public void MinMax_SmallSample_Ok()
        {
            var tree = new BinarySearchTree<int>();
            var values = new[] { 3, 1, 5, 2, 4 };

            foreach (var value in values)
            {
                tree.Insert(value);
            }

            var min = tree.GetMin();
            min.Should().Be(1);

            var max = tree.GetMax();
            max.Should().Be(5);
        }

        [Fact]
        public void GetInSortedOrder_SmallSample_Ok()
        {
            var tree = new BinarySearchTree<int>();
            var values = new[] { 3, 1, 5, 2, 4 };

            foreach (var value in values)
            {
                tree.Insert(value);
            }

            var sorted = tree.GetInSortedOrder().ToList();

            sorted.Should().BeInAscendingOrder();
        }

        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [Theory]
        public void Delete_One_Ok(int toDelete)
        {
            var tree = new BinarySearchTree<int>();
            var values = new[] { 3, 1, 5, 2, 4 };

            foreach (var value in values)
            {
                tree.Insert(value);
            }

            var succeeded = tree.Delete(toDelete);

            succeeded.Should().BeTrue();
        }

        [Fact]
        public void Delete_All_Ok()
        {
            var tree = new BinarySearchTree<int>();
            var values = new[] { 3, 1, 5, 2, 4 };

            foreach (var value in values)
                tree.Insert(value);

            foreach (var value in values)
            {
                var succeeded = tree.Delete(value);
                succeeded.Should().BeTrue();
            }
        }

    }
}
