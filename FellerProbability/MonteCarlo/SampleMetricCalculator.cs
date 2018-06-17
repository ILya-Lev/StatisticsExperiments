using System;
using System.Collections.Generic;
using System.Linq;

namespace FellerProbability.MonteCarlo
{
    public static class SampleMetricCalculator
    {
        private const double Epsilon = 1E-20;
        public static double UniformMean(this IEnumerable<double> sample, double from, double to)
        {
            var distance = to - from;
            if (Math.Abs(distance) < Epsilon)
                return 0;

            return sample.Sum() / distance;
        }

        public static double Mean(this IReadOnlyCollection<double> sample)
        {
            return sample.Sum() / sample.Count;
        }

        public static double Momentum(this IReadOnlyCollection<double> sample, int power)
        {
            var mean = sample.Mean();
            return sample.Sum(n => Math.Pow(n - mean, power)) / sample.Count;
        }

        public static double Variance(this IReadOnlyCollection<double> sample) => sample.Momentum(2);
        public static double Asymmetry(this IReadOnlyCollection<double> sample) => sample.Momentum(3);
        public static double Skewness(this IReadOnlyCollection<double> sample) => sample.Momentum(3) / Math.Pow(sample.Variance(), 1.5);
        public static double Excess(this IReadOnlyCollection<double> sample) => sample.Momentum(4);
        public static double Kurtosis(this IReadOnlyCollection<double> sample) => sample.Momentum(4) / Math.Pow(sample.Variance(), 2);
    }
}
