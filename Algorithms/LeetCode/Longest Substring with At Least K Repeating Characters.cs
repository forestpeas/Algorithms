using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 395. Longest Substring with At Least K Repeating Characters
     * 
     * Find the length of the longest substring T of a given string (consists of lowercase letters only)
     * such that every character in T appears no less than k times.
     * 
     * Example 1:
     * 
     * Input:
     * s = "aaabb", k = 3
     * 
     * Output:
     * 3
     * 
     * The longest substring is "aaa", as 'a' is repeated 3 times.
     * 
     * Example 2:
     * 
     * Input:
     * s = "ababbc", k = 2
     * 
     * Output:
     * 5
     * 
     * The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.
     */
    public class LongestSubstringWithAtLeastKRepeatingCharacters
    {
        public int LongestSubstring(string s, int k)
        {
            // Similar to "76. Minimum Window Substring".
            var set = new HashSet<char>();
            foreach (char c in s) set.Add(c);
            int result = 0;
            for (int numUniqueTarget = 1; numUniqueTarget <= set.Count; numUniqueTarget++)
            {
                // For example, when numUniqueTarget is 2, we are going to find the longest substring
                // with exactly 2 unique characters, and each character appears no less than k times.
                // We use a sliding window [l,r].
                int[] counts = new int[26];
                int numUnique = 0; // number of unique characters in [l,r] 
                int numNoLessThanK = 0; // number of characters in [l,r] that appears no less than k times
                for (int l = 0, r = 0; r < s.Length; r++)
                {
                    int count = counts[s[r] - 'a']++;
                    if (count == 0) numUnique++;
                    if (count == k - 1) numNoLessThanK++;

                    while (numUnique > numUniqueTarget)
                    {
                        // shrink the left bound
                        count = counts[s[l] - 'a']--;
                        if (count == 1) numUnique--;
                        if (count == k) numNoLessThanK--;
                        l++;
                    }

                    if (numUnique == numUniqueTarget && numUnique == numNoLessThanK)
                    {
                        result = Math.Max(result, r - l + 1);
                    }
                }
            }
            return result;
        }
    }
}
