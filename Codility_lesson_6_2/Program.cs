using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_6_2
{
    /// <summary>
    /// CODILITY: Lesson 6 - Sorting, Task 2 - MaxProductOfThree
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData0 = { -3, 6, 1, 5, 2, -2 };
            int[] testData1 = { -5, -6, -4, -7, -10 };
            Console.WriteLine( FindMaximumProductOfThreeNumbersFromArray(testData0) );  // Expected correct result = 60
            Console.WriteLine( FindMaximumProductOfThreeNumbersFromArray(testData1) );  // Expected correct result = -120
        }

        static int FindMaximumProductOfThreeNumbersFromArray( int[] A)
        {
            int N = A.Length;

            A = A.OrderByDescending(p => p).ToArray(); 

            return  A[0] * A[1] * A[2] > A[0] * A[N - 1] * A[N - 2] 
                    ? 
                    A[0] * A[1] * A[2] 
                    : 
                    A[0] * A[N - 1] * A[N - 2];
        }

    }
}
