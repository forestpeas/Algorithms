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
    class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(') return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{') return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[') return false;
                        break;
                }
            }
            if (stack.Count == 0) return true;
            return false;
        }
    }
}
