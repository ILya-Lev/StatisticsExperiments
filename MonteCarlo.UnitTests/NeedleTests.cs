using FluentAssertions;
using Xunit;

namespace MonteCarlo.UnitTests
{
    public class NeedleTests
    {
        [Fact]
        public void IsIntersect_Intersects1p0_False()
        {
            var needle = new Needle(10, 2, 5, 0);

            var intersectsAbscissa = needle.ContainsPoint(1, 0);

            intersectsAbscissa.Should().BeFalse();
        }

        [Fact]
        public void IsIntersect_IntersectsAbscissaAtEdge_True()
        {
            var needle = new Needle(10, 2, 5, 0);

            var intersectsAbscissa = needle.IntersectsHorizontalLine(0);

            intersectsAbscissa.Should().BeTrue();
        }

        [Fact]
        public void IsIntersect_IntersectsAtMiddle_True()
        {
            var needle = new Needle(10, 2, 5, 0);

            var intersectsAbscissa = needle.IntersectsHorizontalLine(4);

            intersectsAbscissa.Should().BeTrue();
        }

        [Fact]
        public void IsIntersect_NoIntersection_False()
        {
            var needle = new Needle(10, 2, 5, 0);

            var intersectsAbscissa = needle.IntersectsHorizontalLine(-4);

            intersectsAbscissa.Should().BeFalse();
        }
    }
}
