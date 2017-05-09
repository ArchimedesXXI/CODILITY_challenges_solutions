using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] TestArray = { -4, 18, -27, -4, 15, -27, -27, 18, -27 };

            Console.WriteLine(FindOddOccurringNumber(TestArray));

        }

        /// <summary>
        /// Returns the value of the element, that has no pair.
        /// </summary>
        /// <param name="A">An none-empty, odd-numbered array containing unordered pairs of same values along with exactly one value without a pair.</param>
        /// <returns>The value of the element without a pair.</returns>
        static public int FindOddOccurringNumber(int[] A)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A));
            if (A.Length == 0)
                throw new ArgumentException("The array supplied should be none-empty.", nameof(A));
            if (A.Length % 2 != 1)
                throw new ArgumentException("The array supplied should be odd-numbered (should have an odd number of elements).", nameof(A));

            Dictionary<int, bool> HasOccuredEvenTimes = new Dictionary<int, bool>();

            foreach (int element in A)
            {
                bool contains = HasOccuredEvenTimes.ContainsKey(element);

                if (contains)
                    HasOccuredEvenTimes[element] = !HasOccuredEvenTimes[element];
                else
                    HasOccuredEvenTimes.Add(element, false);
            }

            foreach (KeyValuePair<int, bool> entry in HasOccuredEvenTimes)
            {
                if (entry.Value == false)
                    return entry.Key;
            }

            throw new ArgumentException("The array supplied should contain exactly one unpaired element.", nameof(A));
        }


    }
}
