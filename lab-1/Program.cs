using System;
using System.Linq;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindIndexOfMin(new int[] { 545, 123, 44, 22, 56, 765 }));
            Console.WriteLine(FindIndexOfMin(new int[] { }));

            Console.WriteLine(SumOfKDigitNumbears(new int[] { 1, 234, 2345, 2 }, 3));
            Console.WriteLine(SumOfKDigitNumbears(new int[] { }, 3));
            Console.WriteLine(SumOfKDigitNumbears(new int[] { 1, 234, 2345, 2 }, 1));

            Console.WriteLine(FindInSortedTable(new int[] { 1, 2, 3, 3, 2, 4 }, 2));
            Console.WriteLine(FindInSortedTable(new int[] { }, 2));
            Console.WriteLine(FindInSortedTable(new int[] { 1, 2, 3, 3, 2, 4 }, 0));
        }

        // zadanie 1
        public static int FindIndexOfMin(int[] array)
        {
            int index = -1;
            int number = 99; // Max two digit number
            for (int i = 0; i < array.Length; i++)
            {
                if (!(Math.Abs(array[i]) > 99 || Math.Abs(array[i]) < 10))
                {
                    if (array[i] <= number)
                    {
                        number = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        // zadanie 2
        public static long SumOfKDigitNumbears(int[] array, int k)
        {
            int sum = 0;
            long avg = 0;
            long endSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            if (array.Length > 0)
            {
                avg = sum / array.Length;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (!(array[i] / Math.Pow(10, k) > 1 || array[i] / Math.Pow(10, k - 1) < 1)) // if 2 digit
                {
                    if (array[i] < sum)
                    {
                        endSum += array[i];
                    }
                }
            }
            return endSum;
        }

        // zadanie 3
        public static int FindInSortedTable(int[] array, int k)
        {
            int temp = 0;
            int[] sortedArray = array;
            k++;
            for (int i = 0; i < sortedArray.Length; i++) // sorting sortedArray
            {
                for (int j = 0; j < sortedArray.Length - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        temp = sortedArray[j + 1];
                        sortedArray[j + 1] = sortedArray[j];
                        sortedArray[j] = temp;
                    }
                }
            }
            sortedArray = sortedArray.Distinct().ToArray();

            if (k > 0 && k <= sortedArray.Length)
            {
                return sortedArray[k - 1];
            }
            return -1;
        }
    }
}
