using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_3_3
{
    /// <summary>
    /// CODILITY: Lesson 3 - Time Complexity, Task 3 - TapeEquilibrium
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] TestData = { 3, 1, 2, 4, 3 };
            Console.WriteLine( FindSmallestDifferenceFromEquilibrium(TestData) );
            Console.WriteLine( FindSmallestDifferenceFromEquilibrium_simpler(TestData) );
        }

        static int FindSmallestDifferenceFromEquilibrium(int[] A)
        {
            int N = A.Length;
            int SumSoFar;

            int[] SumLeftTillP = new int[N];
            int[] SumRightFromP = new int[N];

            SumSoFar = 0;
            for (int P=1; P < N; P++)
            {
                SumSoFar = SumSoFar + A[P-1];
                SumLeftTillP[P] = SumSoFar;
            }

            SumSoFar = 0;
            for (int P = N-1; P > 0; P--)
            {
                SumSoFar = SumSoFar + A[P];
                SumRightFromP[P] = SumSoFar;
            }

            int minDelta = Math.Abs(SumLeftTillP[1] - SumRightFromP[1]);

            for (int P=2; P < N; P++)
            {
                int Delta = Math.Abs(SumLeftTillP[P] - SumRightFromP[P]);

                if (Delta < minDelta)
                    minDelta = Delta;
            }

            return minDelta;
        }


        static int FindSmallestDifferenceFromEquilibrium_simpler(int[] A)
        {
            int N = A.Length;

            int SumAtCurrentPoint = A.Sum();
            int minDelta = Math.Abs(SumAtCurrentPoint - 2 * A[0]);

            for (int P=0; P < N-1; P++)
            {
                SumAtCurrentPoint = SumAtCurrentPoint - 2 * A[P];
                int Delta = Math.Abs(SumAtCurrentPoint);

                if (Delta < minDelta)
                    minDelta = Delta;
            }

            return minDelta;
        }


    }
}
