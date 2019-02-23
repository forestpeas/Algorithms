using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class ReverseIntegerSolution
    {
        public int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int leastSignificantDigit = x % 10;
                // 7 is because int.MaxValue(2147483647)'s least significant digit
                // is 7, and result * 10 is at most 2147483640. Similar logic can
                //be applied when result is negative.
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