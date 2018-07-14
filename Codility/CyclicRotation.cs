using System;
using System.Linq;

namespace Codility
{
    public class CyclicRotation
    {
        public int[] Shift(int[] source, int distance)
        {
            var result = source.ToArray();
            for (int step = 0; step < distance%result.Length; step++)
            {
                var tmp = result[result.Length - 1];
                for (int idx = result.Length -1 ; idx >0 ; idx--)
                {
                    result[idx] = result[idx - 1];
                }

                result[0] = tmp;
            }

            return result;
        }
    }
}
