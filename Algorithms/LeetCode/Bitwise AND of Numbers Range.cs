namespace Algorithms.LeetCode
{
    /* 201. Bitwise AND of Numbers Range
     * 
     * Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers
     * in this range, inclusive.
     * 
     * Example 1:
     * 
     * Input: [5,7]
     * Output: 4
     * Explanation: 4 = 5 & 6 & 7
     * 
     * Example 2:
     * 
     * Input: [0,1]
     * Output: 0
     */
    public class BitwiseAndOfNumbersRange
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            // Inspired by the discuss section. For example, from m to n:
            // 11010 m
            // 11011
            // 11100
            // 11101
            // 11110 n
            //
            // For each bit, if there is at least one 0, the final bit is always 0.
            // In this example, the common prefix of m and n is 11xxx, there is always
            // a different bit on the right 3 bits, which means there must be a 0.
            while (n > m)
            {
                n &= (n - 1); // Change the rightmost 1 to 0.
            }
            return m & n;
        }

        public int RangeBitwiseAnd2(int m, int n)
        {
            // My first try on this problem.
            // For every bit from least significant bit to most significant bit of m,
            // if the bit is 1, when will it change to 0? For example: m = 
            // 01101
            //   ↑
            //  bit
            // Increase m:
            // 01101
            // 01110
            // 01111
            // 10000
            //   ↑
            //  Now it changes to 0!
            // So if 10000 is greater than n, this bit of 1 shall be preserved in the result.
            // How to get 10000 from 01101? Just turn the right bits to 0, then add m and
            // the current mask: 01100 + 00100 = 10000.
            int result = 0;

            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if ((mask & m) == mask) // If the bit is 1.
                {
                    if ((uint)(m + mask) > (uint)n) // Be careful of overflow.
                    {
                        result |= mask; // Preserve the bit.
                    }

                    m &= ~mask; // Set the current bit to 0.
                }
            }

            return result;
        }
    }
}
