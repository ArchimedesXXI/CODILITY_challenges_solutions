using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_7_1
{
    /// <summary>
    /// CODILITY: Lesson 7 - Stacks and Queues, Task 1 - Brackets
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string testString0 = "{[()()]}";
            string testString1 = "([)()]";
            string testString2 = ")(";
            Console.WriteLine( IsProperlyNestedBrackets(testString0) );  // Expected correct result = True
            Console.WriteLine( IsProperlyNestedBrackets(testString1) );  // Expected correct result = False
            Console.WriteLine( IsProperlyNestedBrackets(testString2) );  // Expected correct result = False
        }

        static int IsProperlyNestedBrackets_Adapter(string S)
        {
            return IsProperlyNestedBrackets(S) ? 1 : 0;
        }

        static bool IsProperlyNestedBrackets(string S)
        {
            Stack<char> ToBeCompleted = new Stack<char>();

            Dictionary<char, char> reversedBrackets = new Dictionary<char, char>
            {
                ['{'] = '}',
                ['['] = ']',
                ['('] = ')',
            };

            foreach (char actualBracket in S)
            {
                if (reversedBrackets.ContainsKey(actualBracket))
                    ToBeCompleted.Push(reversedBrackets[actualBracket]);
                else if (reversedBrackets.ContainsValue(actualBracket) && ToBeCompleted.Count == 0)
                        return false;
                else if (reversedBrackets.ContainsValue(actualBracket) && ToBeCompleted.Count > 0)
                {
                    char expectedBracket = ToBeCompleted.Pop();

                    if (actualBracket != expectedBracket)
                        return false;
                }
                else
                    throw new ArgumentException("The string can only contain { [ ( ) ] } characters!", nameof(S));
            }

            if (ToBeCompleted.Count == 0)
                return true;
            else
                return false;
        }

    }
}
