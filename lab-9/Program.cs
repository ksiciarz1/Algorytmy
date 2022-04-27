using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            StringHashTab stringHashTab = new StringHashTab();
            stringHashTab.Add("asddsa");
            stringHashTab.Add("aassdd");
            stringHashTab.Contains("asddsa");
            stringHashTab.Remove("asddsa");
            stringHashTab.Contains("asddsa");
            stringHashTab.Contains("aassdd");

            stringHashTab.Add("sfgsfg");
            stringHashTab.Add("sfgsfgfds");
            stringHashTab.Add("sfgsfgjghj");
            stringHashTab.Add("sfgsfgkytui");

            foreach (var item in stringHashTab)
            {
                Console.WriteLine(item);
            }
        }
    }

    class StringHashTab : IEnumerable<string>
    {
        static readonly int Capacity = 101;
        private List<string>[] _stringListArray = new List<string>[Capacity];

        public StringHashTab() { }

        /// <summary>
        /// Gets hash from given value specified for use in this class
        /// </summary>
        /// <param name="value">Value to get hash from</param>
        /// <returns>Absolute modulo from hash of value</returns>
        private static int GetHashValue(string value)
        {
            return Math.Abs(value.GetHashCode() % Capacity);
        }

        /// <summary>
        /// Adds string to hash tab
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <returns>True if added, false if cannot add</returns>
        public bool Add(string value)
        {
            int hashValue = Math.Abs(value.GetHashCode() % Capacity);
            if (_stringListArray[hashValue] == null)
            {
                _stringListArray[hashValue] = new List<string>();
                _stringListArray[hashValue].Add(value);
                return true;
            }

            if (_stringListArray[hashValue].Contains(value))
                return false;

            _stringListArray[hashValue].Add(value);
            return true;
        }

        /// <summary>
        /// Removes value from hash tab
        /// </summary>
        /// <param name="value">value to be removed</param>
        /// <returns>True if removed, false if cannot remove
        /// or the value wasn't there</returns>
        public bool Remove(string value)
        {
            int hashValue = GetHashValue(value);
            if (_stringListArray[hashValue] == null)
                return false;

            return _stringListArray[hashValue].Remove(value);
        }

        /// <summary>
        /// Chacks if value is contained in hash tab
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if contains, false otherwise</returns>
        public bool Contains(string value)
        {
            int hashValue = GetHashValue(value);
            if (_stringListArray[hashValue] == null)
                return false;

            return _stringListArray[hashValue].Contains(value);
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var list in _stringListArray)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
