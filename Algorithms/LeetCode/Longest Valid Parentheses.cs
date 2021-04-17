using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 32. Longest Valid Parentheses
     * Given a string containing just the characters '(' and ')', find the length of the longest valid
     * (well-formed) parentheses substring.
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
        public int LongestValidParentheses(string s)
        {
            // for example: ()(()(()))
            int res = 0;
            var stack = new Stack<int>();
            stack.Push(-1); // the left boundary of a valid substring
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i); // the left boundary of a valid substring
                    }
                    else
                    {
                        res = Math.Max(res, i - stack.Peek());
                    }
                }
            }
            return res;
        }

        public int LongestValidParentheses2(string s)
        {
            // from https://leetcode.com/articles/longest-valid-parentheses/
            int left = 0, right = 0, maxlength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else
                {
                    right++;
                }

                if (left == right)
                {
                    maxlength = Math.Max(maxlength, 2 * right);
                }
                else if (right > left)
                {
                    left = right = 0;
                }
            }
            left = right = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else
                {
                    right++;
                }

                if (left == right)
                {
                    maxlength = Math.Max(maxlength, 2 * left);
                }
                else if (left > right)
                {
                    left = right = 0;
                }
            }
            return maxlength;
        }

        public int LongestValidParentheses3(string s)
        {
            // stack contains the length of a longest valid string on the left side of a "("
            // when we encounter a ")" that corresponds to that "(", we pop the length from the stack and add it to the total length.
            // Take "()()()((()))" as an examples.
            Stack<int> stack = new Stack<int>();
            int currentLength = 0; // Maintains the current length of longest valid string when the current character is ")".
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
                        result = Math.Max(result, currentLength);
                        currentLength = 0;
                    }
                    else
                    {
                        // "2" means a new pair of parentheses.
                        // ()()()()()() (      (())     )
                        // ------------        ----
                        //  stack.Pop()    currentLength
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
