using System;
using System.Diagnostics;

namespace lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[1000];
            Random random = new Random();

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = random.Next(100);
            }

            Array.Sort(myArray);

            int index = Array.BinarySearch(myArray, 5);


            TreeNode<int> root = new TreeNode<int>() { Value = 10 };
            root.Left = new TreeNode<int>() { Value = 5 };
            root.Right = new TreeNode<int>() { Value = 15 };

            root.Left.Left = new TreeNode<int>() { Value = 3 };
            root.Left.Right = new TreeNode<int>() { Value = 7 };

            root.Right.Left = new TreeNode<int>() { Value = 12 };
            root.Right.Right = new TreeNode<int>() { Value = 18 };



            BinarySearchTree<int> myTree = new BinarySearchTree<int>(new TreeNode<int>()
            {
                Value = 5,
                Left = new TreeNode<int>() { Value = 2 },
                Right = new TreeNode<int>()
                {
                    Value = 15,
                    Right = new TreeNode<int>() { Value = 25 }
                }
            });

            //Console.WriteLine(myTree.Contains(2));  // Returns True
            //Console.WriteLine(myTree.Contains(15)); // Returns True
            //Console.WriteLine(myTree.Contains(25)); // Returns True


            myTree.Insert(30);
            myTree.Insert(3);
            myTree.Insert(10);
            //Console.WriteLine(myTree.Contains(30)); // Returns True
            //Console.WriteLine(myTree.Contains(3));  // Returns True
            //Console.WriteLine(myTree.Contains(10)); // Returns True


            int[] array = new int[1000000];
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            stopwatch.Start();
            Array.Sort(array);
            Array.BinarySearch(array, random.Next(100));
            Array.BinarySearch(array, random.Next(100));
            Array.BinarySearch(array, random.Next(100));
            stopwatch.Stop();
            Console.WriteLine($"For 100 Binary: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();
            stopwatch.Start();
            Array.Find<int>(array, value => { return value == random.Next(100); });
            Array.Find<int>(array, value => { return value == random.Next(100); });
            Array.Find<int>(array, value => { return value == random.Next(100); });
            stopwatch.Stop();
            Console.WriteLine($"For 100 Linear: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1000);
            }

            stopwatch.Start();
            Array.Sort(array);
            Array.BinarySearch(array, random.Next(1000));
            Array.BinarySearch(array, random.Next(1000));
            Array.BinarySearch(array, random.Next(1000));
            stopwatch.Stop();
            Console.WriteLine($"For 1000 Binary: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();
            stopwatch.Start();
            Array.Find<int>(array, value => { return value == random.Next(1000); });
            Array.Find<int>(array, value => { return value == random.Next(1000); });
            Array.Find<int>(array, value => { return value == random.Next(1000); });
            stopwatch.Stop();
            Console.WriteLine($"For 1000 Linear: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10000);
            }

            stopwatch.Start();
            Array.Sort(array);
            Array.BinarySearch(array, random.Next(10000));
            Array.BinarySearch(array, random.Next(10000));
            Array.BinarySearch(array, random.Next(10000));
            stopwatch.Stop();
            Console.WriteLine($"For 10000 Binary: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();
            stopwatch.Start();
            Array.Find<int>(array, value => { return value == random.Next(10000); });
            Array.Find<int>(array, value => { return value == random.Next(10000); });
            Array.Find<int>(array, value => { return value == random.Next(10000); });
            stopwatch.Stop();
            Console.WriteLine($"For 10000 Linear: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10000);
            }

            stopwatch.Start();
            Array.Sort(array);
            Array.BinarySearch(array, random.Next(10000));
            Array.BinarySearch(array, random.Next(10000));
            Array.BinarySearch(array, random.Next(10000));
            stopwatch.Stop();
            Console.WriteLine($"For 10000 Binary: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();
            stopwatch.Start();
            Array.Find<int>(array, value => { return value == random.Next(100000); });
            Array.Find<int>(array, value => { return value == random.Next(100000); });
            Array.Find<int>(array, value => { return value == random.Next(100000); });
            stopwatch.Stop();
            Console.WriteLine($"For 10000 Linear: {stopwatch.Elapsed.TotalMilliseconds}ms");
            stopwatch.Reset();

        }
    }

    class TreeNode<T> where T : IComparable<T>, IEquatable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    class BinarySearchTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public TreeNode<T> Root;

        public BinarySearchTree(TreeNode<T> root)
        {
            Root = root;
        }

        public bool Contains(T value) => Contains(Root, value);

        private bool Contains(TreeNode<T> treeNode, T value)
        {
            if (treeNode == null)
            {
                return false;
            }


            if (treeNode.Value.Equals(value))
            {
                return true;
            }

            if (treeNode.Value.CompareTo(value) > 0)
            {
                return Contains(treeNode.Left, value);
            }
            if (treeNode.Value.CompareTo(value) < 0)
            {
                return Contains(treeNode.Right, value);
            }
            return false;
        }

        public void Insert(T value)
        {
            TreeNode<T> node = Root;
            while (true)
            {
                if (node == null)
                {
                    return;
                }
                if (node.Value.Equals(value))
                {
                    return;
                }

                if (node.Value.CompareTo(value) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>() { Value = value };
                        return;
                    }
                    node = node.Left;
                }
                else if (node.Value.CompareTo(value) < 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>() { Value = value };
                        return;
                    }
                    node = node.Right;
                }
            }

        }
    }

}
