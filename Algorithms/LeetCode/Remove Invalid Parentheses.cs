using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 301. Remove Invalid Parentheses
     * 
     * Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.
     * 
     * Note: The input string may contain letters other than the parentheses ( and ).
     * 
     * Example 1:
     * 
     * Input: "()())()"
     * Output: ["()()()", "(())()"]
     * 
     * Example 2:
     * 
     * Input: "(a)())()"
     * Output: ["(a)()()", "(a())()"]
     * 
     * Example 3:
     * 
     * Input: ")("
     * Output: [""]
     */
    public class RemoveInvalidParenthesesSolution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            // Find every possible substring and check whether it's a valid string(I think it's brute-force).
            // Also BFS.
            var result = new List<string>();
            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            queue.Enqueue(s);
            visited.Add(s);
            bool found = false;

            while (queue.Count != 0)
            {
                s = queue.Dequeue();

                if (IsValid(s))
                {
                    result.Add(s);
                    found = true;
                }

                // We've found the valid string with the minimum parentheses removed, so there is no need to furthur
                // split it into smaller substrings, since this would only yield strings with more parentheses removed.
                if (found) continue;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != '(' && s[i] != ')') continue;

                    string oneRemoved = s.Substring(0, i) + s.Substring(i + 1); // Substring with s[i] removed from s.

                    if (!visited.Contains(oneRemoved))
                    {
                        queue.Enqueue(oneRemoved);
                        visited.Add(oneRemoved);
                    }
                }
            }

            return result;
        }

        private bool IsValid(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                if (s[i] == ')')
                {
                    count--;
                    if (count < 0) return false;
                }
            }
            return count == 0;
        }
    }
}
