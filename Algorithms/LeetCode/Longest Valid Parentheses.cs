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
        public int LongestValidParenthesesUsingStack(string s)
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

        // Constant space solution inspired by "Approach 4: Without extra space" of https://leetcode.com/articles/longest-valid-parentheses/.
        // Scan from left to right and then right to left.
        // Count the numbers of left and right parentheses and get a result when they are equal.
        // Reset the numbers when necessary.
        // I think the validity of this solution is probably bacause the longest valid string
        // always contains the same number of left and right parentheses. But you have to check
        // both directions to avoid "over count", e.g. "(((())".
        public int LongestValidParentheses(string s)
        {
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
                else if (right >= left)
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
                else if (left >= right)
                {
                    left = right = 0;
                }
            }
            return maxlength;
        }
    }
}
