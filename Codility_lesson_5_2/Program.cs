using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_5_2
{
    /// <summary>
    /// CODILITY: Lesson 5 - Prefix Sums, Task 2 - PassingCars
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData0 = { 0, 1, 0, 1, 1 };    //expected correct outcome = 5
            int[] testData1 = { 0, 1 };             //expected correct outcome = 1
            int[] testData2 = { 1, 0 };             //expected correct outcome = 0

            Console.WriteLine(FindNumberOfPassingCars(testData0));
            Console.WriteLine(FindNumberOfPassingCars(testData1));
            Console.WriteLine(FindNumberOfPassingCars(testData2));
        }


        static int FindNumberOfPassingCars(int[] A)
        {
            int N = A.Length;
            int sumOfPassingCars = 0;
            int PrefixSum = 0;

            for (int i = N-1; i > -1; i--)
            {
                if (A[i] == 1)
                    PrefixSum++;
                else if (A[i] == 0)
                    sumOfPassingCars += PrefixSum;
                else
                    throw new ArgumentException("Array passed in should contain only 1's or 0's.", nameof(A));

                // special case in specification
                if (sumOfPassingCars > 1000000000)
                    return -1;
            }

            return sumOfPassingCars;
        }


    }
}
