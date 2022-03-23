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

            //String

            Console.WriteLine("\n\n----Strings----\n");
            string[] tablica5 = new string[] { "asss", "fddd", "bggg", "errr" };
            for (int i = 0; i < tablica5.Length; i++)
            {
                Console.Write($"{tablica5[i]}, ");
            }
            Console.WriteLine("\n");
            string[] tablica6 = SortowaniePrezWstawianie(tablica5);
            for (int i = 0; i < tablica6.Length; i++)
            {
                Console.Write($"{tablica6[i]}, ");
            }

            Console.WriteLine("\n\n--------------\n\n");

            string[] tablica7 = new string[] { "asss", "fddd", "bggg", "errr" };
            for (int i = 0; i < tablica7.Length; i++)
            {
                Console.Write($"{tablica7[i]}, ");
            }
            Console.WriteLine("\n");
            string[] tablica8 = SortowaniePrezWstawianie(tablica7);
            for (int i = 0; i < tablica8.Length; i++)
            {
                Console.Write($"{tablica8[i]}, ");
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
        static public string[] SortowaniePrezWstawianie(string[] tablicaDoSortowania, bool rosnaco = true)
        {
            if (tablicaDoSortowania.Length <= 1)
            {
                throw new ArgumentException("tablica musi być większa niż 1", nameof(tablicaDoSortowania));
            }

            string[] posortowanaTablica = tablicaDoSortowania;

            for (int i = 1; i < tablicaDoSortowania.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (rosnaco)
                    {
                        if (posortowanaTablica[i].CompareTo(posortowanaTablica[j]) < 0)
                        {
                            string temp = posortowanaTablica[j];
                            posortowanaTablica[j] = posortowanaTablica[i];
                            posortowanaTablica[i] = temp;
                        }
                    }
                    else
                    {
                        if (posortowanaTablica[i].CompareTo(posortowanaTablica[j]) > 0)
                        {
                            string temp = posortowanaTablica[j];
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
        static public string[] SortowaniePrzezWybieranie(string[] tablicaDoSortowania, bool rosnoca = true)
        {
            if (tablicaDoSortowania.Length <= 1)
            {
                throw new ArgumentException("tablica musi być większa niż 1", nameof(tablicaDoSortowania));
            }

            string[] posorotowanaTablica = tablicaDoSortowania;

            for (int i = 0; i < tablicaDoSortowania.Length; i++)
            {
                string minimum = " ";
                int indexOfMinimum = -1;
                for (int j = i; j < tablicaDoSortowania.Length; j++)
                {
                    if (rosnoca)
                    {
                        if (minimum == " ")
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;
                        }
                        else if (minimum.CompareTo(posorotowanaTablica[j]) < 0)
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;
                        }
                    }
                    else
                    {
                        if (minimum == " ")
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;
                        }
                        else if (minimum.CompareTo(posorotowanaTablica[j]) > 0)
                        {
                            minimum = posorotowanaTablica[j];
                            indexOfMinimum = j;
                        }
                    }
                }
                if (indexOfMinimum != -1)
                {
                    string temp = posorotowanaTablica[i];
                    posorotowanaTablica[i] = minimum;
                    posorotowanaTablica[indexOfMinimum] = temp;
                }
            }
            return posorotowanaTablica;
        }
    }
}
