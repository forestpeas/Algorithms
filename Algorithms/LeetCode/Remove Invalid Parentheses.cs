using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 301. Remove Invalid Parentheses
     * 
     * Remove the minimum number of invalid parentheses in order to make the input string valid.
     * Return all possible results.
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
            // Inspired by https://leetcode.com/problems/remove-invalid-parentheses/discuss/75027/Easy-Short-Concise-and-Fast-Java-DFS-3-ms-solution
            // To check whether a string is valid, count the number of left and right parentheses
            // from left to right and from right to left, or use a stack.
            List<string> result = new List<string>();
            Remove(s, result, 0, 0);
            return result;
        }

        private void Remove(string s, List<string> result, int last_i, int last_j)
        {
            for (int count = 0, i = last_i; i < s.Length; i++)
            {
                if (s[i] == '(') count++;
                if (s[i] == ')') count--;
                if (count >= 0) continue;
                // Now we've found a redundant ')', we should remove a certain ')' we've seen. Removing any one of
                // a previous seen ')' still makes the string valid.
                for (int j = last_j; j <= i; j++)
                {
                    // Only remove the first one of a sequence of consecutive parenthesis to avoid duplicates, like:
                    // ((())))((())a)))
                    //    ↑      ↑  ↑
                    if (s[j] == ')' && (j == last_j || s[j - 1] != ')'))
                    {
                        // Because we removed one character, the index of the next character is still i.
                        Remove(s.Remove(j, 1), result, i, j);
                    }
                }
                return; // Each level of recursion is only responsible for removing one redundant ')'.
            }

            // If there are no more redundant parentheses, we have a "half valid" string.
            RemoveLeftParentheses(s, result, s.Length - 1, s.Length - 1);
        }

        private void RemoveLeftParentheses(string s, List<string> result, int last_i, int last_j)
        {
            // Similar logic.
            for (int count = 0, i = last_i; i >= 0; i--)
            {
                if (s[i] == ')') count++;
                if (s[i] == '(') count--;
                if (count >= 0) continue;
                for (int j = last_j; j >= i; j--)
                {
                    if (s[j] == '(' && (j == last_j || s[j + 1] != '('))
                    {
                        RemoveLeftParentheses(s.Remove(j, 1), result, i - 1, j - 1);
                    }
                }
                return;
            }

            result.Add(s);
        }

        public IList<string> RemoveInvalidParentheses2(string s)
        {
            // Inspired by https://leetcode.com/problems/remove-invalid-parentheses/discuss/75032/Share-my-Java-BFS-solution
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
