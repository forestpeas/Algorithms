using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1239. Maximum Length of a Concatenated String with Unique Characters
     * 
     * Given an array of strings arr. String s is a concatenation of a sub-sequence of arr which
     * have unique characters.
     * 
     * Return the maximum possible length of s.
     * 
     * Example 1:
     * 
     * Input: arr = ["un","iq","ue"]
     * Output: 4
     * Explanation: All possible concatenations are "","un","iq","ue","uniq" and "ique".
     * Maximum length is 4.
     * 
     * Example 2:
     * 
     * Input: arr = ["cha","r","act","ers"]
     * Output: 6
     * Explanation: Possible solutions are "chaers" and "acters".
     * 
     * Example 3:
     * 
     * Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
     * Output: 26
     * 
     * Constraints:
     *     1 <= arr.length <= 16
     *     1 <= arr[i].length <= 26
     *     arr[i] contains only lower case English letters.
     */
    public class Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
    {
        public int MaxLength(IList<string> arr)
        {
            // Similar to "318. Maximum Product of Word Lengths".
            // Every word can be represented as a integer, with every letter corresponding to a bit.
            // The rest is brute-force.
            var masks = new List<int>() { 0 };
            var lengths = new List<int>() { 0 };
            int result = 0;
            foreach (string w in arr)
            {
                int mask = 0;
                bool dup = false;
                int count = 0;
                foreach (char c in w)
                {
                    int tmp = 1 << (c - 'a');
                    if ((mask & tmp) == tmp)
                    {
                        dup = true; // duplicate character
                        break;
                    }
                    mask |= tmp;
                    count++;
                }
                if (dup) continue;

                int size = masks.Count;
                for (int i = 0; i < size; i++)
                {
                    if ((masks[i] & mask) == 0)
                    {
                        masks.Add(masks[i] | mask);
                        lengths.Add(lengths[i] + count);
                        result = Math.Max(result, lengths[i] + count);
                    }
                }
            }

            return result;
        }
    }
}
