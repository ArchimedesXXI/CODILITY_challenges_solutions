using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_5_1
{
    /// <summary>
    /// CODILITY: Lesson 5 - Prefix Sums, Task 1 - CountDiv
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Given three integers A, B and K, 
        /// returns the number of integers within the range [A..B] that are divisible by K. 
        /// </summary>
        static int FindNumOfIntDivisaleBy(int A, int B, int K)
        {
            return (int)(Math.Floor((double)B / K) - Math.Ceiling((double)A / K) + 1);
        }
    }
}
