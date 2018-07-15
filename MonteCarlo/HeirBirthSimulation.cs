using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarlo
{
    public class HeirBirthSimulation
    {
        private readonly int _boysThreshold;
        private readonly int _maxKidsInOneFamily;
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public HeirBirthSimulation(int boysThreshold = 50, int maxKidsInOneFamily = 10)
        {
            _boysThreshold = boysThreshold;
            _maxKidsInOneFamily = maxKidsInOneFamily;
        }

        public double Simulate(int familyNumber)
        {
            var children = Enumerable.Range(1, familyNumber)
                            .SelectMany(family => GenerateChildSequence())
                            .ToArray();

            var boys = children.Count(child => child == true);
            var girls = children.Count(child => child == false);

            return 1.0 * girls / boys;
        }

        private IEnumerable<bool> GenerateChildSequence()
        {
            for (int numberOfKid = 0; numberOfKid < _maxKidsInOneFamily; numberOfKid++)
            {
                if (IsBoy(_random.Next(1, 100)))
                {
                    yield return true;
                    yield break;
                }
                yield return false;
            }
        }

        private bool IsBoy(int next) => next >= _boysThreshold;
    }
}
