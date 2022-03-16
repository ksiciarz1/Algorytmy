using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 20; i++)
            {
                Console.WriteLine($"Petla: {i}");
                Console.WriteLine(fib(i));
                Console.WriteLine(fibZMemorzacja(i));
            }
        }

        static long fib(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            return fib(n - 1) + fib(n - 2);
        }

        // zadanie 1
        static long fibZMemorzacja(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            int n1 = 1;
            int n2 = 1;
            int wynik = 1;
            for (int i = 1; i < n; i++)
            {
                wynik = n1 + n2;
                n2 = n1;
                n1 = wynik;
            }
            return wynik;
        }
    }
}
