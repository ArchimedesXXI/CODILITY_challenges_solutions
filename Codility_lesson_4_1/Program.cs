using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_4_1
{
    /// <summary>
    /// CODILITY: Lesson 4 - Counting Elements, Task 1 - MissingInteger
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testInput = { 1, 3, 6, -16, 4, 1, 13, 2, 0, 7, -8, 1, 2, 7 };
            Console.WriteLine( FindSmallestMissingPositiveInteger(testInput) );
            Console.WriteLine( FindSmallestMissingPositiveInteger_simpler(testInput) );
        }

        static int FindSmallestMissingPositiveInteger(int[] A)
        {
            int N = A.Length;
            HashSet<int> PossiblePositiveIntegers = new HashSet<int>(Enumerable.Range(1, N + 1));

            foreach(int a in A)
            {
                if (PossiblePositiveIntegers.Contains(a))
                    PossiblePositiveIntegers.Remove(a);
            }


            int min = PossiblePositiveIntegers.FirstOrDefault();

            foreach(int element in PossiblePositiveIntegers)
            {
                if (element < min)
                    min = element;
            }

            return min;
        }

        static int FindSmallestMissingPositiveInteger_simpler(int[] A)
        {
            int N = A.Length;
            HashSet<int> PossiblePositiveIntegers = new HashSet<int>(Enumerable.Range(1, N + 1));

            foreach (int a in A)
            {
                // I don't have to check if the element is in the set. If it's not it doesn't cause any error anyway.
                PossiblePositiveIntegers.Remove(a);
            }

            // I can immediately return the first element of the HashSet, because in C# HashSets are ordered and indexable 
            // and I know, that the first element remaining in my Set will be the smallest, 
            // because they where created in an ordered in the Set (this is how the Enumerable.Range() method works).  
            return PossiblePositiveIntegers.ElementAt(0);
        }

    }
}
