using System;
using System.Collections.Generic;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int punkty = 0;
            if (Zadane1("zakaz") && !Zadane1("robot") && Zadane1(""))
                punkty++;

            if (Zadanie2("abccca").Equals("ccc") && Zadanie2("abcccaddd").Equals("ccc") && Zadanie2("abcd").Equals("a"))
                punkty++;

            if (Zadanie3("abc", "cba") && !Zadanie3("abc", "caba") && Zadanie3("aabbcc", "abcabc") && Zadanie3("a", "a") && Zadanie3("", "") && !Zadanie3("aaaa", "aaac"))
                punkty++;

            if (Zadanie4("100000", "911111").Equals("1011111"))
                punkty++;

            if (Zadanie5("abcdabcd", 4).Equals("abcd\nabcd"))
                punkty++;

            Console.WriteLine(punkty);
        }

        // Czy łańcuch wejściowy jest palingonem
        public static bool Zadane1(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                    return false;
            }
            return true;
        }

        // Znajdź i zwróć pierwszy najdłuższy fragmenty złożony z jednakowych znaków
        public static string Zadanie2(string input)
        {
            string returnString = "";
            string tempString = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (tempString.Equals("") || tempString[0] == input[input.Length - i - 1])
                {
                    // Searching from back
                    tempString += input[input.Length - i - 1];
                    if (input.Length - i - 1 == 0)
                    {
                        if (tempString.Length >= returnString.Length)
                            returnString = tempString;
                        tempString = "" + input[input.Length - i - 1];
                    }
                }
                else // Same char string ended
                {
                    if (tempString.Length >= returnString.Length)
                        returnString = tempString;
                    tempString = "" + input[input.Length - i - 1]; // Resetting the string to 1 length
                }

                // If no string was found return first character
                if (i == input.Length - 1 && returnString.Length <= 1)
                {
                    return "" + input[0];
                }
            }
            return returnString;
        }

        // Sprawdź czy te łańcuchy są anagramami
        public static bool Zadanie3(string input1, string input2)
        {
            // Edge cases
            if (input1.Length != input2.Length)
                return false;
            if (input1.Equals(input2))
                return true;

            Dictionary<char, int> dictionatyInput1 = new();
            Dictionary<char, int> dictionatyInput2 = new();

            // Adds all characters to directories
            foreach (char character in input1)
            {
                // First value can't be incremented
                if (!dictionatyInput1.ContainsKey(character))
                    dictionatyInput1[character] = 0;
                dictionatyInput1[character]++;
            }
            foreach (char character in input2)
            {
                // First value can't be incremented
                if (!dictionatyInput2.ContainsKey(character))
                    dictionatyInput2[character] = 0;
                dictionatyInput2[character]++;
            }


            if (dictionatyInput1.Count != dictionatyInput2.Count)
                return false;

            // Looks if in both directories there are the same number of characters
            foreach (char character in input1)
                if (!(dictionatyInput1[character] == dictionatyInput2[character]))
                    return false;

            return true;

        }

        // Dodawanie dwóch liczb całkowitych zapisanych w łańcuchu
        public static string Zadanie4(string input1, string input2)
        {
            string returnString = "";
            // Dodawnie w słupku
            input1.PadLeft(input2.Length, '0');
            input2.PadLeft(input1.Length, '0');

            for (int i = 0; i < input1.Length; i++)
            {
                int val1 = int.Parse(input1[i].ToString());
                int val2 = int.Parse(input2[i].ToString());
                if (val1 + val2 >= 10)
                {
                    if (returnString.Equals(""))
                    {
                        returnString += val1 + val2;
                    }
                    else
                    {
                        returnString =
                            returnString.Substring(0, i - 1)
                            + (returnString[i] + (int)(val1 + val2 / 10))
                            + (val1 + val2 - 10);
                    }
                }
                else
                {
                    returnString += val1 + val2;
                }
            }
            return returnString;
        }

        // Formatowanie do łańcucha o długości nie większej niż n
        public static string Zadanie5(string input, int n)
        {
            string returnString = "";
            // Ambitnie bez łamania słów
            for (int i = 1; i < input.Length; i++)
            {
                if (i % n == 0)
                {
                    returnString = input.Substring(0, i) + "\n" + input.Substring(i);
                }
            }
            return returnString;
        }
    }

}
