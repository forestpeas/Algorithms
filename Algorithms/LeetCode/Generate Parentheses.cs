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
        public IList<string> GenerateParenthesis(int n)
        {
            // Backtracking
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

        // This solution is very similar to "Problem 95. Unique Binary Search Trees II" both in idea and in structure
        // because they are all Catalan number problems. They are also equal to this problem: If 1...n is the sequence
        // of push operations on an initially empty stack. How many different sequences of pop operations are there?
        // A push is a "(", and a pop is a ")". The root node in BST is the counterpart of the last element that popped
        // out of the stack.
        public IList<string> GenerateParenthesis2(int n)
        {
            return GenerateParenthesis2(1, n);
        }

        private IList<string> GenerateParenthesis2(int start, int end)
        {
            if (start == end) return new string[] { "()" };
            var results = new List<string>();
            for (int i = start; i <= end; i++)
            {
                IList<string> leftResults;
                if (i == start)
                {
                    leftResults = new string[] { string.Empty };
                }
                else
                {
                    leftResults = GenerateParenthesis2(start, i - 1);
                }

                IList<string> rightResults;
                if (i == end)
                {
                    rightResults = new string[] { string.Empty };
                }
                else
                {
                    rightResults = GenerateParenthesis2(i + 1, end);
                }

                foreach (var leftResult in leftResults)
                {
                    foreach (var rightResult in rightResults)
                    {
                        results.Add(leftResult + "(" + rightResult + ")");
                    }
                }
            }

            return results;
        }
    }
}
