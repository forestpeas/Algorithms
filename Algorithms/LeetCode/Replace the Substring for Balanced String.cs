using System;

namespace Algorithms.LeetCode
{
    /* 1234. Replace the Substring for Balanced String
     * 
     * You are given a string containing only 4 kinds of characters 'Q', 'W', 'E' and 'R'.
     * A string is said to be balanced if each of its characters appears n/4 times where n
     * is the length of the string.
     * 
     * Return the minimum length of the substring that can be replaced with any other string
     * of the same length to make the original string s balanced.
     * 
     * Return 0 if the string is already balanced.
     * 
     * Example 1:
     * 
     * Input: s = "QWER"
     * Output: 0
     * Explanation: s is already balanced.
     * 
     * Example 2:
     * 
     * Input: s = "QQWE"
     * Output: 1
     * Explanation: We need to replace a 'Q' to 'R', so that "RQWE" (or "QRWE") is balanced.
     * 
     * Example 3:
     * 
     * Input: s = "QQQW"
     * Output: 2
     * Explanation: We can replace the first "QQ" to "ER". 
     * 
     * Example 4:
     * 
     * Input: s = "QQQQ"
     * Output: 3
     * Explanation: We can replace the last 3 'Q' to make s = "QWER".
     * 
     * Constraints:
     * 
     * 1 <= s.length <= 10^5
     * s.length is a multiple of 4
     * s contains only 'Q', 'W', 'E' and 'R'.
     */
    public class ReplaceTheSubstringForBalancedString
    {
        public int BalancedString(string s)
        {
            // Sliding window.
            int[] count = new int[128];
            int targetNum = 0; // Only consider characters that appear more than n/4 times.
            foreach (char c in s) count[c]++;
            foreach (char c in new char[] { 'Q', 'W', 'E', 'R' })
            {
                count[c] -= s.Length / 4;
                if (count[c] > 0) targetNum++;
            }
            if (targetNum == 0) return 0;

            int result = int.MaxValue;
            int num = 0;
            // Each character c in s[i...j] must satisfy count[s[c]] <= 0.
            for (int l = 0, r = 0; r < s.Length; r++)
            {
                // Ensure [i,j] contains enough characters we are looking for.
                if (--count[s[r]] == 0) num++;
                if (num < targetNum) continue;

                // If count[s[l]] == 0, we can't increase its count any more.
                while (count[s[l]] != 0)
                {
                    ++count[s[l]];
                    l++;
                }

                result = Math.Min(result, r - l + 1);
            }

            return result;
        }
    }
}
