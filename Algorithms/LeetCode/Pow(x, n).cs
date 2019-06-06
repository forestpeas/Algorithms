namespace Algorithms.LeetCode
{
    /* 50. Pow(x, n)
     * 
     * Implement pow(x, n), which calculates x raised to the power n (xn).
     * 
     * Example 1:
     * 
     * Input: 2.00000, 10
     * Output: 1024.00000
     * 
     * Example 2:
     * 
     * Input: 2.10000, 3
     * Output: 9.26100
     * 
     * Example 3:
     * 
     * Input: 2.00000, -2
     * Output: 0.25000
     * Explanation: 2-2 = 1/22 = 1/4 = 0.25
     * 
     * Note:
     * 
     * -100.0 < x < 100.0
     * n is a 32-bit signed integer, within the range [−2^31, 2^31 − 1]
     */
    public class Pow
    {
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            bool neg = false;
            if (n < 0)
            {
                // int.MaxValue's absolute value is 1 less than int.MinValue's,
                // and int.MinValue results in a number so small that its double representation is 0.
                if (n == int.MinValue)
                {
                    if (x == 1 || x == -1) return 1;
                    return 0;
                }
                n = -n;
                neg = true;
            }
            // For example: x = 2, n = 13
            // x = (4)^6, offset = 2
            // x = ((16)^3
            // x = ((256)^1, offset = 2 * 16 = 32
            double offset = 1;
            while (n > 1)
            {
                if ((n & 1) == 1)
                {
                    // n is an odd number
                    offset = offset * x;
                    n = n / 2;
                }
                else
                {
                    n = n / 2; // n is an even number
                }
                x = x * x;
            }
            x = x * offset;
            if (neg) x = 1 / x;
            return x;
        }
    }
}
