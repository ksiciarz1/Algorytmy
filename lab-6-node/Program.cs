using System;

namespace lab_6_node
{
    internal class Program
    {
        static void Main(string[] args)
        { // Lab-6 przerobione na używanie Node
            // Queue
            Queue<int> intQueue = new Queue<int>();
            intQueue.Add(4);
            intQueue.Add(6);
            intQueue.Add(10);
            if (intQueue.Count == 3)
                Console.WriteLine("1");
            if (intQueue.Remove() == 4)
                Console.WriteLine("2");
            if (intQueue.Count == 2)
                Console.WriteLine("3");

            Console.WriteLine("///////////////\n");

            //// Priority Queue
            //PriorityQueue priorityQueue = new PriorityQueue(5);

            //priorityQueue.Add(5);
            //priorityQueue.Add(2);
            //priorityQueue.Add(3);
            //priorityQueue.Add(8);
            //priorityQueue.Add(4);

            //if (priorityQueue.Remove() == 8)
            //    Console.WriteLine("1");
            //if (priorityQueue.Remove() == 5)
            //    Console.WriteLine("2");
            //if (priorityQueue.Remove() == 4)
            //    Console.WriteLine("3");

            Console.WriteLine("///////////////\n");

        }

        public class Queue<T>
        {
            private int count = 0;
            private Node<T> firstNode = null;
            private Node<T> lastNode = null;

            public int Count { get => count; }

            public Queue() { }

            /// <summary>
            /// Adds element in the end of the quque
            /// </summary>
            /// <param name="value"></param>
            /// <returns>true if succesfull, false if failed</returns>
            public bool Add(T value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (!IsEmpty())
                {
                    count++;
                    Node<T> temp = new Node<T>(value);
                    lastNode.NextNode = temp;
                    lastNode = temp;
                    return true;
                }
                else
                {
                    count++;
                    Node<T> temp = new Node<T>(value);
                    firstNode = temp;
                    lastNode = temp;
                    return true;
                }
            }
            /// <summary>
            /// Removes first element in Queue
            /// </summary>
            /// <returns>First element in Queue</returns>            
            public T Remove()
            {
                if (IsEmpty())
                    throw new Exception("Queue is empty");

                T removed = firstNode.Value;
                count--;
                if (firstNode.NextNode != null)
                    firstNode = firstNode.NextNode;
                else
                    firstNode = null;
                return removed;
            }

            public bool IsEmpty()
            {
                return count == 0;
            }

            internal class Node<Y>
            {
                private Y value;
                private Node<Y>? nextNode;

                public Y Value { get => value; set => this.value = value; }
                public Node<Y> NextNode { get => nextNode; set => this.nextNode = value; }

                public Node(Y value, Node<Y> nextNode = null)
                {
                    this.value = value;
                    this.nextNode = nextNode;
                }
            }
        }

        public class PriorityQueue<T> where T : IComparable<T>, IEquatable<T>
        {
            private int count = 0;
            private Node<T> firstNode = null;
            private Node<T> lastNode = null;

            public int Count { get => count; }
            public PriorityQueue() { }

            //// Will not work
            //public bool Add(T value)
            //{
            //    if (value == null)
            //        throw new ArgumentNullException("value");

            //    if (!IsEmpty())
            //    {
            //        count++;
            //        Node<T> temp = new Node<T>(value);
            //        if (lastNode.Parent == null)
            //        {
            //            firstNode.LeftChild = temp;
            //            temp.IsLeftChild = true;
            //            temp.Parent = lastNode.Parent;
            //            lastNode = temp;
            //            RoundUp(temp);
            //            return true;
            //        }
            //        else if (lastNode.IsLeftChild || lastNode.Parent.RightChild == null)
            //        {
            //            lastNode.Parent.RightChild = temp;
            //            temp.IsLeftChild = false;
            //            temp.Parent = lastNode.Parent;
            //            lastNode = temp;
            //            RoundUp(temp);
            //            return true;
            //        }
            //        else if (!lastNode.IsLeftChild)
            //        {
            //            lastNode.LeftChild = temp;
            //            temp.IsLeftChild = true;
            //            lastNode = temp;
            //            RoundUp(temp);
            //            return true;
            //        }

            //        lastNode.NextNode = temp;
            //        lastNode = temp;
            //        return true;
            //    }
            //    else
            //    {
            //        count++;
            //        Node<T> temp = new Node<T>(value);
            //        firstNode = temp;
            //        lastNode = temp;
            //        return true;
            //    }
            //}
            //public T Remove()
            //{
            //    if (IsEmpty())
            //        throw new Exception("Queue is empty");

            //    T removed = firstNode.Value;
            //    count--;
            //    if (firstNode.NextNode != null)
            //        firstNode = firstNode.NextNode;
            //    else
            //        firstNode = null;
            //    return removed;
            //}
            public bool IsEmpty()
            {
                return count == 0;
            }
            public void RoundUp(Node<T> node)
            {

            }
            public void RoundDown()
            {

            }

            internal class Node<Y>
            {
                private Y value;
                private Node<Y>? parent;
                private Node<Y>? leftChild;
                private Node<Y>? rightChild;
                private bool isLeftChild;

                public Y Value { get => value; set => this.value = value; }
                public Node<Y> Parent { get => parent; set => this.parent = value; }
                public Node<Y> LeftChild { get => leftChild; set => this.leftChild = value; }
                public Node<Y> RightChild { get => rightChild; set => this.rightChild = value; }
                public bool IsLeftChild { get => isLeftChild; set => this.isLeftChild = value; }

                public Node(Y value, Node<Y> parent = null)
                {
                    this.value = value;
                    this.parent = parent;
                }
            }
        }
    }
}
