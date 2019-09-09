using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 131. Palindrome Partitioning
     * 
     * Given a string s, partition s such that every substring of the partition is a palindrome.
     * Return all possible palindrome partitioning of s.
     * 
     * Example:
     * 
     * Input: "aab"
     * Output:
     * [
     *   ["aa","b"],
     *   ["a","a","b"]
     * ]
     */
    public class PalindromePartitioning
    {
        private readonly Dictionary<string, List<IList<string>>> _mem = new Dictionary<string, List<IList<string>>>();

        public IList<IList<string>> Partition(string s)
        {
            // Recursive solution with memoization.
            if (_mem.TryGetValue(s, out var value)) return value;

            var result = new List<IList<string>>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (IsPalindrome(s, i, s.Length - 1))
                {
                    if (i == 0)
                    {
                        result.Add(new List<string>() { s });
                        break;
                    }
                    foreach (var item in Partition(s.Substring(0, i)))
                    {
                        var copy = item.ToList();
                        copy.Add(s.Substring(i));
                        result.Add(copy);
                    }
                }
            }

            _mem.Add(s, result);
            return result;
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start++] != s[end--]) return false;
            }

            return true;
        }
    }
}
