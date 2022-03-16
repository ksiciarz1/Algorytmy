using System;
using System.Collections.Generic;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 2; i < 20; i++)
            //{
            //    Console.WriteLine($"Petla: {i}");
            //    Console.WriteLine(fib(i));
            //    Console.WriteLine(fibZMemorzacja(i));
            //}

            Item[] items = new Item[15];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
            }
            Kufer(items, 15);
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

        // zadanie 2
        static int Kufer(Item[] items, int iloscPrzegrudek)
        {
            ItemStruck[] itemStuckArray = new ItemStruck[items.Length];
            int pozostalePrzegrodki = iloscPrzegrudek;
            int suma = 0;
            List<Item> itemsInside = new List<Item>();

            // tworzenie tablicy z odwolaniami do przedmiotow
            for (int i = 0; i < items.Length; i++)
            {
                itemStuckArray[i] = new ItemStruck(i, items[i].wartosc / items[i].iloscPrzegrodek);
            }

            // sortowanie malejąco względem wartości/ilość zajmowanych przegródek
            for (int i = 0; i < itemStuckArray.Length; i++)
            {
                for (int j = 0; j < itemStuckArray.Length - 1; j++)
                {
                    if (itemStuckArray[j].wazonaWartosc < itemStuckArray[j + 1].wazonaWartosc)
                    {
                        ItemStruck temp = itemStuckArray[j];
                        itemStuckArray[j] = itemStuckArray[j + 1];
                        itemStuckArray[j + 1] = temp;
                    }
                }
            }

            // wypełnianie kufra
            for (int i = 0; i < iloscPrzegrudek; i++)
            {
                if (pozostalePrzegrodki == 0)
                {
                    break;
                }
                if (pozostalePrzegrodki - items[itemStuckArray[i].itemId].iloscPrzegrodek >= 0)
                {
                    itemsInside.Add(items[itemStuckArray[i].itemId]);
                    pozostalePrzegrodki -= items[itemStuckArray[i].itemId].iloscPrzegrodek;
                    suma += items[itemStuckArray[i].itemId].wartosc;
                }
            }
            for (int i = 0; i < itemsInside.Count; i++)
            {
                Console.WriteLine($"Przedmiot {i}: wartosc {itemsInside[i].wartosc}, zajmowane przegrodki {itemsInside[i].iloscPrzegrodek}");
            }
            Console.WriteLine($"Pozostałe miejsce: {pozostalePrzegrodki}");
            return suma;
        }
    }
    public class Item
    {
        public int wartosc;
        public int iloscPrzegrodek;
        public Item()
        {
            Random random = new Random();
            wartosc = random.Next(1, 11);
            iloscPrzegrodek = random.Next(1, 5);

            if (iloscPrzegrodek == 3)
            {
                iloscPrzegrodek = 2;
            }
        }
        public Item(int wartosc, int iloscPrzegrodek)
        {
            this.wartosc = wartosc;
            this.iloscPrzegrodek = iloscPrzegrodek;
        }
    }
    public struct ItemStruck
    {
        public int itemId;
        public int wazonaWartosc;

        public ItemStruck(int itemId, int wazonaWartosc)
        {
            this.itemId = itemId;
            this.wazonaWartosc = wazonaWartosc;
        }
    }
}
