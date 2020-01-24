namespace Algorithms.LeetCode
{
    /* 1318. Minimum Flips to Make a OR b Equal to c
     * 
     * Given 3 positives numbers a, b and c. Return the minimum flips required in some
     * bits of a and b to make ( a OR b == c ). (bitwise OR operation).
     * Flip operation consists of change any single bit 1 to 0 or change the bit 0 to 1
     * in their binary representation.
     * 
     *  https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/
     * 
     * Example 1:
     * 
     * Input: a = 2, b = 6, c = 5
     * Output: 3
     * Explanation: After flips a = 1 , b = 4 , c = 5 such that (a OR b == c)
     * 
     * Example 2:
     * 
     * Input: a = 4, b = 2, c = 7
     * Output: 1
     * 
     * Example 3:
     * 
     * Input: a = 1, b = 2, c = 3
     * Output: 0
     */
    public class Minimum_Flips_to_Make_a_OR_b_Equal_to_c
    {
        public int MinFlips(int a, int b, int c)
        {
            // Consider all cases for every single bit.
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                bool a_isZero = (a & mask) == 0;
                bool b_isZero = (b & mask) == 0;
                if ((c & mask) == 0)
                {
                    if (!a_isZero) result++;
                    if (!b_isZero) result++;
                }
                else
                {
                    if (a_isZero && b_isZero) result++;
                }
            }

            return result;
        }
    }
}
