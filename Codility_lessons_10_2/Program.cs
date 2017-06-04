using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lessons_10_2
{
    /// <summary>
    /// CODILITY: Lesson 10 - Prime and composite numbers, Task 2 - CountFactors 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountDivisors(1));       // Expected correct result = 1

            Console.WriteLine();
            Console.WriteLine(CountDivisors(13));       // Expected correct result = 2
            Console.WriteLine(CountDivisors(101));      // Expected correct result = 2

            Console.WriteLine();
            Console.WriteLine(CountDivisors(16));       // Expected correct result = 5
            Console.WriteLine(CountDivisors(36));       // Expected correct result = 9

            Console.WriteLine();
            Console.WriteLine(CountDivisors(24));       // Expected correct result = 8
            Console.WriteLine(CountDivisors(6));        // Expected correct result = 4
        }

        static int CountDivisors(int N)
        {
            if (N <= 0)
                throw new ArgumentOutOfRangeException(nameof(N), "The argument has to be greater than 0.");

            if (N == 1)
                return 1;

            int numOfDivisors = 0;
            double sqrtOfN = Math.Sqrt(N);

            if (N % sqrtOfN == 0)
                numOfDivisors++;


            for (int a = (int)(Math.Ceiling(sqrtOfN) - 1); a > 0; a--)
            {
                if (N % a == 0)
                    numOfDivisors += 2;
            }

            return numOfDivisors;
        }

    }
}
