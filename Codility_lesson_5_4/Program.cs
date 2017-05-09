using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_5_4
{
    /// <summary>
    /// CODILITY: Lesson 5 - Prefix Sums, Task 4 - MinAvgTwoSlice 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData0 = { 4, 2, 2, 5, 1, 5, 8 };  // correct result = 1
            int[] testData1 = { -3, -5, -8, -4, -10 };  // correct result = 2
            int[] testData2 = { 5, 6, 3, 4, 9 };        // correct result = 2
            Console.WriteLine(FindSliceWithSmallestAvarage_correct(testData0));
            Console.WriteLine(FindSliceWithSmallestAvarage_correct(testData1));
            Console.WriteLine(FindSliceWithSmallestAvarage_correct(testData2));
        }


        /// <summary>
        /// Given a non-empty zero-indexed array A consisting of N integers, 
        /// returns the starting position of the slice with the minimal average. 
        /// If there is more than one slice with a minimal average, function returns the smallest starting position of such a slice.
        /// </summary>
        static int FindSliceWithSmallestAvarage_correct(int[] A)
        {
            int N = A.Length;
            int[] SumsOfElements = new int[N+1];
            SumsOfElements[0] = 0;

            for (int i = 0; i < N; i++)
                SumsOfElements[i + 1] = SumsOfElements[i] + A[i];

            double minAvarage = (double)SumsOfElements[N] / N;
            int indexOfMinAvg = 0;


            for (int winLength = 2; winLength <= 3; winLength++)
            {
                for (int i = 0; i + winLength <= N; i++)
                {
                    double currentAvg = (double)(SumsOfElements[i + winLength] - SumsOfElements[i]) / (winLength);

                    if (currentAvg < minAvarage)
                    {
                        minAvarage = currentAvg;
                        indexOfMinAvg = i;
                    }
                }

            }

            return indexOfMinAvg;
        }



        static int FindSliceWithSmallestAvarage_correct_slow(int[] A)
        {
            int N = A.Length;
            int[] SumsOfElements = new int[N + 1];
            SumsOfElements[0] = 0;

            for (int i = 0; i < N; i++)
                SumsOfElements[i + 1] = SumsOfElements[i] + A[i];

            double minAvarage = (double)SumsOfElements[N] / N;
            int indexOfMinAvg = 0;


            for (int winLength = 2; winLength < N; winLength++)
            {
                for (int i = 0; i + winLength <= N; i++)
                {
                    double currentAvg = (double)(SumsOfElements[i + winLength] - SumsOfElements[i]) / (winLength);

                    if (currentAvg < minAvarage)
                    {
                        minAvarage = currentAvg;
                        indexOfMinAvg = i;
                    }
                }

            }

            return indexOfMinAvg;
        }



        static int FindSliceWithSmallestAvarage_not_always_correct_solution(int[] A)
        {
            int N = A.Length;
            int[] SumsUpToIndex = new int[N];
            SumsUpToIndex[0] = A[0];

            for (int i = 1; i < N; i++)
                SumsUpToIndex[i] = SumsUpToIndex[i - 1] + A[i];

            int[] SumOfTwoElementSliceStartingAt = new int[N-1];
            SumOfTwoElementSliceStartingAt[0] = SumsUpToIndex[1];

            for (int i = 1; i < N - 1; i++)
                SumOfTwoElementSliceStartingAt[i] = SumsUpToIndex[i + 1] - SumsUpToIndex[i - 1];

            int minTwoElementSlice = SumOfTwoElementSliceStartingAt[0];
            int startingPositionOfMinTwoElemSlice = 0;

            for (int j = 1; j < N - 1; j++)
            {
                int currentSlice = SumOfTwoElementSliceStartingAt[j];
                if (currentSlice < minTwoElementSlice)
                {
                    minTwoElementSlice = currentSlice;
                    startingPositionOfMinTwoElemSlice = j;
                }
            }


            int[] SumOfThreeElementSliceStartingAt = new int[N - 2];
            SumOfThreeElementSliceStartingAt[0] = SumsUpToIndex[2];

            for (int i = 1; i < N - 2; i++)
                SumOfThreeElementSliceStartingAt[i] = SumsUpToIndex[i + 2] - SumsUpToIndex[i - 1];

            int minThreeElementSlice = SumOfThreeElementSliceStartingAt[0];
            int startingPositionOfMinThreeElemSlice = 0;

            for (int j = 1; j < N - 2; j++)
            {
                int currentSlice = SumOfThreeElementSliceStartingAt[j];
                if (currentSlice < minThreeElementSlice)
                {
                    minThreeElementSlice = currentSlice;
                    startingPositionOfMinThreeElemSlice = j;
                }
            }

            if ((double)minThreeElementSlice / 3 < (double)minTwoElementSlice / 2)
                return startingPositionOfMinThreeElemSlice;
            else
                return startingPositionOfMinTwoElemSlice;

            //// Final search for a global min average slice
            //double globalMinSliceAverage = (double)minTwoElementSlice / 2;
            //int indexOfMinAvg = startingPositionOfMinTwoElemSlice;

            //for (int u = 1; u < startingPositionOfMinTwoElemSlice; u++)
            //{
            //    double currentAvg = (double)(SumsUpToIndex[startingPositionOfMinTwoElemSlice + 1] - SumsUpToIndex[u - 1]) / (startingPositionOfMinTwoElemSlice + 1 - u);
            //    if (currentAvg < globalMinSliceAverage)
            //        indexOfMinAvg = u;
            //}

            //for (int v = startingPositionOfMinTwoElemSlice; v < N - 1; v++)
            //{
            //    double currentAvg = (double)(SumsUpToIndex[v + 1] - SumsUpToIndex[startingPositionOfMinTwoElemSlice - 1]) / (v + 1 - startingPositionOfMinTwoElemSlice);
            //    if (currentAvg < globalMinSliceAverage)
            //        indexOfMinAvg = v;
            //}

            //return indexOfMinAvg;
        }

    }
}
