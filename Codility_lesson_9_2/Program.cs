using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_9_2
{
    /// <summary>
    /// CODILITY: Lesson 9 - Maximum slice problem, Task 2 - MaxSiceSum
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData_0 = { 0 };
            Console.WriteLine(FindMaxSumSlice(testData_0));  // Expected correct result = 0
            int[] testData_1 = { 5, -7, 3, 5, -2, 4, -1 };
            Console.WriteLine(FindMaxSumSlice(testData_1));  // Expected correct result = 10
            int[] testData_2 = { 3, 2, -6, 4, 0 };
            Console.WriteLine(FindMaxSumSlice(testData_2));  // Expected correct result = 5
            int[] testData_3 = { -6, -4 };
            Console.WriteLine(FindMaxSumSlice(testData_3));  // Expected correct result = -4
            int[] testData_4 = { -6, -11 };
            Console.WriteLine(FindMaxSumSlice(testData_4));  // Expected correct result = -6
            int[] testData_5 = { -2, 3 };
            Console.WriteLine(FindMaxSumSlice(testData_5));  // Expected correct result = 3
            int[] testData_6 = { -2, 3, 1 };
            Console.WriteLine(FindMaxSumSlice(testData_6));  // Expected correct result = 4

        }

        public static int FindMaxSumSlice(int[] A)
        {
            int maxSlice = A[0];
            int maxSliceEndingAtLastIndex = 0;

            for (int i = 0; i < A.Length; i++)
            {
                maxSliceEndingAtLastIndex =
                    maxSliceEndingAtLastIndex + A[i] > A[i] ?
                    maxSliceEndingAtLastIndex + A[i] : A[i];

                maxSlice = Math.Max(maxSlice, maxSliceEndingAtLastIndex);
            }

            return maxSlice;
        }

    }
}
