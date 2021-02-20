using System;

namespace Algorithms.LeetCode
{
    /* 600. Non-negative Integers without Consecutive Ones
     * 
     * Given a positive integer n, find the number of non-negative integers less than or equal to n, whose
     * binary representations do NOT contain consecutive ones.
     * 
     * Example 1:
     * Input: 5
     * Output: 5
     * Explanation: 
     * Here are the non-negative integers <= 5 with their corresponding binary representations:
     * 0 : 0
     * 1 : 1
     * 2 : 10
     * 3 : 11
     * 4 : 100
     * 5 : 101
     * Among them, only integer 3 disobeys the rule (two consecutive ones) and the other 5 satisfy the rule. 
     */
    public class Non_negative_Integers_without_Consecutive_Ones
    {
        public int FindIntegers(int num)
        {
            // dp[i] means the number of non-negative integers with i digits, including prefix zeroes.
            int[] dp = new int[32];
            dp[0] = 1;
            dp[1] = 2;
            for (int i = 2; i <= 31; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            int res = 0;
            string binary = Convert.ToString(num, 2);
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    // how many numbers we can get if we change this digit to 0
                    res += dp[binary.Length - i - 1];
                    if (i > 0 && binary[i - 1] == '1')
                    {
                        return res;
                    }
                }
            }
            return res + 1; // plus the given number itself
        }
    }
}
