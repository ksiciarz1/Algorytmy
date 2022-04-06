using System;

namespace lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue(3);
            queue.Add(4);
            queue.Add(6);
            queue.Add(10);
            if (queue.Count() == 3)
            {
                Console.WriteLine("1");
            }
            if (queue.Remove() == 4)
            {
                Console.WriteLine("2");
            }
            if (queue.Count() == 2)
            {
                Console.WriteLine("3");
            }

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
                for (int i = 0; i < Count()-1; i++)
                {
                    array[i] = array[i+1];
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

    //class priorityQueue
    //{
    //    private int[] array;
    //    private int lastIndex;

    //    public priorityQueue()
    //    {

    //    }

    //    public bool Insert(int value)
    //    {

    //    }
    //    public int Remove()
    //    {

    //    }
    //    public int Count()
    //    {
    //        return count;
    //    }
    //    public bool IsEmpty()
    //    {
    //        return Count() == 0;
    //    }
    //    public bool IsFull()
    //    {
    //        return Count() == array.Length;
    //    }
    //}
}
