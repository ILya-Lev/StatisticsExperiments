using System;
using FluentAssertions;
using Xunit;

namespace Codility.UnitTests
{
    public class CyclicRotationTests
    {
        [InlineData(1, new int[] {4,1,2,3})]
        [InlineData(2, new int[] {3,4,1,2})]
        [InlineData(3, new int[] {2,3,4,1})]
        [InlineData(4, new int[] {1,2,3,4})]
        [InlineData(5, new int[] {4,1,2,3})]
        [Theory]
        public void Shift_EvenSourceLength_DoRotation(int stepsAmount, int[] expected)
        {
            var source = new int[] {1, 2, 3, 4};
            var rotator = new CyclicRotation();
            
            var result = rotator.Shift(source, stepsAmount);

            result.Should().BeEquivalentTo(expected);
        }

        [InlineData(1, new int[] {5,1,2,3,4})]
        [InlineData(2, new int[] {4,5,1,2,3})]
        [InlineData(3, new int[] {3,4,5,1,2})]
        [InlineData(4, new int[] {2,3,4,5,1})]
        [InlineData(5, new int[] {1,2,3,4,5})]
        [InlineData(6, new int[] {5,1,2,3,4})]
        [Theory]
        public void Shift_OddSourceLength_DoRotation(int stepsAmount, int[] expected)
        {
            var source = new int[] {1, 2, 3, 4, 5};
            var rotator = new CyclicRotation();
            
            var result = rotator.Shift(source, stepsAmount);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
