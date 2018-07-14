using System;
using System.Linq;

namespace Codility
{
    public class OddOccurrencesInArray
    {
        public int GetUnpairedOddInteger(int[] source)
        {
            var ordered = source.OrderBy(n => n);   //already O(N logN) - we need O(N)
            var total = 0;
            var sign = 1;
            foreach (var number in ordered)
            {
                total += sign * number;
                sign = sign > 0 ? -1 : 1;
            }

            return Math.Abs(total);
        }
    }
}
