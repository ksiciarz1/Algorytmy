using System;
using System.Collections.Generic;

namespace lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] table = { 1, 3, 6, 8, 9, 10 };

            BinaryTree<int> tree = new BinaryTree<int>(table);

            tree.PreorderTraversal(node => { Console.Write($"{node.Value}, "); }); // 1, 3, 8, 9, 6, 10,
            Console.WriteLine("\n");
            tree.PostorderTraversal(node => { Console.Write($"{node.Value}, "); }); // 8, 9, 3, 10, 6, 1,
            Console.WriteLine("\n");
            tree.LevelTraversal(node => { Console.Write($"{node.Value}, "); }); //1, 3, 6, 8, 9, 10,

        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    public class BinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public BinaryTree() { }
        public BinaryTree(T[] table)
        {
            if (table != null)
            {

                if (table.Length != 0)
                {
                    Root = BuildRecursive(table, 0);
                    return;
                }
            }
            throw new ArgumentException($"Invalud argument: {nameof(table)}");
        }

        /// <summary>
        /// Creates a new tree build from the table
        /// Works like BinaryTree(T[] table) constructor
        /// </summary>
        /// <param name="table">Table to build tree from</param>
        /// <returns>Fully builded tree</returns>
        public static BinaryTree<T> Build(T[] table)
        {
            if (table != null)
                if (table.Length != 0)
                    return new BinaryTree<T>() { Root = BuildRecursive(table, 0) };
            throw new ArgumentException($"Invalid argument: {nameof(table)}");
        }

        private static Node<T> BuildRecursive(T[] table, int index)
        {
            Node<T> node = new Node<T>() { Value = table[index] };

            if (Left(index) < table.Length)
                node.Left = BuildRecursive(table, Left(index));
            if (Right(index) < table.Length)
                node.Right = BuildRecursive(table, Right(index));

            return node;
        }


        public void PreorderTraversal(Action<Node<T>> action) { PreorderTraversalRecursive(Root, action); }

        /// <summary>
        /// Invokes action on each element of the tree
        /// </summary>
        /// <param name="action">Action to invoke with each element</param>
        private void PreorderTraversalRecursive(Node<T> node, Action<Node<T>> action)
        {
            if (node != null)
            {
                action.Invoke(node);
                PreorderTraversalRecursive(node.Left, action);
                PreorderTraversalRecursive(node.Right, action);
            }
        }


        public void PostorderTraversal(Action<Node<T>> action) { PostorderTraversalRecursive(Root, action); }

        /// <summary>
        /// Invokes action on each element of the tree with reversed order
        /// </summary>
        /// <param name="action">Action to invoke with each element</param>
        private void PostorderTraversalRecursive(Node<T> node, Action<Node<T>> action)
        {
            if (node != null)
            {
                PostorderTraversalRecursive(node.Left, action);
                PostorderTraversalRecursive(node.Right, action);
                action.Invoke(node);
            }
        }


        public void LevelTraversal(Action<Node<T>> action)
        {
            Queue<Node<T>> nodeQueue = new Queue<Node<T>>();
            nodeQueue.Enqueue(Root);

            while (nodeQueue.Count > 0)
            {
                Node<T> tempNode = nodeQueue.Dequeue();
                action.Invoke(tempNode);
                if (tempNode.Left != null)
                    nodeQueue.Enqueue(tempNode.Left);
                if (tempNode.Right != null)
                    nodeQueue.Enqueue(tempNode.Right);
            }
        }

        private static int Left(int index) { return 2 * index + 1; }
        private static int Right(int index) { return 2 * index + 2; }

    }


}
