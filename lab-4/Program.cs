using System;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tablica = new int[] { 2, 7, 5, 4, 7, 0, 4 };
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.Write($"{tablica[i]}, ");
            }
            Console.WriteLine("\n");
            int[] tablica2 = SortowaniePrezWstawianie(tablica);
            for (int i = 0; i < tablica2.Length; i++)
            {
                Console.Write($"{tablica2[i]}, ");
            }

            Console.WriteLine("\n\n--------------\n\n");

            int[] tablica3 = new int[] { 2, 7, 5, 4, 7, 0, 4 };
            for (int i = 0; i < tablica3.Length; i++)
            {
                Console.Write($"{tablica3[i]}, ");
            }
            Console.WriteLine("\n");
            int[] tablica4 = SortowaniePrzezWybieranie(tablica3);
            for (int i = 0; i < tablica4.Length; i++)
            {
                Console.Write($"{tablica4[i]}, ");
            }
        }

        static public int[] SortowaniePrezWstawianie(int[] tablicaDoSortowania, bool rosnaco = true)
        {
            if (tablicaDoSortowania.Length <= 1)
            {
                throw new ArgumentException("tablica musi być większa niż 1", nameof(tablicaDoSortowania));
            }

            int[] posortowanaTablica = tablicaDoSortowania;

            for (int i = 1; i < tablicaDoSortowania.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (rosnaco)
                    {
                        if (posortowanaTablica[i] < posortowanaTablica[j])
                        {
                            int temp = posortowanaTablica[j];
                            posortowanaTablica[j] = posortowanaTablica[i];
                            posortowanaTablica[i] = temp;
                        }
                    }
                    else
                    {
                        if (posortowanaTablica[i] > posortowanaTablica[j])
                        {
                            int temp = posortowanaTablica[j];
                            posortowanaTablica[j] = posortowanaTablica[i];
                            posortowanaTablica[i] = temp;
                        }
                    }
                }

            }

            return posortowanaTablica;
        }

        static public int[] SortowaniePrzezWybieranie(int[] tablicaDoSortowania, bool rosnoca = true)
        {
            if (tablicaDoSortowania.Length <= 1)
            {
                throw new ArgumentException("tablica musi być większa niż 1", nameof(tablicaDoSortowania));
            }

            int[] posorotowanaTablica = tablicaDoSortowania;

            for (int i = 0; i < tablicaDoSortowania.Length; i++)
            {
                int minimum = rosnoca ? int.MaxValue : int.MinValue;
                int indexOfMinimum = -1;
                for (int j = i; j < tablicaDoSortowania.Length; j++)
                {
                    if (rosnoca)
                    {
                        if (minimum > posorotowanaTablica[j])
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;

                        }
                    }
                    else
                    {
                        if (minimum < posorotowanaTablica[j])
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;
                        }

                    }
                }
                if (indexOfMinimum != -1)
                {
                    int temp = posorotowanaTablica[i];
                    posorotowanaTablica[i] = minimum;
                    posorotowanaTablica[indexOfMinimum] = temp;
                }
            }
            return posorotowanaTablica;
        }
    }
}
