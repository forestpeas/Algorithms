using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 407. Trapping Rain Water II
     * 
     * Given an m x n matrix of positive integers representing the height of each unit cell in a 2D
     * elevation map, compute the volume of water it is able to trap after raining.
     * 
     * Example:
     * https://leetcode.com/problems/trapping-rain-water-ii/
     * Given the following 3x6 height map:
     * [
     *   [1,4,3,1,3,2],
     *   [3,2,1,3,2,4],
     *   [2,3,3,2,3,1]
     * ]
     * Return 4.
     * 
     * Constraints:
     * 1 <= m, n <= 110
     * 0 <= heightMap[i][j] <= 20000
     */
    public class Trapping_Rain_Water_II
    {
        public int TrapRainWater(int[][] heights)
        {
            var pq = new PriorityQueue<(int i, int j)>(Comparer<(int i, int j)>.Create((x, y) => heights[y.i][y.j] - heights[x.i][x.j]));
            int m = heights.Length, n = heights[0].Length;
            bool[,] visited = new bool[m, n];
            // visit all the cells on the borders
            for (int i = 0; i < m; i++)
            {
                visited[i, 0] = true;
                visited[i, n - 1] = true;
                pq.Add((i, 0));
                pq.Add((i, n - 1));
            }
            for (int i = 0; i < n; i++)
            {
                visited[0, i] = true;
                visited[m - 1, i] = true;
                pq.Add((0, i));
                pq.Add((m - 1, i));
            }

            int maxHeight = 0, res = 0;
            while (pq.Count != 0)
            {
                var (min_i, min_j) = pq.DeleteTop();
                maxHeight = Math.Max(maxHeight, heights[min_i][min_j]);
                foreach (int[] dir in dirs)
                {
                    int i = min_i + dir[0];
                    int j = min_j + dir[1];
                    if (i >= 0 && i < m && j >= 0 && j < n && !visited[i, j])
                    {
                        visited[i, j] = true;
                        res += Math.Max(0, maxHeight - heights[i][j]);
                        pq.Add((i, j));
                    }
                }
            }
            return res;
        }

        private static readonly int[][] dirs = new int[][]
        {
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int[] { 0, -1 },
        };
    }
}
