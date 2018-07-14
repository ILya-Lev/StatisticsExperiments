using System;
using System.Linq;

namespace Codility
{
    public class CyclicRotation
    {
        public int[] Shift(int[] source, int distance)
        {
            if (source == null || !source.Any())
                return source;

            var shift = distance % source.Length;
            if (shift == 0)
                return source;

            var result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                var resultIndex = (i + shift) % source.Length;
                result[resultIndex] = source[i];
            }
            
            return result;
        }
    }
}
