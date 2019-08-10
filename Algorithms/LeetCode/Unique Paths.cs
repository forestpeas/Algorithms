using System.Numerics;

namespace Algorithms.LeetCode
{
    /* 62. Unique Paths
     * 
     * A robot is located at the top-left corner of a m x n grid.
     * The robot can only move either down or right at any point in time. 
     * The robot is trying to reach the bottom-right corner of the grid.
     * 
     * How many possible unique paths are there?
     * Note: m and n will be at most 100.
     * 
     * For illustration, refer to https://leetcode.com/problems/unique-paths/
     * 
     * Example 1:
     * 
     * Input: m = 3, n = 2
     * Output: 3
     * Explanation:
     * From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
     * 1. Right -> Right -> Down
     * 2. Right -> Down -> Right
     * 3. Down -> Right -> Right
     * 
     * Example 2:
     * 
     * Input: m = 7, n = 3
     * Output: 28
     */
    public class UniquePathsSolution
    {
        // The robot will move down m-1 steps, and move right n-1 steps.
        // let m=m-1, n=n-1, and the robot will move m+n steps in total.
        // The question becomes equal to "There are m black balls and 
        // n white balls. Balls with the same color are of no difference.
        // How mant possible permutations are there？"
        // Given m+n positions, we only have to choose m positions that are
        // for the black balls, and the left are for the white balls.
        // So the answer is C(m+n,m).
        public int UniquePathsCombination(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            m--;
            n--;
            BigInteger result = 1;
            for (int i = 1; i <= m; i++)
            {
                result = result * (m + n - i + 1) / i;
            }
            return (int)result;
        }

        public int UniquePaths(int m, int n)
        {
            // DP solution. "mem[i,j]" means the answer of UniquePaths(i, j).
            // For example: m = 4, n = 4, and "mem" should be:
            // 1  1  1  1
            // 1  2  3  4
            // 1  3  6  10
            // 1  4  10 20
            // We can see that: mem[i,j] = mem[i-1,j] + mem[i,j-1]
            if (m <= 1 || n <= 1) return 1;
            if (m > n)
            {
                int tmp = m;
                m = n;
                n = tmp;
            }
            int[,] mem = new int[m, n];
            for (int j = 0; j < n; j++)
            {
                mem[0, j] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                // "mem" is symmetric about its diagonal line.
                if (i < n) mem[i, i] = 2 * mem[i - 1, i];
                for (int j = i + 1; j < n; j++)
                {
                    mem[i, j] = mem[i - 1, j] + mem[i, j - 1];
                }
            }
            return mem[m - 1, n - 1];
        }

        public int UniquePathsRecursive(int m, int n)
        {
            int result = 0;
            UniquePath(1, 1);
            return result;

            void UniquePath(int i, int j)
            {
                if (i + 1 > m || j + 1 > n)
                {
                    // For example, if i reaches m, 
                    // then the only path to the destination is to move down all the way from here.
                    result++;
                    return;
                }
                UniquePath(i + 1, j);
                UniquePath(i, j + 1);
            }
        }
    }
}
