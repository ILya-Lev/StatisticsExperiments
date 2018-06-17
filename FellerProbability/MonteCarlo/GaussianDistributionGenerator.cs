using System;
using System.Collections.Generic;
using System.Linq;

namespace FellerProbability.MonteCarlo
{
    public class GaussianDistributionGenerator
    {
        private readonly Random _uniformGenerator = new Random(DateTime.UtcNow.Millisecond);

        public IReadOnlyList<double> GetSample(int amount, double mean, double variance)
        {
            return GetStandardSample(amount).Select(n => mean + variance * n).ToList();
        }

        public IReadOnlyList<double> GetStandardSample(int amount)
        {
            //+2 instead of +1 due to integer division - it's better to generate more and filter out than generate less
            var uniformSampleSize = amount / 2 + 2;

            //next double gives us uniformly distributed random variable on [0;1) we need on (0;1]
            var uniformSample = Enumerable.Range(0, uniformSampleSize)
                .Select(n => 1.0 - _uniformGenerator.NextDouble())
                .ToList();

            return FirstBoxMullerTransformation(uniformSample).Take(amount).ToList();
        }

        /// <summary>
        /// generates random variable distributed with Standard Normal Distribution
        /// i.e. Gaussian Distribution with expected value (aka mean) = 0 (aka centered random variable) and variance = 1
        /// using a set of independent uniformly distributed random variables (at least 2 of them are required)
        /// defined on interval (0;1]
        /// 
        /// given N values produces 2(N-1) new ones
        /// </summary>
        private IEnumerable<double> FirstBoxMullerTransformation(IReadOnlyList<double> uniformDistribution)
        {
            for (int i = 0; i + 1 < uniformDistribution.Count; i++)
            {
                var distance = Math.Sqrt(-2.0 * Math.Log(uniformDistribution[i]));
                var phase = 2 * Math.PI * uniformDistribution[i + 1];

                yield return distance * Math.Sin(phase);
                yield return distance * Math.Cos(phase);
            }
        }
    }
}
