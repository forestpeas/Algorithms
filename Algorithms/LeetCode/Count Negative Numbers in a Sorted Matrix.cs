namespace Algorithms.LeetCode
{
    /* 1351. Count Negative Numbers in a Sorted Matrix
     * 
     * Given a m * n matrix grid which is sorted in non-increasing order both row-wise and column-wise. 
     * 
     * Return the number of negative numbers in grid.
     * 
     * Example 1:
     * 
     * Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
     * Output: 8
     * Explanation: There are 8 negatives number in the matrix.
     * 
     * Example 2:
     * 
     * Input: grid = [[3,2],[1,0]]
     * Output: 0
     * 
     * Example 3:
     * 
     * Input: grid = [[1,-1],[-1,-1]]
     * Output: 3
     * 
     * Example 4:
     * 
     * Input: grid = [[-1]]
     * Output: 1
     */
    public class Count_Negative_Numbers_in_a_Sorted_Matrix
    {
        public int CountNegatives(int[][] grid)
        {
            // Similar to "240. Search a 2D Matrix II".
            int m = grid.Length, n = grid[0].Length;
            int i = m - 1, j = 0;
            int result = 0;
            while (i >= 0 && j < n)
            {
                if (grid[i][j] < 0)
                {
                    result += n - j;
                    i--;
                }
                else
                {
                    j++;
                }
            }
            return result;
        }
    }
}
