using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codility_lesson_8_2
{
    /// <summary>
    /// CODILITY: Lesson 8 - Leader, Task 2 - Dominator
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData_0 = { 0 };
            Console.WriteLine(GetValueOfLeader(testData_0));  // Expected correct result = 0
            int[] testData_1 = { };
            Console.WriteLine(GetValueOfLeader(testData_1));  // Expected correct result = null
            int[] testData_2 = { 1, 3, 2, 3, 3, 3, 4,};
            Console.WriteLine(GetValueOfLeader(testData_2));  // Expected correct result = 3
            int[] testData_3 = { 3, 1, 2, 3, 3, 4, }; 
            Console.WriteLine(GetValueOfLeader(testData_3));  // Expected correct result = null

            Console.WriteLine();
            Console.WriteLine(FirstIndexOfLeader(testData_0));  // Expected correct result = 0
            Console.WriteLine(FirstIndexOfLeader(testData_1));  // Expected correct result = -1
            Console.WriteLine(FirstIndexOfLeader(testData_2));  // Expected correct result = 1
            Console.WriteLine(FirstIndexOfLeader(testData_3));  // Expected correct result = -1
        }

        public static int FirstIndexOfLeader(int[] A)
        {
            int? leader = GetValueOfLeader(A);

            // if there is no Leader in A, the function returns -1
            if (leader == null)
                return -1;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == leader)
                    return i;
            }

            return -1;
        }


        public static int? GetValueOfLeader(int[] A)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A), "Array A must not be null!");

            int N = A.Length;

            if (N == 0)
                return null;

            int candidate = A[0];
            int count = 1;

            for (int i = 1; i < N; i++)
            {
                Debug.Assert(count >= 0);

                if (count == 0)
                {
                    candidate = A[i];
                    count++;
                }
                else
                {
                    if (A[i] == candidate)
                        count++;
                    else
                        count--;
                }
            }

            if (count == 0)
                return null;

            // We confirm, if the candidate is the Leader or not.
            int finalCount = 0;

            foreach (int a in A)
            {
                if (a == candidate)
                    finalCount++;
                if (finalCount > N / 2)
                    return candidate;
            }

            return null;
        }


    }
}
