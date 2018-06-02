using System;
using System.Collections.Generic;

namespace FellerProbability
{
    public class QuickSort<T> where T : IComparable<T>
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        public int Comparisons { get; private set; }

        public IList<T> Sort(IList<T> source)
        {
            Comparisons = 0;
            var sourceCopy = new List<T>(source);
            PlaceRandomElementAtStart(sourceCopy, 0, source.Count);

            SortSubset(sourceCopy, 0, source.Count);
            return sourceCopy;
        }

        private void SortSubset(IList<T> source, int beginning, int ending)
        {
            if (beginning >= ending)
                return;

            var start = beginning;
            var end = ending - 1;
            while (start < end)
            {
                Comparisons++;
                //todo:what about 0?
                var relation = source[start].CompareTo(source[start + 1]);
                if (relation >= 0)
                {
                    Swap(source, start, start + 1);
                    start++;
                }
                else
                {
                    Swap(source, start + 1, end);
                    end--;
                }
            }

            SortSubset(source, beginning, start);
            SortSubset(source, end + 1, ending);
        }

        private void PlaceRandomElementAtStart(IList<T> source, int beginning, int ending)
        {
            var seedIndex = _random.Next(0, ending);
            Swap(source, beginning, seedIndex);
        }

        private void Swap(IList<T> source, int lhs, int rhs)
        {
            var tmp = source[lhs];
            source[lhs] = source[rhs];
            source[rhs] = tmp;
        }
    }
}
