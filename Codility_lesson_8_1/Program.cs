using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_8_1
{
    /// <summary>
    /// CODILITY: Lesson 8 - Leader, Task 1 - EquiLeader
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int?,int> leader;

            int[] testData_0 = { 0 };
            Console.WriteLine($"{TryGetValueOfLeader(testData_0, out leader)}, {leader}");  // Expected correct result = True, (0, 1)
            int[] testData_1 = { };
            Console.WriteLine($"{TryGetValueOfLeader(testData_1, out leader)}, {leader}");  // Expected correct result = False, (null, 0)
            int[] testData_2 = { 1, 3, 2, 3, 3, 3, 4, };
            Console.WriteLine($"{TryGetValueOfLeader(testData_2, out leader)}, {leader}");  // Expected correct result = True, (3, 4)
            int[] testData_3 = { 3, 1, 2, 3, 3, 4, }; 
            Console.WriteLine($"{TryGetValueOfLeader(testData_3, out leader)}, {leader}");  // Expected correct result = False, (null, 0)

            Console.WriteLine();
            Console.WriteLine(FindNumberOfEquiLeaders(testData_1));     // Expected correct result = 0
            int[] testData_4 = { 4, 3, 4, 4, 4, 2 };
            Console.WriteLine(FindNumberOfEquiLeaders(testData_4));     // Expected correct result = 2
            int[] testData_5 = { 4, 4, 2, 5, 3, 4, 4, 4 };
            Console.WriteLine(FindNumberOfEquiLeaders(testData_5));     // Expected correct result = 3
        }


        public static int FindNumberOfEquiLeaders(int[] A)
        {
            Tuple<int?,int> leader;
            bool hasLeader = TryGetValueOfLeader(A, out leader);

            if (!hasLeader)
                return 0;

            int leaderValue = (int)leader.Item1;
            int RightHalfLeaderCount = leader.Item2;
            int LeftHalfLeaderCount = 0;
            int RightHalfSize = A.Length;
            int LeftHalfSize = 0;
            int EquiLeadersCount = 0;

            foreach (int a in A)
            {
                LeftHalfSize++;
                RightHalfSize--;

                if (a == leaderValue)
                {
                    LeftHalfLeaderCount++;
                    RightHalfLeaderCount--;
                }

                if (LeftHalfLeaderCount > LeftHalfSize / 2 && RightHalfLeaderCount > RightHalfSize / 2)
                    EquiLeadersCount++;
            }

            return EquiLeadersCount;
        }


        public static bool TryGetValueOfLeader(int[] A, out Tuple<int?,int> leader)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A), "Array must not be null!");

            leader = new Tuple<int?, int>(null, 0);
            int N = A.Length;
            int halfWayMark = N / 2;

            if (N == 0)
                return false;

            Dictionary<int, int> ValuesCount = new Dictionary<int, int>();

            foreach(int a in A)
            {
                if (!ValuesCount.ContainsKey(a))
                    ValuesCount.Add(a, 1);
                else
                    ValuesCount[a]++;
            }

            foreach (KeyValuePair<int,int> pair in ValuesCount)
            {
                if (pair.Value > halfWayMark)
                {
                    leader = new Tuple<int?, int>(pair.Key, pair.Value);
                    return true;
                }
            }

            return false;
        }

    }
}
