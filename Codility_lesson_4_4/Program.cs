using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_4_4
{
    /// <summary>
    /// CODILITY: Lesson 4 - Counting Elements, Task 4 - MaxCounters
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations_Test0 = new int[] { 3, 4, 4, 6, 1, 4, 4};
            int N_Test0 = 5;
            Console.WriteLine( String.Join(", ", CalculateEndstateOfCounters_very_slow(N_Test0, operations_Test0)) );
            Console.WriteLine(String.Join(", ", CalculateEndstateOfCounters_fast_and_correct(N_Test0, operations_Test0)));
        }


        static int[] CalculateEndstateOfCounters_fast_and_correct(int N, int[] A)
        {
            int currentMax = 0;
            // The Key [-1] is a "wild card" - it keeps the value of all counters, that do not have there own Key in the dictionary yet. 
            Dictionary<int, int> HashTableOfCounters = new Dictionary<int, int>() { [-1] = 0 };

            foreach (int counterNumber in A)
            {
                if (counterNumber >= 1 && counterNumber <= N)
                {
                    if (HashTableOfCounters.ContainsKey(counterNumber))
                        HashTableOfCounters[counterNumber]++;
                    else
                        HashTableOfCounters.Add(counterNumber, HashTableOfCounters[-1] + 1);

                    if (currentMax < HashTableOfCounters[counterNumber])
                        currentMax = HashTableOfCounters[counterNumber];
                }
                else if (counterNumber == N + 1)
                {
                    HashTableOfCounters = new Dictionary<int, int>() { [-1] = currentMax };
                }
            }

            int[] Counters = new int[N];

            for (int i = 0; i < N; i++)
            {
                if (HashTableOfCounters.ContainsKey(i + 1))
                    Counters[i] = HashTableOfCounters[i + 1];
                else
                    Counters[i] = HashTableOfCounters[-1];
            }

            return Counters;
        }


        static int[] CalculateEndstateOfCounters_very_slow(int N, int[] A)
        {
            int[] Counters = new int[N];
            int M_numOfOperations = A.Length;

            int currentMax = 0;

            foreach (int operation_code in A)
            {
                if (operation_code >= 1 && operation_code <= N)
                {
                    //increase X-th counter by 1
                    Counters[operation_code - 1] = Counters[operation_code - 1] + 1;

                    if (currentMax < Counters[operation_code - 1])
                        currentMax = Counters[operation_code - 1];
                }
                else if (operation_code == N + 1)
                {
                    //max counter − all counters are set to the maximum value of any counter
                    Counters = Enumerable.Repeat<int>(currentMax, N).ToArray();
                }
                else
                {
                    throw new ArgumentException("The values in array passed in, are out of range allowed by specification.", nameof(A));
                }
            }

            return Counters;
        }


    }
}
