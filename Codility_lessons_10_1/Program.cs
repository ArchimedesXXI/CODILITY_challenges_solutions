using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lessons_10_1
{
    /// <summary>
    /// CODILITY: Lesson 10 - Prime and composite numbers, Task 1 - MinPerimeterRectangle
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // TESTS where area is a Prime number:
            Console.WriteLine(FindMinPerimeter_Wrapper(13));    // Expected correct result = 28
            Console.WriteLine(FindMinPerimeter_Wrapper(31));    // Expected correct result = 64
            
            // TESTS where area has a Square root, which is a whole number:
            Console.WriteLine();
            Console.WriteLine(FindMinPerimeter_Wrapper(64));    // Expected correct result = 32
            Console.WriteLine(FindMinPerimeter_Wrapper(100));   // Expected correct result = 40
            
            // Other TESTS:
            Console.WriteLine();
            Console.WriteLine(FindMinPerimeter_Wrapper(30));    // Expected correct result = 22
        }


        static int FindMinPerimeter_Wrapper(int N)
        {
            return FindMinPerimeter(N);
        }  

        /// <summary>
        /// Find the minimal perimeter of any rectangle whose area is given. The sides of this rectangle should be only integers.
        /// </summary>
        static int FindMinPerimeter(int area)
        {
            if (area <= 0)
                throw new ArgumentOutOfRangeException(nameof(area), "Rectangle area has to be an int greater than 0.");

            for (int side1 = (int)Math.Sqrt(area), side2; side1 > 0; side1--)
            {
                if(area % side1 == 0)
                {
                    side2 = area / side1;
                    return (2 * side1) + (2 * side2);
                }
            }

            return (2 * area) + 2;
        }

    }
}
