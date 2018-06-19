using System;
using System.Collections.Generic;
using System.Linq;

namespace FellerProbability.DataStructures
{
    public abstract class Heap<T> where T : IComparable<T>
    {
        private readonly List<T> _storage = new List<T>();

        public int Count => _storage.Count;

        public T Peek() => _storage.FirstOrDefault();

        public void Push(T item)
        {
            _storage.Add(item);
            BubbleUp();
        }

        public T Pop()
        {
            var head = Peek();
            Swap(0, _storage.Count - 1);
            _storage.RemoveAt(_storage.Count - 1);
            BubbleDown();
            return head;
        }

        private void BubbleUp()
        {
            var childIdx = _storage.Count - 1;
            var parentIdx = GetParentIndex(childIdx);
            while (parentIdx.HasValue && !ObeysHeapProperty(_storage[parentIdx.Value], _storage[childIdx]))
            {
                Swap(parentIdx.Value, childIdx);

                childIdx = parentIdx.Value;
                parentIdx = GetParentIndex(childIdx);
            }
        }

        private void BubbleDown()
        {
            var parentIdx = 0;
            var childIdx = GetProperChildIdx(parentIdx);
            while (childIdx.HasValue && !ObeysHeapProperty(_storage[parentIdx], _storage[childIdx.Value]))
            {
                Swap(parentIdx, childIdx.Value);

                parentIdx = childIdx.Value;
                childIdx = GetProperChildIdx(parentIdx);
            }
        }

        protected abstract bool ObeysHeapProperty(T parent, T child);

        private void Swap(int parentIdx, int childIdx)
        {
            var tmp = _storage[parentIdx];
            _storage[parentIdx] = _storage[childIdx];
            _storage[childIdx] = tmp;
        }

        private int? GetParentIndex(int childIndex)
        {
            var parentIndex = (childIndex - 1) / 2;
            return parentIndex >= 0 ? parentIndex : default(int?);
        }

        private int? GetProperChildIdx(int parentIndex)
        {
            var firstChildIndex = parentIndex * 2 + 1;
            if (firstChildIndex >= _storage.Count)
                return null;

            var secondChildIndex = firstChildIndex + 1;
            if (secondChildIndex >= _storage.Count)
                return firstChildIndex;

            return ObeysHeapProperty(_storage[firstChildIndex], _storage[secondChildIndex])
                ? firstChildIndex
                : secondChildIndex;
        }
    }

    public class MaxHeap<T> : Heap<T> where T : IComparable<T>
    {
        protected override bool ObeysHeapProperty(T parent, T child) => parent.CompareTo(child) >= 0;
    }

    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        protected override bool ObeysHeapProperty(T parent, T child) => parent.CompareTo(child) <= 0;
    }
}
