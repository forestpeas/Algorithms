using System;

namespace Algorithms.LeetCode
{
    /* 1758. Minimum Changes To Make Alternating Binary String
     * 
     * You are given a string s consisting only of the characters '0' and '1'. In one operation, you can change
     * any '0' to '1' or vice versa.
     * 
     * The string is called alternating if no two adjacent characters are equal. For example, the string "010"
     * is alternating, while the string "0100" is not.
     * 
     * Return the minimum number of operations needed to make s alternating.
     * 
     * Example 1:
     * 
     * Input: s = "0100"
     * Output: 1
     * Explanation: If you change the last character to '1', s will be "0101", which is alternating.
     * Example 2:
     * 
     * Input: s = "10"
     * Output: 0
     * Explanation: s is already alternating.
     * Example 3:
     * 
     * Input: s = "1111"
     * Output: 2
     * Explanation: You need two operations to reach "0101" or "1010".
     */
    public class Minimum_Changes_To_Make_Alternating_Binary_String
    {
        public int MinOperations(string s)
        {
            // either starts with 1 or 0
            int f1 = 1, f0 = 0, res1 = 0, res2 = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                res1 += s[i] - '0' != f1 ? 1 : 0;
                res2 += s[i] - '0' != f0 ? 1 : 0;
                f1 = f1 == 1 ? 0 : 1;
                f0 = f0 == 1 ? 0 : 1;
            }
            return Math.Min(res1, res2);
        }
    }
}
