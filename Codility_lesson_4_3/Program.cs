using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_4_3
{
    /// <summary>
    /// CODILITY: Lesson 4 - Counting Elements, Task 3 - FrogRiverOne
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = { 1, 3, 1, 4, 2, 3, 5, 4, 1, 8, 19, 0 };
            Console.WriteLine(FindEarliestTimeToJump(5, testData));
        }

        static int FindEarliestTimeToJump(int X, int[] A)
        {
            int N = A.Length;

            HashSet<int> AllStepsNeeded = new HashSet<int>(Enumerable.Range(1,X));

            for (int t=0; t<N; t++)
            {
                AllStepsNeeded.Remove(A[t]);

                if (AllStepsNeeded.Count == 0)
                    return t;
            }

            // If the frog is never able to jump to the other side of the river, the function should return −1
            return -1;
        }

    }
}
