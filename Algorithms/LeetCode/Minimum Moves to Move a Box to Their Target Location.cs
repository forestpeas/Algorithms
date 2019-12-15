using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1263. Minimum Moves to Move a Box to Their Target Location
     * 
     * https://leetcode.com/problems/minimum-moves-to-move-a-box-to-their-target-location/
     */
    public class Minimum_Moves_to_Move_a_Box_to_Their_Target_Location
    {
        public int MinPushBox(char[][] grid)
        {
            // We represent the search state as (player_row, player_col, box_row, box_col).
            // Most of the time, the box's position remains unchanged, but when it changes, the 
            // player can go back to those visited grids. We need to explore every possible state.
            int m = grid.Length;
            int n = grid[0].Length;
            int[] player = null, box = null, target = null;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 'S') player = new int[] { i, j };
                    else if (grid[i][j] == 'B') box = new int[] { i, j };
                    else if (grid[i][j] == 'T') target = new int[] { i, j };
                }
            }

            var start = new State(player[0], player[1], box[0], box[1]);
            // Every seen state and the minimum number of pushes needed so far to reach this state.
            var pushes = new Dictionary<State, int> { { start, 0 } };
            int result = int.MaxValue;
            var queue = new Queue<State>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var state = queue.Dequeue();
                if (pushes[state] >= result) continue;
                if (state.box_row == target[0] && state.box_col == target[1])
                {
                    result = Math.Min(result, pushes[state]);
                    continue;
                }

                foreach (int[] dir in _directions)
                {
                    var next = new State(state.player_row + dir[0], state.player_col + dir[1], state.box_row, state.box_col);
                    if (next.player_row < 0 || next.player_row >= m ||
                        next.player_col < 0 || next.player_col >= n ||
                        grid[next.player_row][next.player_col] == '#') continue;

                    if (next.player_row == state.box_row && next.player_col == state.box_col)
                    {
                        next = new State(next.player_row, next.player_col, state.box_row + dir[0], state.box_col + dir[1]);
                        if (next.box_row < 0 || next.box_row >= m ||
                            next.box_col < 0 || next.box_col >= n ||
                            grid[next.box_row][next.box_col] == '#') continue;

                        int push = pushes[state] + 1;
                        if (pushes.TryGetValue(next, out int old) && old <= push) continue;
                        pushes[next] = push;
                        queue.Enqueue(next);
                    }
                    else
                    {
                        if (pushes.TryGetValue(next, out int old) && old <= pushes[state]) continue;
                        pushes[next] = pushes[state];
                        queue.Enqueue(next);
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
        }

        private struct State
        {
            public readonly int player_row;
            public readonly int player_col;
            public readonly int box_row;
            public readonly int box_col;

            public State(int player_row, int player_col, int box_row, int box_col)
            {
                this.player_row = player_row;
                this.player_col = player_col;
                this.box_row = box_row;
                this.box_col = box_col;
            }

            public override bool Equals(object obj)
            {
                return obj is State state &&
                       player_row == state.player_row &&
                       player_col == state.player_col &&
                       box_row == state.box_row &&
                       box_col == state.box_col;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(player_row, player_col, box_row, box_col);
            }
        }

        private readonly int[][] _directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    }
}
