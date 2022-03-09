using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //long wartosc = 0;
            //wartosc = silnia(5);
            //Console.WriteLine($"wartość = {wartosc}");

            //int[] table = new int[] { 1, 3, 5, 1, 10, 15, 25 };
            //long wartosc = 0;
            //wartosc = sumaElementowTablicy(table);
            //Console.WriteLine($"Wartosc to: {wartosc}");

            //Console.WriteLine(iloscPowtorzenWTablicy(new int[] { 5, 5, 5, 4, 22, 2 }, 5));

            //fizBuzz();

            //Console.WriteLine($" wynik to: {PierwiastekKwadratowy(25, 5)}");
        }

        //5! = 1 * 2 * 3 * 4 * 5
        //n! = n* (n-1)
        //n! = n* ((n-1) * (n-2)!)
        //n! = n* (n-1) * (n-2) * (n-3)!
        //dla n >= 0

        static long Silnia(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Wartość nie może być mniejsza od zera");
            }
            if (n == 0)
            {
                return 1;
            }
            //Console.WriteLine($"n = {n}");
            return n * Silnia(n - 1);
        }


        // zadanie 1
        static long SumaElementowTablicy(int[] tablica, int i = 0)
        {
            if (i < 0)
            {
                throw new ArgumentException("Wartość nie może być mniejsza od zera");
            }
            if (i == tablica.Length)
            {
                return 0;
            }
            return tablica[i] + SumaElementowTablicy(tablica, i + 1);
        }

        // zadanie 2
        static int IloscPowtorzenWTablicy(int[] tablica, int wyjatkowe, int iloscWyjatkowych = 0, int i = 0)
        {
            if (i == tablica.Length - 1)
            {
                if (tablica[i] == wyjatkowe)
                {
                    return iloscWyjatkowych++;
                }
                return iloscWyjatkowych;
            }
            if (tablica[i] == wyjatkowe)
            {
                iloscWyjatkowych++;
            }
            return IloscPowtorzenWTablicy(tablica, wyjatkowe, iloscWyjatkowych, i + 1);
        }

        // zadanie 3
        static int FizBuzz(int i = 0, int m = 100, int fiz = 0, int buzz = 0)
        {
            if (i >= m)
            {
                return 0;
            }
            string odpowiedz = "";

            if (fiz == 3)
            {
                odpowiedz += "Fiz";
                fiz = 0;
            }
            if (buzz == 5)
            {
                odpowiedz += "Buzz";
                buzz = 0;
            }
            if (odpowiedz == "")
            {
                odpowiedz = i.ToString();
            }

            Console.WriteLine(odpowiedz);

            return FizBuzz(i + 1, m, fiz + 1, buzz + 1);
        }

        // zadanie 4
        static long PierwiastekKwadratowy(long s, long n, long i = 0, long xn = 0)
        {
            if (i == n)
            {
                return (xn + s / xn) / 2;
            }
            if (i == 0)
            {
                xn = s / 2;
            }
            else
            {
                long nextXN = (xn + s / xn) / 2;
                xn = nextXN;
            }

            Console.WriteLine($"xn = {xn}");



            return PierwiastekKwadratowy(s, n, i + 1, xn);
        }
    }
}
