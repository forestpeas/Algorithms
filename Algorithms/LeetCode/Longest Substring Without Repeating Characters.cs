using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 3. Longest Substring Without Repeating Characters
     * 
     * Given a string, find the length of the longest substring without repeating characters.
     * 
     * Example 1:
     * Input: "abcabcbb"
     * Output: 3 
     * Explanation: The answer is "abc", with the length of 3. 
     * 
     * Example 2:
     * Input: "bbbbb"
     * Output: 1
     * Explanation: The answer is "b", with the length of 1.
     * 
     * Example 3:
     * Input: "pwwkew"
     * Output: 3
     * Explanation: The answer is "wke", with the length of 3. 
     * Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
     */
    public class LengthOfLongestSubstringSolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length, result = 0;
            // Let i and j represent the boundaries of a sliding window [i,j] that only contains unique characters.
            // map contains the next index of each character in s. So if we find a duplicate character,
            // we can directly update i to the correct index(shrink the window). If we know that the charset
            // is rather small, we can replace map with an array, for example: int[128] for ASCII.
            var map = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.TryGetValue(s[j], out int next))
                {
                    // For example: s = ..x..y..y...x
                    // "." are all different characters.
                    // When we find y = y, i is updated to "index of the first y" + 1.
                    // When we find x = x, i is pointing "index of the first y" + 1 and stays the same.
                    i = Math.Max(i, next);
                }
                result = Math.Max(result, j - i + 1);
                map[s[j]] = j + 1;
            }
            return result;
        }
    }
}
