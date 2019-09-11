namespace Algorithms.LeetCode
{
    /* 233. Number of Digit One
     * 
     * Given an integer n, count the total number of digit 1 appearing in all non-negative
     * integers less than or equal to n.
     * 
     * Example:
     * 
     * Input: 13
     * Output: 6 
     * Explanation: Digit 1 occurred in the following numbers: 1, 10, 11, 12, 13.
     */
    public class NumberOfDigitOne
    {
        // Inspired by https://leetcode.com/problems/number-of-digit-one/discuss/64381/4%2B-lines-O(log-n)-C%2B%2BJavaPython
        // For example: n = 3141592
        // First we consider one's position, then ten's position, then hundred's position...
        // When we come to hundred's position,
        // a = 31415, b = 92
        // We can fix the rightmost three digits being 100, so the digits to the left are
        // 0    100
        // 1    100
        // 2    100
        // 3    100
        // ...  100
        // 3141 100
        // So from 0 to 3141 there are 3142 numbers in total. The fixed "100" can also be [100-199],
        // So there are 3142 * 100 ones in total.
        // If a = 31410, there are only 3141 * 100 ones, because the last [3141 xxx]'s xxx can only
        // be 0xx(hunded's position is 0, not reaching [100-199]).
        // If n = 3141192, thus a = 31411, b = 92
        // there are 3141 * 100 + 93 ones. Because the last [3141 xxx]'s xxx can be [100-192].
        public int CountDigitOne(int n)
        {
            long result = 0;
            for (long position = 1; position <= n; position *= 10)
            {
                long a = n / position;
                long b = n % position;
                long digit = a % 10;
                if (digit == 0)
                {
                    result += a / 10 * position;
                }
                else if (digit == 1)
                {
                    result += a / 10 * position + (b + 1);
                }
                else
                {
                    result += (a / 10 + 1) * position;
                }
            }
            return (int)result;
        }
    }
}
