using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 424. Longest Repeating Character Replacement
     * 
     * Given a string s that consists of only uppercase English letters, you can perform at most
     * k operations on that string.
     * 
     * In one operation, you can choose any character of the string and change it to any other
     * uppercase English character.
     * 
     * Find the length of the longest sub-string containing all repeating letters you can get after
     * performing the above operations.
     * 
     * Note:
     * Both the string's length and k will not exceed 10^4.
     * 
     * Example 1:
     * 
     * Input:
     * s = "ABAB", k = 2
     * 
     * Output:
     * 4
     * 
     * Explanation:
     * Replace the two 'A's with two 'B's or vice versa. 
     * 
     * Example 2:
     * 
     * Input:
     * s = "AABABBA", k = 1
     * 
     * Output:
     * 4
     * 
     * Explanation:
     * Replace the one 'A' in the middle with 'B' and form "AABBBBA".
     * The substring "BBBB" has the longest repeating letters, which is 4.
     */
    public class Longest_Repeating_Character_Replacement
    {
        public int CharacterReplacement(string s, int k)
        {
            // Inspired by https://leetcode.com/problems/longest-repeating-character-replacement/discuss/91271/Java-12-lines-O(n)-sliding-window-solution-with-explanation/95833
            // The sliding window never shrink, because we only need to find a longer window.
            int result = 0;
            int[] count = new int[26];
            int maxCount = 0;
            for (int l = 0, r = 0; r < s.Length; r++)
            {
                maxCount = Math.Max(maxCount, ++count[s[r] - 'A']);

                if (r - l + 1 - maxCount > k) // Shift the whole window to the right by one.
                {
                    --count[s[l] - 'A'];
                    l++;
                }

                result = Math.Max(result, r - l + 1);
            }

            return result;
        }

        public int CharacterReplacement2(string s, int k)
        {
            // My solution. Maintain a sliding window such that the character that appears the
            // maximum number of times in it is greater than its length minus k.
            int result = 0;
            int[] count = new int[26];
            for (int l = 0, r = 0; r < s.Length; r++)
            {
                ++count[s[r] - 'A'];

                while (r - l + 1 - count.Max() > k)
                {
                    --count[s[l] - 'A'];
                    l++;
                }

                result = Math.Max(result, r - l + 1);
            }

            return result;
        }
    }
}
