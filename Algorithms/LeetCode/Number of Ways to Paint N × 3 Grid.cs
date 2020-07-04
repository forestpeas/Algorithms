using System;

namespace Algorithms.LeetCode
{
    /* 1411. Number of Ways to Paint N × 3 Grid
     * 
     * https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/
     * You have a grid of size n x 3 and you want to paint each cell of the grid with exactly one of the
     * three colours: Red, Yellow or Green while making sure that no two adjacent cells have the same
     * colour (i.e no two cells that share vertical or horizontal sides have the same colour).
     * 
     * You are given n the number of rows of the grid.
     * 
     * Return the number of ways you can paint this grid. As the answer may grow large, the answer must
     * be computed modulo 10^9 + 7.
     * 
     */
    public class Number_of_Ways_to_Paint_N___3_Grid
    {
        public int NumOfWays(int n)
        {
            // dp[i] is the number of ways in which the grid's bottom row is @base[i].
            // dp[i] is only related to dp[i-1].
            // Simpler code: https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/discuss/574923/JavaC%2B%2BPython-DP-O(1)-Space
            const int mod = 1000000007;
            Row[] @base = new Row[]
            {
                new Row(1,2,1), new Row(1, 2, 3), new Row(1, 3, 1), new Row(1, 3, 2),
                new Row(2,1,2), new Row(2, 1, 3), new Row(2, 3, 1), new Row(2, 3, 2),
                new Row(3,1,2), new Row(3, 1, 3), new Row(3, 2, 1), new Row(3, 2, 3),
            };
            int[] dp = new int[12];
            Array.Fill(dp, 1);
            while (--n > 0)
            {
                int[] dp_next = new int[12];
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (NoAdjacent(@base[i], @base[j]))
                        {
                            dp_next[i] += dp[j];
                            dp_next[i] %= mod;
                        }
                    }
                }

                dp = dp_next;
            }

            int res = 0;
            foreach (int i in dp)
            {
                res += i;
                res %= mod;
            }
            return res;
        }

        private bool NoAdjacent(Row r1, Row r2)
        {
            return r1.c1 != r2.c1 && r1.c2 != r2.c2 && r1.c3 != r2.c3;
        }

        private struct Row
        {
            public int c1;
            public int c2;
            public int c3;

            public Row(int c1, int c2, int c3)
            {
                this.c1 = c1;
                this.c2 = c2;
                this.c3 = c3;
            }
        }
    }
}
