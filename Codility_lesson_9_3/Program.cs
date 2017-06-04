using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_9_3
{
    /// <summary>
    /// CODILITY: Lesson 9 - Maximum slice problem, Task 3 - MaxDoubleSiceSum
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 0, 0 } );      // Expected correct result:  sum = 0, indexes = [0, 1]
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 88, 144 } );   // Expected correct result: sum = 0, indexes = [0, 1]
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 0, 1, 15} );   // Expected correct result: sum = 1, indexes = [0, 2]
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 148, 1, 642 } );  // Expected correct result: sum = 1, indexes = [0, 2]
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 1428, 1, 15, 7777 });   // Expected correct result: sum = 16, indexes = [0, 3]
            FindMaxSliceExcludingItsBorders_TEST(new int[] { 5, 17, 0, 3 });   // Expected correct result: sum = 17, indexes = [0, 3]

            Console.WriteLine();
            FindMaxDubleSlice_TEST(new int[] { 48, 152, 17 } );   // Expected correct result = 0
            FindMaxDubleSlice_TEST(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 } );   // Expected correct result = 17
            FindMaxDubleSlice_TEST(new int[] { 5, 17, 0, 3 } );   // Expected correct result = 17
            FindMaxDubleSlice_TEST(new int[] { 0, 10, -5, -2, 0 } );   // Expected correct result = 10
            FindMaxDubleSlice_TEST(new int[] { 5, 0, 1, 0, 5 });   // Expected correct result = 1
        }


        public static int FindMaxDubleSlice(int[] A)
        {
            int N = A.Length;
            Tuple<int, int, int> maxSlice = FindMaxSliceExcludingItsBorders(A);
            int singleSliceSum = maxSlice.Item1;
            int start_i = maxSlice.Item2;
            int end_i = maxSlice.Item3;
            int maxDoubleSum = 0;
            int appendixSum = 0;

            for (int i = start_i+1; i <= end_i-1; i++)
            {
                maxDoubleSum = Math.Max(singleSliceSum - A[i], maxDoubleSum);
            }

            for (int i = start_i-1; i >= 0; i--)
            {
                maxDoubleSum = Math.Max(singleSliceSum + appendixSum, maxDoubleSum);
                appendixSum += A[i];
            }

            for (int i = end_i+1; i < N; i++)
            {
                maxDoubleSum = Math.Max(singleSliceSum + appendixSum, maxDoubleSum);
                appendixSum += A[i];
            }

            return maxDoubleSum;
        }


        public static Tuple<int, int, int> FindMaxSliceExcludingItsBorders(int[] A)
        {
            int N = A.Length;
            int start_max_i = 0;
            int start_i = 0;
            int end_max_i = 1;
            int end_i = 1;
            int maxSliceEndingAtLastIndex = 0;
            int maxSlice = 0;

            while (end_i < N-1)
            {
                end_i += 1;

                if (maxSliceEndingAtLastIndex + A[end_i-1] >= 0)
                {
                    maxSliceEndingAtLastIndex = maxSliceEndingAtLastIndex + A[end_i-1];
                }
                else
                {
                    maxSliceEndingAtLastIndex = 0;
                    start_i = end_i-1;
                }

                if (maxSliceEndingAtLastIndex >= maxSlice)
                {
                    maxSlice = maxSliceEndingAtLastIndex;
                    start_max_i = start_i;
                    end_max_i = end_i;
                }
            }

            return new Tuple<int, int, int>(maxSlice, start_max_i, end_max_i);
        }


        #region TEST functions:
        public static void FindMaxSliceExcludingItsBorders_TEST(int[] test_data)
        {
            Tuple<int, int, int> result = FindMaxSliceExcludingItsBorders(test_data);
            Console.WriteLine($"sum = {result.Item1}, indexes = [{result.Item2}, {result.Item3}]");
        }

        public static void FindMaxDubleSlice_TEST(int[] test_data)
        {
            Console.WriteLine(FindMaxDubleSlice(test_data));
        }
        #endregion
    }
}
