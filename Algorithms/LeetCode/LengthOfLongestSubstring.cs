using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* Given a string, find the length of the longest substring without repeating characters.
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
            // Let i and j represent the boundaries of a "Sliding Window": [i,j].
            // map contains the next index of each character in s. So if we find
            // a duplicate character, we can directly update i to the correct index.
            // if we know that the charset is rather small, we can replace map with
            // an array, for example: int[128] for ASCII.
            var map = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                result = Math.Max(result, j - i + 1);
                map[s[j]] = j + 1;
            }
            return result;
        }
    }
}
