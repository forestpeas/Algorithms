using System;

namespace Algorithms.LeetCode
{
    /* 583. Delete Operation for Two Strings
     * 
     * Given two words word1 and word2, find the minimum number of steps required to make word1
     * and word2 the same, where in each step you can delete one character in either string.
     * 
     * Example 1:
     * Input: "sea", "eat"
     * Output: 2
     * Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".
     */
    public class Delete_Operation_for_Two_Strings
    {
        public int MinDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], 1 + dp[i - 1, j - 1]);
                    }
                }
            }
            return word1.Length + word2.Length - 2 * dp[word1.Length, word2.Length];
        }

        public int MinDistance2(string word1, string word2)
        {
            // top-down
            int[,] mem = new int[word1.Length, word2.Length];
            for (int i = 0; i < word1.Length; i++)
            {
                for (int j = 0; j < word2.Length; j++)
                {
                    mem[i, j] = -1;
                }
            }

            int result = Helper(0, 0);
            return word1.Length - result + word2.Length - result;

            int Helper(int i, int j)
            {
                if (i == word1.Length || j == word2.Length) return 0;
                if (mem[i, j] > 0) return mem[i, j];
                int res = 0;
                for (int x = j; x < word2.Length; x++)
                {
                    if (word1[i] == word2[x])
                    {
                        res = 1 + Helper(i + 1, x + 1);
                        break;
                    }
                }

                res = Math.Max(res, Helper(i + 1, j));
                mem[i, j] = res;
                return res;
            }
        }
    }
}
