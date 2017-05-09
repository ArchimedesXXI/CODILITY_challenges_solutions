using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_6_1
{
    /// <summary>
    /// CODILITY: Lesson 6 - Sorting, Task 1 - Distinct
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = { 15, -17, 8, 8, 3, -17, 15, 0, 8, 15, 8, 8, 8, 15 };
            Console.WriteLine( GetNumberOfDistinctValues_solution0(testData) );  // Expected correct result = 5
            Console.WriteLine( GetNumberOfDistinctValues_solution1(testData) );  // Expected correct result = 5
            Console.WriteLine( GetNumberOfDistinctValues_solution2(testData) );  // Expected correct result = 5
        }

        static int GetNumberOfDistinctValues_solution0(int[] A)
        {
            int[] DistinctElements = A.Distinct().ToArray();
            return DistinctElements.Length;
        }


        static int GetNumberOfDistinctValues_solution1(int[] A)
        {
            HashSet<int> DistinctElements = new HashSet<int>(A);
            return DistinctElements.Count;
        }


        static int GetNumberOfDistinctValues_solution2(int[] A)
        {
            HashSet<int> DistinctElements = new HashSet<int>();

            foreach (int element in A)
            {
                DistinctElements.Add(element);
            }

            return DistinctElements.Count;
        }



    }
}
