using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1316. Distinct Echo Substrings
     * 
     * Return the number of distinct non-empty substrings of text that can be written as the concatenation of some string with itself.
     * 
     * Example 1:
     * 
     * Input: text = "abcabcabc"
     * Output: 3
     * Explanation: The 3 substrings are "abcabc", "bcabca" and "cabcab".
     * 
     * Example 2:
     * 
     * Input: text = "leetcodeleetcode"
     * Output: 2
     * Explanation: The 2 substrings are "ee" and "leetcodeleetcode".
     */
    public class Distinct_Echo_Substrings
    {
        public int DistinctEchoSubstrings(string text)
        {
            // Brute-force O(N^3).
            var set = new HashSet<string>();
            for (int i = 1; i < text.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((i - j + 1) % 2 != 0) continue;
                    if (Check(text, j, i)) set.Add(text.Substring(j, i - j + 1));
                }
            }

            return set.Count;
        }

        private bool Check(string s, int start, int end)
        {
            int offset = (end - start + 1) / 2;
            for (int i = start; i < start + offset; i++)
            {
                if (s[i] != s[i + offset]) return false;
            }
            return true;
        }
    }
}
