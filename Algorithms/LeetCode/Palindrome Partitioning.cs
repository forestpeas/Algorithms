using System.Collections.Generic;

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
        public IList<IList<string>> Partition(string s)
        {
            // Recursive solution with memoization.
            return Partition(s, new Dictionary<string, List<IList<string>>>());
        }

        private IList<IList<string>> Partition(string s, Dictionary<string, List<IList<string>>> mem)
        {
            if (mem.TryGetValue(s, out var value)) return value;
            var result = new List<IList<string>>();
            if (IsPalindrome(s, 0, s.Length - 1)) result.Add(new List<string>() { s });

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (IsPalindrome(s, 0, i))
                {
                    foreach (var item in Partition(s.Substring(i + 1), mem))
                    {
                        // Copy the list because the list was added in the dictionary, we don't
                        // want to mutate it because it might be used again.
                        // Also note that the order of substrings in the list matters.
                        var copy = new List<string>();
                        copy.Add(s.Substring(0, i + 1));
                        copy.AddRange(item);
                        result.Add(copy);
                    }
                }
            }
            mem.Add(s, result);
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
