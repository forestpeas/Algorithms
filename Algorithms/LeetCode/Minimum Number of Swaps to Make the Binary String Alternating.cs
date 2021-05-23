using System;

namespace Algorithms.LeetCode
{
    /* 1864. Minimum Number of Swaps to Make the Binary String Alternating
     * 
     * Given a binary string s, return the minimum number of character swaps to make it alternating,
     * or -1 if it is impossible.
     * 
     * The string is called alternating if no two adjacent characters are equal. For example, the
     * strings "010" and "1010" are alternating, while the string "0100" is not.
     * 
     * Any two characters may be swapped, even if they are not adjacent. 
     * 
     * Example 1:
     * 
     * Input: s = "111000"
     * Output: 1
     * Explanation: Swap positions 1 and 4: "111000" -> "101010"
     * The string is now alternating.
     * 
     * Example 2:
     * 
     * Input: s = "010"
     * Output: 0
     * Explanation: The string is already alternating, no swaps are needed.
     * 
     * Example 3:
     * 
     * Input: s = "1110"
     * Output: -1
     * 
     * Constraints: 
     * 1 <= s.length <= 1000
     * s[i] is either '0' or '1'.
     */
    public class Minimum_Number_of_Swaps_to_Make_the_Binary_String_Alternating
    {
        public int MinSwaps(string s)
        {
            int res = Math.Min(MinSwaps('0'), MinSwaps('1'));
            return res == int.MaxValue ? -1 : res;

            int MinSwaps(char template)
            {
                int swapOnes = 0, swapZeroes = 0;
                foreach (char c in s)
                {
                    if (c != template)
                    {
                        if (c == '1') swapOnes++;
                        else swapZeroes++;
                    }
                    template = template == '1' ? '0' : '1';
                }
                return swapOnes == swapZeroes ? swapOnes : int.MaxValue;
            }
        }
    }
}
