using System;

namespace Algorithms.LeetCode
{
    /* 516. Longest Palindromic Subsequence
     * 
     * Given a string s, find the longest palindromic subsequence's length in s.
     * You may assume that the maximum length of s is 1000.
     * 
     * Example 1:
     * Input:
     * 
     * "bbbab"
     * Output:
     * 4
     * One possible longest palindromic subsequence is "bbbb".
     * 
     * Example 2:
     * Input:
     * 
     * "cbbd"
     * Output:
     * 2
     * One possible longest palindromic subsequence is "bb".
     */
    public class Longest_Palindromic_Subsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            // Similar to the DP solution of "5. Longest Palindromic Substring".
            // Let dp[j, i] be the answer to s[j...i]. 
            if (s.Length == 0) return 0;
            int[,] dp = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = 1;
                for (int j = i - 1; j >= 0; j--) // Note that we iterate j from right to left because we need dp[j + 1, i].
                {
                    if (s[j] == s[i])
                    {
                        dp[j, i] = dp[j + 1, i - 1] + 2;
                    }
                    else
                    {
                        dp[j, i] = Math.Max(dp[j + 1, i], dp[j, i - 1]);
                    }
                }
            }

            return dp[0, s.Length - 1];
        }
    }
}
