using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_3_1
{
    /// <summary>
    /// CODILITY: Lesson 3 - Time Complexity, Task 1 - FrogJmp
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateMinNumOfJumps(10, 85, 30));
        }

        static int CalculateMinNumOfJumps(int X, int Y, int D)
        {
            int a = (int)Math.Ceiling((double)(Y - X) / D);
            return a;
        }


    }
}
