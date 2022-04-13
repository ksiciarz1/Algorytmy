using System;
using System.Collections.Generic;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "adam" };
            node.Next = new Node<string>() { Value = "ewa" };
            node.Next.Next = new Node<string>() { Value = "karol" };

            Node<string> head = node;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            Console.WriteLine("/////////////////");


            Stack<string> stack = new Stack<string>();
            stack.Push("adam");
            stack.Push("ewa");
            stack.Push("karol");

            int length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("/////////////////");


        }


        // Zadanie 7
        static bool TestList<T>(LinkedList<T> list) where T : IComparable
        {
            return list.Last == list.First;
        }

        static bool TestOnMyList<T>(MyLinkedList<T> list) where T : IComparable
        {
            return list.GetNode(list.Count) == list.GetNode(0);
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node() { }
        public Node(T value, Node<T>? next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    public class Stack<T>
    {
        /// <summary>
        /// Top of the stack, null if stack is empty
        /// </summary>
        private Node<T>? top;
        public int Count { get; set; } = 0;

        public Stack() { }
        public Stack(T value)
        {
            top = new Node<T>(value);
            Count++;
        }

        /// <summary>
        /// Adds Node to the top of the stack
        /// </summary>
        /// <param name="node">Node to be added at the top</param>
        public void Push(T value)
        {
            Node<T> node = new Node<T>(value, top);
            top = node;
            Count++;
        }

        /// <summary>
        /// Removes Top value of the stack
        /// </summary>
        /// <returns>Top of the stack</returns>
        /// <exception cref="NullReferenceException">When stack is empty</exception>
        public T Pop()
        {
            if (top != null)
            {
                T returnValue = top.Value;
                top = top.Next;
                Count--;
                return returnValue;
            }
            throw new NullReferenceException("Stack is empty");
        }

        /// <summary>
        /// Return top of the stack without removing it
        /// </summary>
        /// <returns>Top of the stack</returns>
        /// <exception cref="NullReferenceException">When stack is empty</exception>
        public T Peek()
        {
            if (top != null)
            {
                return top.Value;
            }
            throw new NullReferenceException("Stack is empty");
        }

        /// <summary>
        /// Reverses all the elements in the stack
        /// </summary>
        /// <returns>Stack with reversed values</returns>
        public Stack<T> Reverse()
        {
            Stack<T> tempStack = new Stack<T>();
            Stack<T> stackCopy = this; // so that the orginal value order isn't deleted
            for (int i = 0; i < Count; i++)
            {
                tempStack.Push(stackCopy.Pop());
            }
            return tempStack;
        }
    }

    public class Queue<T>
    {
        private Node<T>? head = null;
        public int Count { get; set; } = 0;

        public Queue() { }
        public Queue(T value)
        {
            head = new Node<T>(value);
            Count++;
        }

        public void Push(T value)
        {
            if (head != null)
            {
                Node<T> temp = head;
                for (int i = 1; i < Count; i++)
                {
                    temp = temp.Next;
                }
                temp.Next = new Node<T>(value);
                Count++;
            }
            else
            {
                head = new Node<T>(value);
                Count++;
            }
        }

        public T Pop()
        {
            if (head != null)
            {
                T returnValue = head.Value;
                head = head.Next;
                Count--;
                return returnValue;
            }
            throw new NullReferenceException("Stack is empty");
        }

        public void Enqueue(T value) => Push(value);
        public T Dequeue() => Pop();
    }

    public class MyLinkedList<T>
    {
        private Node<T> head = null;
        public int Count { get; set; }
        public MyLinkedList() { }

        public T Get(int index)
        {
            if (head != null)
            {
                if (index == 0)
                {
                    return head.Value;
                }

                Node<T> temp = head;
                for (int i = 1; i < Count; i++)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }
            else
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        public Node<T> GetNode(int index)
        {
            if (head != null)
            {
                if (index == 0)
                {
                    return head;
                }

                Node<T> temp = head;
                for (int i = 1; i < Count; i++)
                {
                    temp = temp.Next;
                }
                return temp;
            }
            else
            {
                throw new NullReferenceException("Stack is empty");
            }
        }

        /// <summary>
        /// Adds value at the end of the list
        /// </summary>
        /// <param name="value">Value to be added</param>
        public void Add(T value)
        {
            if (head != null)
            {
                Node<T> temp = head;
                for (int i = 1; i < Count; i++)
                {
                    temp = temp.Next;
                }
                temp.Next = new Node<T>(value);
                Count++;
            }
            else
            {
                head = new Node<T>(value);
                Count++;
            }
        }
        /// <summary>
        /// Adds value at the index
        /// </summary>
        /// <param name="value">value to be added</param>
        /// <param name="index">index to add the value to</param>
        /// <exception cref="NullReferenceException">If the index is out of range</exception>
        public void AddAt(T value, int index)
        {
            if (head != null)
            {
                Node<T> temp = head;
                for (int i = 1; i < index - 1; i++)
                {
                    temp = temp.Next;
                }
                temp.Next = new Node<T>(value, temp.Next);
                Count++;
            }
            else
            {
                if (index != 0)
                {
                    throw new ArgumentException("value was out of index");
                }
                head = new Node<T>(value);
            }
        }

        /// <summary>
        /// Removes last value in the List
        /// </summary>
        public void Remove()
        {
            if (Count == 0)
            {
                throw new NullReferenceException("stack is empty");
            }

            if (head != null)
            {
                Node<T> temp = head;
                for (int i = 1; i < Count - 1; i++)
                {
                    temp = temp.Next;
                }
                Node<T> temp2 = temp.Next.Next;
                temp.Next = temp2;
            }
        }
        /// <summary>
        /// Removes value of the index
        /// </summary>
        /// <param name="index">index of value to be removed</param>
        /// <exception cref="NullReferenceException">Index is out of the range</exception>
        public void RemoveAt(int index)
        {
            if (head != null)
            {
                if (index == 0)
                {
                    head = null;
                    return;
                }
                Node<T> temp = head;
                try
                {
                    for (int i = 1; i < index - 1; i++)
                    {
                        temp = temp.Next;
                    }
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("Index was out of range");
                }
                Node<T> temp2 = temp.Next.Next;
                temp.Next = temp2;
            }
        }
    }

}
