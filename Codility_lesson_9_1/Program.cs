using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_9_1
{
    /// <summary>
    /// CODILITY: Lesson 9 - Maximum slice problem, Task 1 - MaxProfit
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
            //int[] testData_3 = { -6, -4 };
            //Console.WriteLine(FindMaxSumSlice(testData_3));  // Expected correct result = 0
            //int[] testData_4 = { -6, -11 };
            //Console.WriteLine(FindMaxSumSlice(testData_4));  // Expected correct result = 0
            int[] testData_5 = { -2, 3 };
            Console.WriteLine(FindMaxSumSlice(testData_5));  // Expected correct result = 3


            Console.WriteLine();
            int[] testData_100 = { 23171, 21011, 21123, 21366, 21013, 21367};
            Console.WriteLine(CalculateMaxPossibleProfit(testData_100));  // Expected correct result = 356
            int[] testData_101 = { 17, 16, 11, 8, 4, 1 };
            Console.WriteLine(CalculateMaxPossibleProfit(testData_101));  // Expected correct result = 0
            int[] testData_102 = { 17, 16, 11, 13, 4, 1 };
            Console.WriteLine(CalculateMaxPossibleProfit(testData_102));  // Expected correct result = 2

        }

        public static int CalculateMaxPossibleProfit(int[] A)
        {
            int N = A.Length;
            int maxProfit = 0;
            int maxProfitIfMonetizedOnThisDay = 0;

            for (int i = 1; i < N; i++)
            {
                int changeInStockPrice = A[i] - A[i - 1];

                maxProfitIfMonetizedOnThisDay = Math.Max(0, maxProfitIfMonetizedOnThisDay + changeInStockPrice);

                if (maxProfitIfMonetizedOnThisDay > maxProfit)
                    maxProfit = maxProfitIfMonetizedOnThisDay;
            }

            return maxProfit;
        }

        public static int FindMaxSumSlice(int[] A)
        {
            int maxSlice = 0;
            int maxSliceEndingAtLastIndex = 0;

            foreach (int a in A)
            {
                maxSliceEndingAtLastIndex = 
                    maxSliceEndingAtLastIndex + a > 0 ? 
                    maxSliceEndingAtLastIndex + a : 0;


                //   * 1-st way of doing the selection *
                //if (maxSliceEndingAtLastIndex > maxSlice)
                //    maxSlice = maxSliceEndingAtLastIndex;

                //   * 2-nd way to do the same *
                //maxSlice =
                //    maxSlice > maxSliceEndingAtLastIndex ?
                //    maxSlice : maxSliceEndingAtLastIndex;

                //   * 3-rd way to do the same *
                maxSlice = Math.Max(maxSlice, maxSliceEndingAtLastIndex);
            }

            return maxSlice;
        }

    }
}
