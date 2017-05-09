using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_7_4
{
    /// <summary>
    /// CODILITY: Lesson 7 - Stacks and Queues, Task 4 - StoneWall
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testWall_0 = { 0 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_0) );  // Expected correct result = 0
            int[] testWall_1 = { 0, 0, 0, 0, 0, 0 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_1) );  // Expected correct result = 0
            int[] testWall_2 = { 1, 1, 1 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_2) );  // Expected correct result = 1
            int[] testWall_3 = { 19, 19, 19, 19, 19, 19 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_3) );  // Expected correct result = 1
            int[] testWall_4 = { 8, 8, 5, 7, 9, 8, 7, 4, 8 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_4) );  // Expected correct result = 7
            int[] testWall_5 = { 8, 8, 5, 7, 9, 9, 9, 9, 9, 8, 7, 4, 4, 4, 4, 8, 8, 8, 8, 8 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_5) );  // Expected correct result = 7
            int[] testWall_6 = { 12, 10, 12 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_6) );  // Expected correct result = 3
            int[] testWall_7 = { 10, 12, 10 };
            Console.WriteLine( MinRectanglesToBuildWall(testWall_7) );  // Expected correct result = 2
        }

        static int MinRectanglesToBuildWall(int[] H)
        {
            int N = H.Length;
            int rectanglesCount = 0;
            Stack<int> rectangleStack = new Stack<int>();
            rectangleStack.Push(0);

            foreach (int h in H)
            {
                while (h < rectangleStack.First())
                {
                    Debug.Assert(rectangleStack.Count > 0);
                    rectangleStack.Pop();
                    rectanglesCount++;
                }

                Debug.Assert(rectangleStack.Count > 0);
                if (h > rectangleStack.First())
                    rectangleStack.Push(h);
            }

            return rectanglesCount + rectangleStack.Count - 1;
        }

    }
}
