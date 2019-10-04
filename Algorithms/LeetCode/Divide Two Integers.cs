using System;

namespace Algorithms.LeetCode
{
    /* 29. Divide Two Integers
     * 
     * Given two integers dividend and divisor, divide two integers without using multiplication, division and mod operator.
     * Return the quotient after dividing dividend by divisor.
     * The integer division should truncate toward zero.
     * 
     * Example 1:
     * 
     * Input: dividend = 10, divisor = 3
     * Output: 3
     * 
     * Example 2:
     * 
     * Input: dividend = 7, divisor = -3
     * Output: -2
     * 
     * Note:
     *     Both dividend and divisor will be 32-bit signed integers.
     *     The divisor will never be 0.
     *     Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. 
     *     For the purpose of this problem, assume that your function returns 231 − 1 when the division result overflows.
     */
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
            long dividendL = Math.Abs((long)dividend);
            long divisorL = Math.Abs((long)divisor);
            int quotient = 0;
            // Adding one divisor each time is too slow. We can multiply divisor.
            // Like divisor * 2, divisor * 4, divisor * 8, ...
            // But once we get greater than dividend, we stop right before the greater result.
            // And let dividend = divident - "the result we get".
            // And continue like this until dividend is less than divisor.
            // For example: dividend = 16, divisor = 3
            // first iteration: dividend = 16, shiftSize = 2, quotient = 4
            // second iteration: dividend = 16 - (3 << 2) = 4, quotient = 4 + 1 = 5
            // then: dividend = 4 - 3 < 3, done
            while (dividendL >= divisorL)
            {
                int shiftSize = 0;
                long shiftResult = divisorL << 1;
                while (shiftResult <= dividendL)
                {
                    shiftSize++;
                    shiftResult = divisorL << (shiftSize + 1);
                }
                quotient += (1 << shiftSize);
                dividendL = dividendL - (divisorL << shiftSize);
            }

            return sign * quotient;
        }
    }
}
