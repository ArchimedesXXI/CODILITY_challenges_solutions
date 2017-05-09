using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codility_lesson_4_2
{
    /// <summary>
    /// CODILITY: Lesson 4 - Counting Elements, Task 2 - PermCheck
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] test_ShouldReturnFalse = { 1, 3, 6, -16, 4, 1, 13, 2, 0, 7, -8, 1, 2, 7 };
            int[] test_ShouldReturnTrue = {10, 9, 5, 11, 4, 1, 3, 6, 2, 8, 7, 12};
            Console.WriteLine(IsArrayAPermutation(test_ShouldReturnFalse));
            Console.WriteLine(IsArrayAPermutation(test_ShouldReturnTrue));
        }

        static int IsArrayAPermutation_Wrapper(int[] A)
        {
            bool success = IsArrayAPermutation(A);

            if (success)
                return 1;
            else
                return 0;
        }

        static bool IsArrayAPermutation(int[] A)
        {
            int N = A.Length;

            HashSet<int> ProperPermutation = new HashSet<int>(Enumerable.Range(1, N));
            
            foreach(int a in A)
            {
                if (ProperPermutation.Contains(a))
                    ProperPermutation.Remove(a);
                else
                    return false;
            }

            Debug.Assert(ProperPermutation.Count == 0);
            return true;
        }

    }
}
