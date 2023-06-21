using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees.BinaryTree
{
    public class BinaryTree<T> : IEnumerable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public BinaryTree(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Insert(item);
        }

        public T Insert(T value)
        {
            var newNode = new Node<T>(value);

            if (Root == null)
            {
                Root = newNode;
                Count++;
                return value;
            }

            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if (temp.Left != null)
                    q.Enqueue(temp.Left);
                else
                {
                    temp.Left = newNode;
                    Count++;
                    return value;
                }
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
                else
                {
                    temp.Right = newNode;
                    Count++;
                    return value;
                }
            }
            throw new Exception("The insertion operation failed.");
        }

        public static List<T> InOrderIterationTraverse(Node<T> root)
        {
            var list = new List<T>();
            var stack = new Stack<Node<T>>();
            Node<T> currentNode = root;
            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                currentNode = stack.Pop();
                list.Add(currentNode.Value);
                currentNode = currentNode.Right;
            }
            return list;
        }

        public static List<Node<T>> LevelOrderTraverse(Node<T> root)
        {
            var list = new List<Node<T>>();
            var q = new Queue<Node<T>>();
            if (root != null) q.Enqueue(root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                list.Add(temp);
                if (temp.Left != null) q.Enqueue(temp.Left);
                if (temp.Right != null) q.Enqueue(temp.Right);
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return LevelOrderTraverse(this.Root).GetEnumerator();
        }
    }
}
