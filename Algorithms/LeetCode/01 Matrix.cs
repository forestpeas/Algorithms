using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 542. 01 Matrix
     * 
     * Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell.
     * 
     * The distance between two adjacent cells is 1.
     * 
     * Example 1:
     * 
     * Input:
     * [[0,0,0],
     *  [0,1,0],
     *  [0,0,0]]
     * 
     * Output:
     * [[0,0,0],
     *  [0,1,0],
     *  [0,0,0]]
     * 
     * Example 2:
     * 
     * Input:
     * [[0,0,0],
     *  [0,1,0],
     *  [1,1,1]]
     * 
     * Output:
     * [[0,0,0],
     *  [0,1,0],
     *  [1,2,1]]
     */
    public class _01_Matrix
    {
        public int[][] UpdateMatrix(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            var queue = new Queue<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                    }
                    else
                    {
                        matrix[i][j] = int.MaxValue;
                    }
                }
            }

            int dist = 1;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                while (size-- > 0)
                {
                    int[] point = queue.Dequeue();
                    foreach (int[] d in directions)
                    {
                        int i = point[0] + d[0], j = point[1] + d[1];
                        if (i < 0 || i >= m || j < 0 || j >= n || matrix[i][j] <= dist) continue;
                        matrix[i][j] = dist;
                        queue.Enqueue(new int[] { i, j });
                    }
                }
                dist++;
            }
            return matrix;
        }

        private static readonly int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    }
}
