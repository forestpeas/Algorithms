using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 438. Find All Anagrams in a String
     * 
     * Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
     * 
     * Strings consists of lowercase English letters only and the length of both strings s and p will
     * not be larger than 20,100.
     * 
     * The order of output does not matter.
     * 
     * Example 1:
     * 
     * Input:
     * s: "cbaebabacd" p: "abc"
     * 
     * Output:
     * [0, 6]
     * 
     * Explanation:
     * The substring with start index = 0 is "cba", which is an anagram of "abc".
     * The substring with start index = 6 is "bac", which is an anagram of "abc".
     * 
     * Example 2:
     * 
     * Input:
     * s: "abab" p: "ab"
     * 
     * Output:
     * [0, 1, 2]
     * 
     * Explanation:
     * The substring with start index = 0 is "ab", which is an anagram of "ab".
     * The substring with start index = 1 is "ba", which is an anagram of "ab".
     * The substring with start index = 2 is "ab", which is an anagram of "ab".
     */
    public class FindAllAnagramsInString
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (s.Length < p.Length) return new int[0];

            var counts = new Dictionary<char, int>();
            foreach (char c in p) counts[c] = counts.GetValueOrDefault(c) + 1;

            // The length of the sliding window [i, j] is always p.Length when we check
            // whether count is 0. If count is 0, it means for every character c in p,
            // the number of c in [i, j] >= the number of c in p. Since [i, j]'s length
            // equals p's length, the number of c in [i, j] is actually equal to the
            // number of c in p.
            var result = new List<int>();
            int count = counts.Count;
            for (int i = 0, j = 0; j < s.Length; j++)
            {
                // Characters that do not exist in p will not affect count.
                counts[s[j]] = counts.GetValueOrDefault(s[j]) - 1;
                if (counts[s[j]] == 0) count--;
                if (j < p.Length - 1) continue;

                if (count == 0) result.Add(i);

                // Inverse operation. s[i] was once visited by j.
                counts[s[i]] = counts[s[i]] + 1;
                if (counts[s[i]] == 1) count++;
                i++;
            }

            return result;
        }
    }
}
