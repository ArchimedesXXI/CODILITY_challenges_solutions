using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_7_2
{
    /// <summary>
    /// CODILITY: Lesson 7 - Stacks and Queues, Task 2 - Fish 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray_A0 = { 4, 3, 2, 1, 5 };
            int[] testArray_B0 = { 1, 1, 0, 0, 1 };
            int[] testArray_A1 = { 4, 3, 2, 1, 5 };
            int[] testArray_B1 = { 0, 1, 0, 0, 0 };
            int[] testArray_A2 = { 4, 2, 3, 1, 5 };
            int[] testArray_B2 = { 1, 1, 0, 0, 1 };
            Console.WriteLine( CountRemainingFish(testArray_A0, testArray_B0) );  // Expected correct result = 3 
            Console.WriteLine( CountRemainingFish(testArray_A1, testArray_B1) );  // Expected correct result = 2 
            Console.WriteLine( CountRemainingFish(testArray_A2, testArray_B2) );  // Expected correct result = 2 
        }

        static int CountRemainingFish(int[] A, int[] B)
        {
            int N = A.Length;
            Debug.Assert(A.Length == B.Length);

            Stack<int> DownstreamFishStack = new Stack<int>();
            int upstreamFishCount = 0;

            for (int i=0; i<N; i++)
            {
                if (B[i] == 1)
                    DownstreamFishStack.Push(A[i]);
                else
                {
                    while (DownstreamFishStack.Count > 0 && A[i] > DownstreamFishStack.First())
                        DownstreamFishStack.Pop();
                    if (DownstreamFishStack.Count == 0)
                        upstreamFishCount++;
                }

            }

            return DownstreamFishStack.Count + upstreamFishCount;
        }


    }
}
