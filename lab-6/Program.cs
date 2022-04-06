using System;

namespace lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Queue
            IntQueue queue = new IntQueue(3);
            queue.Add(4);
            queue.Add(6);
            queue.Add(10);
            if (queue.Count() == 3)
                Console.WriteLine("1");
            if (queue.Remove() == 4)
                Console.WriteLine("2");
            if (queue.Count() == 2)
                Console.WriteLine("3");

            Console.WriteLine("///////////////\n");

            // Priority Queue
            PriorityQueue priorityQueue = new PriorityQueue(5);

            priorityQueue.Add(5);
            priorityQueue.Add(2);
            priorityQueue.Add(3);
            priorityQueue.Add(8);
            priorityQueue.Add(4);

            if (priorityQueue.Remove() == 8)
                Console.WriteLine("1");
            if (priorityQueue.Remove() == 5)
                Console.WriteLine("2");
            if (priorityQueue.Remove() == 4)
                Console.WriteLine("3");

            Console.WriteLine("///////////////\n");

        }
    }

    class IntQueue
    {
        private int[] array;
        private int index;

        public IntQueue(int size)
        {
            array = new int[size];
            index = 0;
        }

        public bool Add(int value)
        {
            if (!IsFull())
            {
                array[index] = value;
                index++;
                return true;
            }
            return false;
        }
        public int Remove()
        {
            if (!IsEmpty())
            {
                int removed = array[0];
                // moving all values back by 1
                for (int i = 0; i < Count() - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                index--;
                return removed;
            }
            throw new Exception();
        }
        public int Count()
        {
            return index;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public bool IsFull()
        {
            return Count() == array.Length;
        }
    }

    class PriorityQueue
    {
        private int[] array;
        private int last = -1;

        public PriorityQueue(int size)
        {
            array = new int[size];
        }

        public bool Add(int value)
        {
            if (!IsFull())
            {
                array[++last] = value;
                RebuildUp(last);
                return true;
            }
            return false;
        }
        public int Remove()
        {
            if (!IsEmpty())
            {
                int removed = array[0];
                array[0] = array[last--];
                RebuildDown();

                return removed;
            }
            throw new Exception();
        }
        public int Count()
        {
            return last + 1;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public bool IsFull()
        {
            return Count() == array.Length;
        }

        private int LeftChild(int parent)
        {
            return parent * 2 + 1;
        }
        private int RightChild(int parent)
        {
            return parent * 2 + 2;
        }
        private int Parent(int child)
        {
            return (child - 1) / 2;
        }
        private void RebuildUp(int node)
        {
            // loopig throught the binary tree
            while (node > 0)
            {
                int nodeValue = array[node];
                int parentValue = array[Parent(node)];

                // switching values
                if (nodeValue > parentValue)
                {
                    array[Parent(node)] = nodeValue;
                    array[node] = parentValue;
                    // (array[Parent(node)], array[node]) = (array[node], array[Parent(node)]); // same thing

                    node = Parent(node);
                }
                else
                    break;
            }
        }
        private void RebuildDown()
        {
            int node = 0;

            while (node <= last)
            {
                int leftChildValue = array[LeftChild(node)];
                int rightChildValue = array[RightChild(node)];
                int nodeValue = array[node];

                if (nodeValue >= leftChildValue && nodeValue >= rightChildValue)
                    break;

                if (leftChildValue > rightChildValue)
                {
                    (array[node], array[LeftChild(node)]) = (array[LeftChild(node)], array[node]); // swaping
                    node = LeftChild(node);
                }
                else
                {
                    (array[node], array[RightChild(node)]) = (array[RightChild(node)], array[node]); // swaping
                    node = RightChild(node);
                }
            }
        }
    }
}
