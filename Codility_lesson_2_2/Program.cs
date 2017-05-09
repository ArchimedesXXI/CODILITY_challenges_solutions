using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int[] ShiftElementsRight(int[] A, int K)
        {
            int N = A.Length;
            int[] Result = new int[N];

            for (int i = 0; i < N; i++)
            {
                Result[(i + K) % N] = A[i];
            }

            return Result;
        }


    }
}
