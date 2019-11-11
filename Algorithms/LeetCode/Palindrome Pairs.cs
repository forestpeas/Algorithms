using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 336. Palindrome Pairs
     * 
     * Given a list of unique words, find all pairs of distinct indices (i, j) in the given list,
     * so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.
     * 
     * Example 1:
     * 
     * Input: ["abcd","dcba","lls","s","sssll"]
     * Output: [[0,1],[1,0],[3,2],[2,4]] 
     * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
     * 
     * Example 2:
     * 
     * Input: ["bat","tab","cat"]
     * Output: [[0,1],[1,0]] 
     * Explanation: The palindromes are ["battab","tabbat"]
     */
    public class PalindromePairsSolution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            // Basically the same as "214. Shortest Palindrome". We also need to consider
            // adding another string to the end.
            var map = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++) map.Add(words[i], i);

            var result = new List<IList<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                string w = words[i];
                string r = new string(w.Reverse().ToArray());

                for (int j = 0; j <= w.Length; j++)
                {
                    // Just find all the palindromes starting from w[0], and
                    // all the palindromes that ends with w[n - 1].
                    string sub1 = r.Substring(j);
                    string sub2 = r.Substring(0, j);

                    if (IsPalindrome(sub1))
                    {
                        if (map.TryGetValue(sub2, out int idx) && idx != i)
                        {
                            result.Add(new int[] { idx, i });
                        }
                    }

                    if (IsPalindrome(sub2))
                    {
                        // "j != 0" avoids duplicate pairs, consider "abcd" and "dcba", we
                        // only add another one to the front in the above "if block".
                        if (map.TryGetValue(sub1, out int idx) && idx != i && j != 0)
                        {
                            result.Add(new int[] { i, idx });
                        }
                    }
                }
            }

            return result;
        }

        private bool IsPalindrome(string s)
        {
            int start = 0, end = s.Length - 1;
            while (start < end)
            {
                if (s[start++] != s[end--]) return false;
            }
            return true;
        }
    }
}
