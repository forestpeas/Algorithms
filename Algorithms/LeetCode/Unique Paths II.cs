namespace Algorithms.LeetCode
{
    /* 63. Unique Paths II
     * 
     * A robot is located at the top-left corner of a m x n grid.
     * The robot can only move either down or right at any point in time.
     * The robot is trying to reach the bottom-right corner of the grid.
     * Now consider if some obstacles are added to the grids. How many unique paths would there be?
     * 
     * Note: m and n will be at most 100.
     * 
     * Example 1:
     * 
     * Input:
     * [
     *   [0,0,0],
     *   [0,1,0],
     *   [0,0,0]
     * ]
     * Output: 2
     * 
     * Explanation:
     * There is one obstacle in the middle of the 3x3 grid above.
     * There are two ways to reach the bottom-right corner:
     * 1. Right -> Right -> Down -> Down
     * 2. Down -> Down -> Right -> Right
     */
    public class UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            // obstacleGrid[1][1] = 1
            // 1  1  1  1
            // 1  0  1  2
            // 1  1  2  4
            // 1  2  4  8
            if (obstacleGrid.Length < 1) return 0;
            int[] mem = new int[obstacleGrid[0].Length];
            mem[0] = obstacleGrid[0][0] == 1 ? 0 : 1;
            for (int i = 1; i < mem.Length; i++)
            {
                mem[i] = obstacleGrid[0][i] == 1 ? 0 : mem[i - 1];
            }

            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                mem[0] = obstacleGrid[i][0] == 1 ? 0 : mem[0];
                for (int j = 1; j < mem.Length; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        mem[j] = 0;
                    }
                    else
                    {
                        mem[j] = mem[j] + mem[j - 1];
                    }
                }
            }
            return mem[mem.Length - 1];
        }
    }
}
