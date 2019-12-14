namespace Algorithms.LeetCode
{
    /* 1267. Count Servers that Communicate
     * 
     * You are given a map of a server center, represented as a m * n integer matrix grid,
     * where 1 means that on that cell there is a server and 0 means that it is no server.
     * Two servers are said to communicate if they are on the same row or on the same column.
     * Return the number of servers that communicate with any other server.
     * 
     * https://leetcode.com/problems/count-servers-that-communicate/
     */
    public class Count_Servers_that_Communicate
    {
        public int CountServers(int[][] grid)
        {
            // Mark each server to corresponding row and column.
            // A bit similar to "1252. Cells with Odd Values in a Matrix".
            int m = grid.Length;
            int n = grid[0].Length;
            int[] rows = new int[m];
            int[] cols = new int[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        rows[i]++;
                        cols[j]++;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && (rows[i] > 1 || cols[j] > 1))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
