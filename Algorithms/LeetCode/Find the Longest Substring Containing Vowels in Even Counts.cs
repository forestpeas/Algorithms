using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1371. Find the Longest Substring Containing Vowels in Even Counts
     * 
     * Given the string s, return the size of the longest substring containing each vowel an even number of times.
     * That is, 'a', 'e', 'i', 'o', and 'u' must appear an even number of times.
     * 
     * Example 1:
     * 
     * Input: s = "eleetminicoworoep"
     * Output: 13
     * Explanation: The longest substring is "leetminicowor" which contains two each of the vowels: e, i and o and
     * zero of the vowels: a and u.
     * 
     * Example 2:
     * 
     * Input: s = "leetcodeisgreat"
     * Output: 5
     * Explanation: The longest substring is "leetc" which contains two e's.
     * 
     * Example 3:
     * 
     * Input: s = "bcbcbc"
     * Output: 6
     * Explanation: In this case, the given string "bcbcbc" is the longest because all vowels: a, e, i, o and u appear
     * zero times.
     */
    public class Find_the_Longest_Substring_Containing_Vowels_in_Even_Counts
    {
        public int FindTheLongestSubstring(string s)
        {
            // For each substring s[0..i], we need to save its state:
            // (number of 'a', number of 'e', number of 'i', number of 'o', number of 'u')
            // Or more simply, we only need to know whether each number of vowel is even or odd.
            // So we can represent even with 1 and odd with 0, and a state with an integer.
            // For each state, find the leftmost substring with the same state, because
            // odd - odd = even, even - even = even, odd - even = odd.
            string vowels = "aeiou";
            int res = 0, curr = 0;
            var seen = new Dictionary<int, int>() { { 0, -1 } };
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i])) curr ^= 1 << vowels.IndexOf(s[i]);
                if (!seen.ContainsKey(curr)) seen.Add(curr, i);
                res = Math.Max(res, i - seen[curr]);
            }
            return res;
        }
    }
}
