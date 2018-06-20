using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FellerProbability.DataStructures
{
    [DebuggerDisplay("{Data}; P {Parent?.Data}; L {Left?.Data}; R {Right?.Data}")]
    internal class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node<T> _root;

        public void Insert(T item)
        {
            if (_root == null)
            {
                _root = new Node<T> { Data = item };
                return;
            }

            var currentNode = _root;
            while (true)
            {
                var comparisonResult = currentNode.Data.CompareTo(item);
                if (comparisonResult >= 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new Node<T> { Data = item, Parent = currentNode };
                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Node<T> { Data = item, Parent = currentNode };
                        return;
                    }

                    currentNode = currentNode.Right;
                }
            }

            //re-balance the tree ! - change root according to its position
        }

        public T SelectOrderStatistics(int order)
        {
            throw new NotImplementedException();
        }

        public T GetMin() => GetExtremalNode(_root, n => n.Left).Data;

        public T GetMax() => GetExtremalNode(_root, n => n.Right).Data;

        public bool Contains(T item) => FindNodeByKey(item) != null;

        public T Predecessor(T current)
        {
            throw new NotImplementedException();
        }

        public T Successor(T current)
        {
            throw new NotImplementedException();
        }

        public int Rank(T current)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetInSortedOrder()
        {
            if (_root == null)
                return Enumerable.Empty<T>();

            var stack = new Stack<Node<T>>();
            stack.Push(_root);
            var alreadySeenNodes = new HashSet<Node<T>>();

            var resultSequence = new List<T>();
            while (stack.Count != 0)
            {
                var currentNode = stack.Peek();

                if (currentNode.Left != null && !alreadySeenNodes.Contains(currentNode.Left))
                {
                    stack.Push(currentNode.Left);
                    continue;
                }

                resultSequence.Add(currentNode.Data);
                stack.Pop();
                alreadySeenNodes.Add(currentNode);

                if (currentNode.Right != null && !alreadySeenNodes.Contains(currentNode.Right))
                    stack.Push(currentNode.Right);
            }

            return resultSequence;
        }

        public bool Delete(T item)
        {
            var nodeToDelete = FindNodeByKey(item);
            if (nodeToDelete == null)
                return false;

            //go to left or right depending on balancing!
            if (nodeToDelete.Left != null)
                ReplaceWithLeftChild(nodeToDelete);
            else if (nodeToDelete.Right != null)
                ReplaceWithRightChild(nodeToDelete);
            else
                MakeReplacementANewChild(nodeToDelete, null);
            //re-balance the tree!

            return true;
        }

        private void ReplaceWithLeftChild(Node<T> nodeToDelete)
        {
            var replacement = nodeToDelete.Left;
            replacement.Parent = nodeToDelete.Parent;
            MakeReplacementANewChild(nodeToDelete, replacement);

            var replacementsMax = GetExtremalNode(replacement, n => n.Right);
            if (nodeToDelete.Right != null)
            {
                replacementsMax.Right = nodeToDelete.Right;
                nodeToDelete.Right.Parent = replacementsMax;
            }

            if (nodeToDelete == _root)
                _root = replacement;
        }

        private void ReplaceWithRightChild(Node<T> nodeToDelete)
        {
            var replacement = nodeToDelete.Right;
            replacement.Parent = nodeToDelete.Parent;
            MakeReplacementANewChild(nodeToDelete, replacement);

            var replacementsMin = GetExtremalNode(replacement, n => n.Left);
            if (nodeToDelete.Left != null)
            {
                replacementsMin.Left = nodeToDelete.Left;
                nodeToDelete.Left.Parent = replacementsMin;
            }

            if (nodeToDelete == _root)
                _root = replacement;
        }

        private static void MakeReplacementANewChild(Node<T> nodeToDelete, Node<T> replacement)
        {
            if (nodeToDelete.Parent == null)
                return;

            if (nodeToDelete.Parent.Left == nodeToDelete)
                nodeToDelete.Parent.Left = replacement;
            else
                nodeToDelete.Parent.Right = replacement;
        }

        private Node<T> GetExtremalNode(Node<T> root, Func<Node<T>, Node<T>> childSelector)
        {
            if (root == null)
                throw new Exception("tree is empty");

            var currentNode = root;
            while (childSelector(currentNode) != null)
                currentNode = childSelector(currentNode);

            return currentNode;
        }

        private Node<T> FindNodeByKey(T item)
        {
            if (_root == null)
                return null;

            var currentNode = _root;
            while (true)
            {
                var comparisonResult = currentNode.Data.CompareTo(item);
                if (comparisonResult == 0)
                    return currentNode;

                currentNode = comparisonResult > 0 ? currentNode.Left : currentNode.Right;
                if (currentNode == null)
                    return null;
            }
        }
    }
}

