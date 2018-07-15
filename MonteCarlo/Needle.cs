using System;

namespace MonteCarlo
{
    public class Needle
    {
        private const double Precision = 1e-5;
        public double Length { get; }

        public double Orientation { get; set; }
        public double VertexX { get; set; }
        public double VertexY { get; set; }

        public Needle(double length, double orientation, double x, double y)
        {
            Length = length;
            Orientation = orientation;
            VertexX = x;
            VertexY = y;
        }

        public bool ContainsPoint(double x, double y)
        {
            var currentDistance = y - Inclination() * x;
            return Math.Abs(currentDistance - Distance) < Precision;
        }

        public bool IntersectsHorizontalLine(double y)
        {
            var inRangeForY = y <= Math.Max(VertexY, AnotherVertexY) && y >= Math.Min(VertexY, AnotherVertexY);
            if (!inRangeForY)
                return false;

            var intersectX = (y - Distance) / Inclination();
            return intersectX <= Math.Max(VertexX, AnotherVertexX)
                   && intersectX >= Math.Min(VertexX, AnotherVertexX);
        }

        private double Inclination()
        {
            if (Orientation < -Precision || Orientation > Math.PI * 2 + Precision)
                throw new ArgumentOutOfRangeException("Orientation should be in radian from 0 to 2PI," +
                                                      $" while met {Orientation}");
            return Math.Tan(Orientation);
        }

        private double Distance => VertexY - Inclination() * VertexX;

        private double AnotherVertexX => Length * Math.Cos(Orientation) + VertexX;
        private double AnotherVertexY => Length * Math.Sin(Orientation) + VertexY;

    }
}
