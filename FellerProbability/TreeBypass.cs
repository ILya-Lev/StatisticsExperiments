using System;

namespace FellerProbability
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    public class TreeBypass<T>
    {
        private Node<T> _root;
        public void Init(Node<T> root)
        {
            _root = root;
        }

        public int CalculateHeight()
        {
            return DoCalculate(0, _root);
        }

        private int DoCalculate(int currentLevel, Node<T> node)
        {
            if (node == null)
                return currentLevel;

            var leftSubTree = 0;
            var rightSubTree = 0;
            if (node.Left != null)
                leftSubTree = DoCalculate(currentLevel + 1, node.Left);
            if (node.Right != null)
                rightSubTree = DoCalculate(currentLevel + 1, node.Right);

            return Math.Max(Math.Max(rightSubTree, leftSubTree), currentLevel);
        }
    }
}
