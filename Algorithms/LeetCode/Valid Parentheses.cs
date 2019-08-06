using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 20. Valid Parentheses
     * 
     * Given a string containing just the characters '(', ')', '{', '}', '[' and ']', 
     * determine if the input string is valid.
     * 
     * An input string is valid if:
     * 
     *     Open brackets must be closed by the same type of brackets.
     *     Open brackets must be closed in the correct order.
     * 
     * Note that an empty string is also considered valid.
     * 
     * Example 1:
     * 
     * Input: "()"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: "()[]{}"
     * Output: true
     * 
     * Example 3:
     * 
     * Input: "(]"
     * Output: false
     * 
     * Example 4:
     * 
     * Input: "([)]"
     * Output: false
     * 
     * Example 5:
     * 
     * Input: "{[]}"
     * Output: true
     */
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var mappings = new Dictionary<char, char>()
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (mappings.TryGetValue(c, out char openingBracket))
                {
                    if (stack.Count == 0 || stack.Pop() != openingBracket)
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
    }
}
