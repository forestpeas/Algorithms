namespace Algorithms.LeetCode
{
    /* 576. Out of Boundary Paths
     * 
     * There is an m by n grid with a ball. Given the start coordinate (i,j) of the ball,
     * you can move the ball to adjacent cell or cross the grid boundary in four directions
     * (up, down, left, right). However, you can at most move N times. Find out the number
     * of paths to move the ball out of grid boundary. The answer may be very large, return
     * it after mod 109 + 7. 
     * 
     * Example 1:
     * 
     * Input: m = 2, n = 2, N = 2, i = 0, j = 0
     * Output: 6
     * Explanation:
     * https://leetcode.com/problems/out-of-boundary-paths/
     * 
     * Example 2:
     * 
     * Input: m = 1, n = 3, N = 3, i = 0, j = 1
     * Output: 12
     */
    public class Out_of_Boundary_Paths
    {
        private const int mod = 1000000007;

        public int FindPaths(int m, int n, int N, int i, int j)
        {
            int[,,] mem = new int[m, n, N + 1];
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int z = 0; z <= N; z++)
                    {
                        mem[x, y, z] = -1;
                    }
                }
            }
            return Find(m, n, N, i, j, mem);
        }

        private int Find(int m, int n, int N, int i, int j, int[,,] mem)
        {
            if (i < 0 || i >= m || j < 0 || j >= n) return 1;
            if (N == 0) return 0;
            if (mem[i, j, N] >= 0) return mem[i, j, N];
            long res = 0;
            res += Find(m, n, N - 1, i - 1, j, mem);
            res += Find(m, n, N - 1, i + 1, j, mem);
            res += Find(m, n, N - 1, i, j - 1, mem);
            res += Find(m, n, N - 1, i, j + 1, mem);
            mem[i, j, N] = (int)(res % mod);
            return mem[i, j, N];
        }
    }
}
