using System;

namespace Algorithms.LeetCode
{
    /* 1312. Minimum Insertion Steps to Make a String Palindrome
     * 
     * Given a string s. In one step you can insert any character at any index of the string.
     * Return the minimum number of steps to make s palindrome.
     * A Palindrome String is one that reads the same backward as well as forward.
     * 
     * Example 1:
     * 
     * Input: s = "zzazz"
     * Output: 0
     * Explanation: The string "zzazz" is already palindrome we don't need any insertions.
     * 
     * Example 2:
     * 
     * Input: s = "mbadm"
     * Output: 2
     * Explanation: String can be "mbdadbm" or "mdbabdm".
     * 
     * Example 3:
     * 
     * Input: s = "leetcode"
     * Output: 5
     * Explanation: Inserting 5 characters the string becomes "leetcodocteel".
     * 
     * Example 4:
     * 
     * Input: s = "g"
     * Output: 0
     * 
     * Example 5:
     * 
     * Input: s = "no"
     * Output: 1
     */
    public class Minimum_Insertion_Steps_to_Make_a_String_Palindrome
    {
        public int MinInsertions(string s)
        {
            // mem[l,r] is the answer to s[l..r].
            // If s[l] != s[r], we can append another s[l] at the end,
            // or another s[r] at the front.
            int[,] mem = new int[s.Length, s.Length];
            for (int l = 0; l < s.Length; l++)
            {
                for (int r = l; r < s.Length; r++)
                {
                    mem[l, r] = -1;
                }
            }

            return F(0, s.Length - 1);

            int F(int l, int r)
            {
                if (l >= r) return 0;
                if (mem[l, r] != -1) return mem[l, r];
                return mem[l, r] = s[l] == s[r] ? F(l + 1, r - 1) : 1 + Math.Min(F(l + 1, r), F(l, r - 1));
            }
        }

        public int MinInsertions2(string s)
        {
            // Exactly the same as "516. Longest Palindromic Subsequence" except the last line.
            // After we find the longest palindromic subsequence, we only have to copy the
            // characters left to "complement" themselves.
            int[,] dp = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = 1;
                for (int j = i - 1; j >= 0; j--)
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

            return s.Length - dp[0, s.Length - 1];
        }
    }
}
