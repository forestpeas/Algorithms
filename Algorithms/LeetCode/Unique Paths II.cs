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
            // Similar to "Problem 62. Unique Paths". The only difference is that
            // if "obstacleGrid[i][j]" is 1, then mem[i][j] is 0.
            // For example: obstacleGrid is a 4 x 4 grid. The only obstacle in it is obstacleGrid[1][1].
            // "mem" should be:
            // 1  1  1  1
            // 1  0  1  2
            // 1  1  2  4
            // 1  2  4  8
            if (obstacleGrid.Length < 1) return 0;
            int[] mem = new int[obstacleGrid[0].Length]; // "mem" records every row in the grid above
            mem[0] = 1;
            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                mem[0] = obstacleGrid[i][0] == 1 ? 0 : mem[0];
                for (int j = 1; j < mem.Length; j++)
                {
                    mem[j] = obstacleGrid[i][j] == 1 ? 0 : mem[j] + mem[j - 1];
                }
            }
            return mem[mem.Length - 1];
        }
    }
}
