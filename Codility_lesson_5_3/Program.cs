using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codility_lesson_5_3
{
    /// <summary>
    /// CODILITY: Lesson 5 - Prefix Sums, Task 3 - GenomicRangeQuery
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string DNAtestSequence = "AC";
            int[] P = { 0, 0, 1 };
            int[] Q = { 0, 1, 1 };
            Console.WriteLine( String.Join(", ", CalculateMinImpactFactors(DNAtestSequence, P, Q) ));  // Expected correct result = [1, 1, 2]

        }

        static int[] CalculateMinImpactFactors(string S, int[] P, int[] Q)
        {
            int N = S.Length;

            Debug.Assert(P.Length == Q.Length);
            int M = P.Length;

            int[] PrefixSumOf_A = new int[N + 1];
            int[] PrefixSumOf_C = new int[N + 1];
            int[] PrefixSumOf_G = new int[N + 1];
            PrefixSumOf_A[0] = 0;
            PrefixSumOf_C[0] = 0;
            PrefixSumOf_G[0] = 0;

            for (int i = 0; i < N; i++)
            {
                PrefixSumOf_A[i + 1] = PrefixSumOf_A[i];
                PrefixSumOf_C[i + 1] = PrefixSumOf_C[i];
                PrefixSumOf_G[i + 1] = PrefixSumOf_G[i];

                if (S[i] == 'A')
                    PrefixSumOf_A[i + 1] = PrefixSumOf_A[i] + 1;
                else if (S[i] == 'C')
                    PrefixSumOf_C[i + 1] = PrefixSumOf_C[i] + 1;
                else if (S[i] == 'G')
                    PrefixSumOf_G[i + 1] = PrefixSumOf_G[i] + 1;
            }

            int[] results = new int[M];

            for (int j = 0; j < M; j++)
            {
                results[j] = GetOneMinImpactFactor(P[j], Q[j], PrefixSumOf_A, PrefixSumOf_C, PrefixSumOf_G);
            }

            return results;
        }

        // Helper Method
        static int GetOneMinImpactFactor(int StartIndex, int EndIndex, int[] PrefixSumOf_A, int[] PrefixSumOf_C, int[] PrefixSumOf_G)
        {
            if (PrefixSumOf_A[EndIndex + 1] - PrefixSumOf_A[StartIndex] > 0)
                return 1;
            else if (PrefixSumOf_C[EndIndex + 1] - PrefixSumOf_C[StartIndex] > 0)
                return 2;
            else if (PrefixSumOf_G[EndIndex + 1] - PrefixSumOf_G[StartIndex] > 0)
                return 3;
            else
                return 4;
        }


    }
}
