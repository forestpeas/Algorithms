using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1293. Shortest Path in a Grid with Obstacles Elimination
     * 
     * Given a m * n grid, where each cell is either 0 (empty) or 1 (obstacle). In one step,
     * you can move up, down, left or right from and to an empty cell.
     * 
     * Return the minimum number of steps to walk from the upper left corner (0, 0) to the lower
     * right corner (m-1, n-1) given that you can eliminate at most k obstacles. If it is not
     * possible to find such walk return -1.
     * 
     * Example 1:
     * 
     * Input: 
     * grid = 
     * [[0,0,0],
     *  [1,1,0],
     *  [0,0,0],
     *  [0,1,1],
     *  [0,0,0]], 
     * k = 1
     * Output: 6
     * Explanation: 
     * The shortest path without eliminating any obstacle is 10. 
     * The shortest path with one obstacle elimination at position (3,2) is 6.
     * Such path is (0,0) -> (0,1) -> (0,2) -> (1,2) -> (2,2) -> (3,2) -> (4,2).
     * 
     * Example 2:
     * 
     * Input: 
     * grid = 
     * [[0,1,1],
     *  [1,1,1],
     *  [1,0,0]], 
     * k = 1
     * Output: -1
     * Explanation: 
     * We need to eliminate at least two obstacles to find such a walk.
     */
    public class Shortest_Path_in_a_Grid_with_Obstacles_Elimination
    {
        public int ShortestPath(int[][] grid, int k)
        {
            // We represent the search state as (i, j, k), where k is the number of opportunities
            // left that we can remove obstacles.
            // Similar to "1263. Minimum Moves to Move a Box to Their Target Location".
            int m = grid.Length;
            int n = grid[0].Length;
            State start = new State(0, 0, k);
            var visited = new HashSet<State>() { start };
            var queue = new Queue<State>();
            queue.Enqueue(start);
            int step = -1;
            while (queue.Count != 0)
            {
                step++;
                int size = queue.Count;
                while (size-- > 0)
                {
                    var state = queue.Dequeue();
                    if (state.i == m - 1 && state.j == n - 1) return step;

                    foreach (int[] dir in _directions)
                    {
                        var next = new State(state.i + dir[0], state.j + dir[1], state.k);
                        if (next.i < 0 || next.i >= m || next.j < 0 || next.j >= n) continue;
                        if (grid[next.i][next.j] == 1)
                        {
                            if (next.k == 0) continue;
                            next = new State(next.i, next.j, next.k - 1);
                        }

                        if (visited.Add(next)) queue.Enqueue(next);
                    }
                }
            }

            return -1;
        }

        private class State
        {
            public readonly int i;
            public readonly int j;
            public readonly int k;

            public State(int i, int j, int k)
            {
                this.i = i;
                this.j = j;
                this.k = k;
            }

            public override bool Equals(object obj)
            {
                return obj is State state &&
                       i == state.i &&
                       j == state.j &&
                       k == state.k;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(i, j, k);
            }
        }

        private readonly int[][] _directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    }
}
