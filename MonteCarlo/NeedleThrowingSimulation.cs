using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarlo
{
    public class NeedleThrowingSimulation
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private const int Size = 1000;
        private const int Distance = 10;

        private readonly List<double> _lines = new List<double>();

        public NeedleThrowingSimulation()
        {
            InitializeLines();
        }

        public double Simulate(int amount)
        {
            var intersections = 0;
            for (int i = 0; i < amount; i++)
            {
                var needle = ThrowNeedle();

                var intersects = _lines.Any(ln => needle.IntersectsHorizontalLine(ln));
                if (intersects)
                    intersections++;
            }

            return intersections * 1.0 / amount;
        }

        private Needle ThrowNeedle()
        {
            return new Needle(length: GetRandom(Distance), orientation: GetRandom(2 * Math.PI), x: GetRandom(Size), y: GetRandom(Size));
        }

        private void InitializeLines()
        {
            for (int i = 0; i < Size / Distance; i++)
            {
                _lines.Add(i * Distance);
            }
        }

        private static double GetRandom(double limit) => limit * _random.NextDouble();
    }
}
