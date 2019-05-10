using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 32. Longest Valid Parentheses
     * Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
     * 
     * Example 1:
     * 
     * Input: "(()"
     * Output: 2
     * Explanation: The longest valid parentheses substring is "()"
     * 
     * Example 2:
     * 
     * Input: ")()())"
     * Output: 4
     * Explanation: The longest valid parentheses substring is "()()"
     */
    public class LongestValidParenthesesSolution
    {
        // Your runtime beats 84.73 % of csharp submissions.
        // Your memory usage beats 14.81 % of csharp submissions.
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int currentLength = 0;
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    stack.Push(currentLength);
                    currentLength = 0;
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        if (currentLength > result)
                        {
                            result = currentLength;
                        }
                        currentLength = 0;
                    }
                    else
                    {
                        currentLength = currentLength + 2 + stack.Pop();
                    }
                }
            }

            result = Math.Max(result, currentLength);
            while (stack.Count != 0)
            {
                result = Math.Max(result, stack.Pop());
            }
            return result;
        }
    }
}
