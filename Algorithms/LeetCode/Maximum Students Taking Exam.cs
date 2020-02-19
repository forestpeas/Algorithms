using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1349. Maximum Students Taking Exam
     * 
     * Given a m * n matrix seats  that represent seats distributions in a classroom. If a seat is broken,
     * it is denoted by '#' character otherwise it is denoted by a '.' character.
     * 
     * Students can see the answers of those sitting next to the left, right, upper left and upper right,
     * but he cannot see the answers of the student sitting directly in front or behind him. Return the
     * maximum number of students that can take the exam together without any cheating being possible.
     * 
     * Students must be placed in seats in good condition.
     * 
     * Example 1:
     * 
     * https://leetcode.com/problems/maximum-students-taking-exam/
     * Input: seats = [["#",".","#","#",".","#"],
     *                 [".","#","#","#","#","."],
     *                 ["#",".","#","#",".","#"]]
     * Output: 4
     * Explanation: Teacher can place 4 students in available seats so they don't cheat on the exam. 
     * 
     * Constraints:
     * seats contains only characters '.' and'#'.
     * m == seats.length
     * n == seats[i].length
     * 1 <= m <= 8
     * 1 <= n <= 8
     */
    public class Maximum_Students_Taking_Exam
    {
        public int MaxStudents(char[][] seats)
        {
            // Inspired by https://leetcode.com/problems/maximum-students-taking-exam/discuss/503686/A-simple-tutorial-on-this-bitmasking-problem
            // Every row can be represented as an integer: bit 1 means there is a seat (or student),
            // bit 0 means there is no seat.
            // dp[i][mask] represents the answer to the first i rows, with the i-th row being "mask".
            // (j & row) == j: check if j is a subset of row.
            // j & (j >> 1): check if there are adjancent 1 bits.
            // For each row, check every possible state (brute-force).
            int m = seats.Length;
            int n = seats[0].Length;
            int[] rows = new int[m];
            for (int i = 0; i < m; i++)
            {
                int curr = 0;
                for (int j = 0; j < n; j++)
                {
                    curr = (curr << 1) + (seats[i][j] == '.' ? 1 : 0);
                }
                rows[i] = curr;
            }

            int[][] dp = new int[m + 1][];
            dp[0] = new int[1 << n];
            Array.Fill(dp[0], -1);
            dp[0][0] = 0;
            for (int i = 1; i <= m; i++)
            {
                dp[i] = new int[1 << n];
                Array.Fill(dp[i], -1);
                int row = rows[i - 1];
                for (int j = 0; j < (1 << n); j++)
                {
                    // [0, 1 << n) includes all the possible states.
                    // j is the current possible row, k is the previous possible row.
                    if ((j & row) == j && (j & (j >> 1)) == 0)
                    {
                        for (int k = 0; k < (1 << n); k++)
                        {
                            if ((j & (k >> 1)) == 0 && ((j >> 1) & k) == 0 && dp[i - 1][k] != -1)
                            {
                                dp[i][j] = Math.Max(dp[i][j], dp[i - 1][k] + NumberOf1Bits(j));
                            }
                        }
                    }
                }
            }

            return dp[m].Max();
        }

        private int NumberOf1Bits(int n)
        {
            // A trick: n &(n - 1) is equal to changing the rightmost 1 in n to 0.
            int sum = 0;
            while (n != 0)
            {
                sum++;
                n = n & (n - 1);
            }
            return sum;
        }
    }
}
