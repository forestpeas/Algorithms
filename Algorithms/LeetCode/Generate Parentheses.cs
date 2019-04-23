using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 22. Generate Parentheses
     * 
     * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
     * 
     * For example, given n = 3, a solution set is:
     * 
     * [
     *   "((()))",
     *   "(()())",
     *   "(())()",
     *   "()(())",
     *   "()()()"
     * ]
     */
    public class GenerateParentheses
    {
        // Your runtime beats 94.80 % of csharp submissions.
        // Your memory usage beats 14.76 % of csharp submissions.
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            Backtrack("", 0, 0, n);
            return list;

            void Backtrack(string str, int open, int close, int max)
            {
                if (str.Length == max * 2)
                {
                    list.Add(str);
                    return;
                }

                if (open < max)
                {
                    Backtrack(str + "(", open + 1, close, max);
                }
                if (close < open)
                {
                    Backtrack(str + ")", open, close + 1, max);
                }
            }
        }
    }
}
