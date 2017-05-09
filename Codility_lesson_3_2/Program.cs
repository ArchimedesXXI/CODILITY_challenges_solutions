using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codility_lesson_3_2
{
    /// <summary>
    /// CODILITY: Lesson 3 - Time Complexity, Task 2 - PermMissingElem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int FindMissingInteger(int[] A)
        {
            int N = A.Length;

            HashSet<int> ReferenceSet = new HashSet<int>(Enumerable.Range(1, N + 1));

            foreach (int element in A)
            {
                ReferenceSet.Remove(element);
            }

            Debug.Assert(ReferenceSet.Count == 1);

            return ReferenceSet.First();
        }


    }
}
