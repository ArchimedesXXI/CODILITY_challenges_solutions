using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_6_3
{
    /// <summary>
    /// CODILITY: Lesson 6 - Sorting, Task 3 - Triangle
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData0 = { 10, 2, -6, 5, 1, 8, 20, -18 };
            int[] testData1 = { 10, 50, 5, 1, -2, -7, -3, -4, -12 };
            int[] testData2 = { int.MaxValue - 1, int.MaxValue - 1, int.MaxValue, int.MinValue, int.MinValue };
            Console.WriteLine( ContainsValidTriangle(testData0) );  // Expected correct result = True
            Console.WriteLine( ContainsValidTriangle(testData1) );  // Expected correct result = False
            Console.WriteLine( ContainsValidTriangle(testData2) );  // Expected correct result = True
        }

        static int ContainsValidTriangle_Adapter(int[] A)
        {
            bool result = ContainsValidTriangle(A);

            if (result)
                return 1;
            else
                return 0;
        }

        static bool ContainsValidTriangle(int[] A)
        {
            int N = A.Length;

            List<int> B = A.ToList();
            B.Sort();

            for (int i = 1; i < N - 1; i++)
            {
                if ((long)B[i - 1] + (long)B[i] > B[i + 1])
                    return true;
            }

            return false;
        }

    }
}
