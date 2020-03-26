using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1368. Minimum Cost to Make at Least One Valid Path in a Grid
     * 
     * Given a m x n grid. Each cell of the grid has a sign pointing to the next cell you should visit if you are currently in this cell. The sign of grid[i][j] can be:
     * 1 which means go to the cell to the right. (i.e go from grid[i][j] to grid[i][j + 1])
     * 2 which means go to the cell to the left. (i.e go from grid[i][j] to grid[i][j - 1])
     * 3 which means go to the lower cell. (i.e go from grid[i][j] to grid[i + 1][j])
     * 4 which means go to the upper cell. (i.e go from grid[i][j] to grid[i - 1][j])
     * Notice that there could be some invalid signs on the cells of the grid which points outside the grid.
     * 
     * You will initially start at the upper left cell (0,0). A valid path in the grid is a path which starts from the upper left cell (0,0) and ends at the bottom-right cell (m - 1, n - 1) following the signs on the grid. The valid path doesn't have to be the shortest.
     * 
     * You can modify the sign on a cell with cost = 1. You can modify the sign on a cell one time only.
     * 
     * Return the minimum cost to make the grid have at least one valid path.
     * 
     * https://leetcode.com/problems/minimum-cost-to-make-at-least-one-valid-path-in-a-grid/
     * 
     * Example 1:
     * 
     * Input: grid = [[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]
     * Output: 3
     * Explanation: You will start at point (0, 0).
     * The path to (3, 3) is as follows. (0, 0) --> (0, 1) --> (0, 2) --> (0, 3) change the arrow to down with cost = 1 --> (1, 3) --> (1, 2) --> (1, 1) --> (1, 0) change the arrow to down with cost = 1 --> (2, 0) --> (2, 1) --> (2, 2) --> (2, 3) change the arrow to down with cost = 1 --> (3, 3)
     * The total cost = 3.
     * 
     * Example 2:
     * 
     * Input: grid = [[1,1,3],[3,2,2],[1,1,4]]
     * Output: 0
     * Explanation: You can follow the path from (0, 0) to (2, 2).
     * 
     * Example 3:
     * 
     * Input: grid = [[1,2],[4,3]]
     * Output: 1
     * 
     * Example 4:
     * 
     * Input: grid = [[2,2,2],[2,2,2]]
     * Output: 3
     * 
     * Example 5:
     * 
     * Input: grid = [[4]]
     * Output: 0
     */
    public class Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid
    {
        public int MinCost(int[][] grid)
        {
            // state[i,j] is the current known minimum cost from point (0,0) to point (i,j). Starting from (0,0),
            // we greedily choose the neighbor with 0 cost, and put other neighbors in a deque for future dispose.
            // deque contains all the points to be dealt with next. Note that the absolute difference of the cost
            // of any two points in the deque is at most 1, e.g. [1,1,1,2,2,2,2]. So we can add the "smaller
            // points" to its head and the "larger points" to its tail, and "pop" from its head. If a neighbor
            // has already been visited and its cost is less or equal to the current processing point, we don't
            // want to add it to deque. If a neighbor has already been visited but its cost was larger, we should
            // relocate its position in the deque, but we can also simply add a smaller one to the head because
            // when this old larger neighbor is popped, it will only find that all the 4 directions are less or
            // equal to itself.
            // Another approach: represent the grid as a directed weighted graph and use Dijkstra's algorithm.
            int m = grid.Length, n = grid[0].Length;
            int[,] state = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    state[i, j] = int.MaxValue;
                }
            }
            state[0, 0] = 0;

            var deque = new LinkedList<Point>();
            deque.AddFirst(new Point(0, 0));
            while (deque.Count != 0)
            {
                var point = deque.First.Value;
                deque.RemoveFirst();
                foreach (int[] d in _dir)
                {
                    var nbr = new Point(point.row + d[0], point.col + d[1]);
                    if (nbr.row < 0 || nbr.row >= m || nbr.col < 0 || nbr.col >= n) continue;
                    if (state[nbr.row, nbr.col] <= state[point.row, point.col]) continue; // already visited
                    if (grid[point.row][point.col] == d[2])
                    {
                        state[nbr.row, nbr.col] = state[point.row, point.col];
                        deque.AddFirst(nbr);
                    }
                    else
                    {
                        state[nbr.row, nbr.col] = state[point.row, point.col] + 1;
                        deque.AddLast(nbr);
                    }
                }
            }

            return state[m - 1, n - 1];
        }


        private static readonly int[][] _dir = new int[][] { new int[] { 1, 0, 3 }, new int[] { -1, 0, 4 }, new int[] { 0, 1, 1 }, new int[] { 0, -1, 2 } };

        private class Point
        {
            public int row;
            public int col;

            public Point(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }
    }
}
