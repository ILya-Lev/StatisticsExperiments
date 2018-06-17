using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FellerProbability.MonteCarlo
{
    public class PiEvaluator
    {
        private readonly Random _randomGenerator = new Random(DateTime.UtcNow.Millisecond);

        public double Evaluate(int experimentsAmount)
        {
            var insideCircleAmount = CalculateAmountPointsInsideCircleSerial(experimentsAmount);
            //var insideCircleAmount = CalculateAmountPointsInsideCircleParallel(experimentsAmount);
            //var insideCircleAmount = CalculateAmountPointsInsideCircle(experimentsAmount);

            return 4.0 * insideCircleAmount / experimentsAmount;
        }

        private int CalculateAmountPointsInsideCircleSerial(int experimentsAmount)
        {
            var insideCircleAmount = Enumerable.Range(0, experimentsAmount)
                .Select(n => new
                {
                    x = _randomGenerator.NextDouble(),
                    y = _randomGenerator.NextDouble()
                })
                .Count(point => IsInsideCircle(point.x, point.y));
            return insideCircleAmount;
        }
        private int CalculateAmountPointsInsideCircle(int n)
        {
            Func<int, int, int> amountFunc = (start, finish) => Enumerable.Range(start, finish)
                  .Select(val => new
                  {
                      x = _randomGenerator.NextDouble(),
                      y = _randomGenerator.NextDouble()
                  })
                  .Count(point => IsInsideCircle(point.x, point.y));
            var insideCircleAmount = 0;
            Parallel.For(0, 10,
                i => Interlocked.Add(ref insideCircleAmount, amountFunc((int)(n / 10.0 * i), (int)(n / 10.0 * (i + 1)))));
            return insideCircleAmount;
        }

        private int CalculateAmountPointsInsideCircleParallel(int experimentsAmount)
        {
            int insideCircle = 0;
            Parallel.For(0, experimentsAmount, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
              {
                  if (IsInsideCircle(_randomGenerator.NextDouble(), _randomGenerator.NextDouble()))
                      Interlocked.Increment(ref insideCircle);
              });
            return insideCircle;
        }

        private bool IsInsideCircle(double x, double y)
        {
            return x + y - x * x - y * y >= 0.25;
        }

        //private bool IsInsideCircle(double x, double y)
        //{
        //    return Dev(x) * Dev(x) + Dev(y) * Dev(y) <= 0.25;
        //}

        //private double Dev(double coordinate) => coordinate - 0.5;
    }
}
