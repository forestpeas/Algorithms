using System;

namespace Algorithms.LeetCode
{
    /* 1278. Palindrome Partitioning III
     * 
     * You are given a string s containing lowercase letters and an integer k. You need to :
     * First, change some characters of s to other lowercase English letters.
     * Then divide s into k non-empty disjoint substrings such that each substring is palindrome.
     * 
     * Return the minimal number of characters that you need to change to divide the string.
     * 
     * Example 1:
     * 
     * Input: s = "abc", k = 2
     * Output: 1
     * Explanation: You can split the string into "ab" and "c", and change 1 character in "ab" to make it palindrome.
     * 
     * Example 2:
     * 
     * Input: s = "aabbc", k = 3
     * Output: 0
     * Explanation: You can split the string into "aa", "bb" and "c", all of them are palindrome.
     * 
     * Example 3:
     * 
     * Input: s = "leetcode", k = 8
     * Output: 0
     */
    public class Palindrome_Partitioning_III
    {
        public int PalindromePartition(string s, int k)
        {
            // DP. dp[m,i] is the answer of s[0...i] when k = m.
            // For each substring, check all possibilities of dividing.
            int[] dp = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = Palindrome(s, 0, i);
            }

            for (int m = 2; m <= k; m++)
            {
                int[] nextDp = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (i + 1 < m)
                    {
                        nextDp[i] = dp[i];
                        continue;
                    }

                    nextDp[i] = int.MaxValue;
                    for (int j = 1; j <= i; j++)
                    {
                        nextDp[i] = Math.Min(nextDp[i], dp[j - 1] + Palindrome(s, j, i));
                    }
                }
                dp = nextDp;
            }

            return dp[s.Length - 1];
        }

        // Returns the minimum number of characters that we need to change to make the string a palindrome.
        private int Palindrome(string s, int start, int end)
        {
            int count = 0;
            while (start < end)
            {
                if (s[start++] != s[end--]) count++;
            }
            return count;
        }
    }
}
