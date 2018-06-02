using System.Collections.Generic;
using System.Linq;

namespace FellerProbability
{
    public class FourNumbersSum
    {
        private readonly int _threshold;
        private readonly IReadOnlyList<SmokeSample> _smokeSamples;

        public FourNumbersSum(int threshold)
        {
            _threshold = threshold;
            _smokeSamples = GenerateSmokeSamples(_threshold).ToList();
        }

        public int GetAmount() => _smokeSamples.Count;

        public int SmokingManMoreThanWomanAmount()
        {
            return _smokeSamples
                .Count(sample
                        => sample.ManNotSmoke != 0 && sample.WomanNotSmoke != 0
                        && sample.ManSmoke / sample.ManNotSmoke > sample.WomanSmoke / sample.WomanNotSmoke);
        }

        private static IEnumerable<SmokeSample> GenerateSmokeSamples(int threshold)
        {
            for (int a = 0; a <= threshold; a++)
                for (int b = 0; b <= threshold; b++)
                    for (int c = 0; c <= threshold; c++)
                    {
                        var d = threshold - a - b - c;
                        if (d >= 0 && d <= threshold)
                        {
                            yield return new SmokeSample
                            {
                                ManSmoke = a,
                                WomanSmoke = b,
                                ManNotSmoke = c,
                                WomanNotSmoke = d
                            };
                        }
                    }
        }
    }

    public class SmokeSample
    {
        public int ManSmoke { get; set; }
        public int WomanSmoke { get; set; }
        public int ManNotSmoke { get; set; }
        public int WomanNotSmoke { get; set; }

    }
}
