using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_lesson_7_3
{
    /// <summary>
    /// CODILITY: Lesson 7 - Stacks and Queues, Task 3 - Nesting 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string testString0 = "((()()))";
            string testString1 = "(()(())";
            string testString2 = ")(";
            Console.WriteLine(IsProperlyNestedParenthesis_simpler(testString0));  // Expected correct result = True
            Console.WriteLine(IsProperlyNestedParenthesis_simpler(testString1));  // Expected correct result = False
            Console.WriteLine(IsProperlyNestedParenthesis_simpler(testString2));  // Expected correct result = False
        }

        static int IsProperlyNestedParenthesis_Adapter(string S)
        {
            return IsProperlyNestedParenthesis(S) ? 1 : 0;
        }

        static bool IsProperlyNestedParenthesis(string S)
        {
            Stack<char> ToBeCompleted = new Stack<char>();

            foreach (char actualBracket in S)
            {
                if (actualBracket == ')' && ToBeCompleted.Count == 0)
                    return false;
                else if (actualBracket == '(')
                    ToBeCompleted.Push(actualBracket);
                else // this case is equivalent to:   else if(actualBracket == ')' )
                {
                    Debug.Assert(actualBracket == ')');
                    ToBeCompleted.Pop();
                }
            }

            if (ToBeCompleted.Count == 0)
                return true;
            else
                return false;
        }


        static int IsProperlyNestedParenthesis_simpler_Adapter(string S)
        {
            return IsProperlyNestedParenthesis_simpler(S) ? 1 : 0;
        }

        static bool IsProperlyNestedParenthesis_simpler(string S)
        {
            int CountOfStackOfParenthesis = 0;

            foreach (char actualBracket in S)
            {
                if (actualBracket == ')' && CountOfStackOfParenthesis == 0)
                    return false;
                else if (actualBracket == '(')
                    CountOfStackOfParenthesis++;
                else // this case is equivalent to:   else if(actualBracket == ')' )
                {
                    Debug.Assert(actualBracket == ')');
                    CountOfStackOfParenthesis--;
                }
            }

            if (CountOfStackOfParenthesis == 0)
                return true;
            else
                return false;
        }


    }
}
