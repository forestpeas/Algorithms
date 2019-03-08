namespace Algorithms.LeetCode
{
    /* 7. Reverse Integer
     * 
     * Given a 32-bit signed integer, reverse digits of an integer.
     * 
     * Example 1
     * Input: 123
     * Output: 321
     * 
     * Example 2:
     * Input: -123
     * Output: -321
     * 
     * Example 3:
     * Input: 120
     * Output: 21
     * 
     * Note:
     * Assume we are dealing with an environment which could only store integers within the 32-bit signed integer
     * range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
     */
    public class ReverseIntegerSolution
    {
        // Your runtime beats 100.00 % of csharp submissions.
        // Your memory usage beats 81.00 % of csharp submissions.
        public int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int leastSignificantDigit = x % 10;
                // 7 is because int.MaxValue(2147483647)'s least significant digit
                // is 7, and result * 10 is at most 2147483640. Similar logic can
                // be applied when result is negative.
                if (result > int.MaxValue / 10
                    || (result == int.MaxValue / 10 && leastSignificantDigit > 7))
                {
                    return 0;
                }
                if (result < int.MinValue / 10
                    || (result == int.MaxValue / 10 && leastSignificantDigit < -8))
                {
                    return 0;
                }
                result = result * 10 + leastSignificantDigit;
                x = x / 10;
            }
            return result;
        }
    }
}