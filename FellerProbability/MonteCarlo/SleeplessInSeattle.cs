using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FellerProbability.MonteCarlo
{
    public class SleeplessInSeattle
    {
        private readonly double _annieFrom;
        private readonly double _annieTo;
        private readonly double _samFrom;
        private readonly double _samTo;
        private readonly int _sampleSize;
        private readonly Random _rand = new Random(DateTime.UtcNow.Millisecond);
        private List<double> _annieComes;
        private List<double> _samComes;

        public SleeplessInSeattle(double annieFrom, double annieTo, double samFrom, double samTo, int sampleSize)
        {
            _annieFrom = annieFrom;
            _annieTo = annieTo;
            _samFrom = samFrom;
            _samTo = samTo;
            _sampleSize = sampleSize;
        }

        public async void Initialize()
        {
            _annieComes = await GenerateArriveTimes(_annieFrom, _annieTo);
            _samComes = await GenerateArriveTimes(_samFrom, _samTo);
        }

        public double EvaluateProbabilityAnnieComesBeforeSam()
        {
            var annieBeforeSam = CalculateAmountAnnieBeforeSam(_annieComes, _samComes);

            return 1.0 * annieBeforeSam / _sampleSize;
        }

        public async Task<double> EvaluateDifferenceInArrival()
        {
            var overallDiff = 0.0;

            Parallel.For(0, _sampleSize, i =>
            {
                //var diff = Math.Abs(_annieComes[i] - _samComes[i]);
                var diff = _annieComes[i] - _samComes[i];
                lock (this)
                {
                    overallDiff += diff;
                }
            });

            return overallDiff / _sampleSize;
        }
        public async Task<double> EvaluateErrorForArrivalDifference(double mean)
        {
            var numerator = 0.0;

            Parallel.For(0, _sampleSize, i =>
            {
                var diff = _annieComes[i] - _samComes[i];
                lock (this)
                {
                    numerator += (diff - mean) * (diff - mean);
                }
            });

            //error = sigma/ N^1/2; sigma = (sum(deviations from mean)^2/N)^1/2 => error = sum()^1/2 / N
            return Math.Sqrt(numerator) / _sampleSize;
        }

        private Task<List<double>> GenerateArriveTimes(double lowerBound, double upperBound)
        {
            var sequence = Enumerable.Range(0, _sampleSize)
                .Select(n => _rand.NextDouble())
                .Select(ur => ur * (upperBound - lowerBound) + lowerBound);

            return Task.FromResult(sequence.ToList());
        }

        private int CalculateAmountAnnieBeforeSam(IReadOnlyList<double> annie, IReadOnlyList<double> sam)
        {
            var annieBeforeSam = 0;

            Parallel.For(0, _sampleSize, i =>
            {
                if (annie[i] < sam[i])
                    Interlocked.Increment(ref annieBeforeSam);
            });

            return annieBeforeSam;
        }
    }
}
