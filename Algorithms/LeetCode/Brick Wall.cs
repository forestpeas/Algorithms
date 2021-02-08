using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 554. Brick Wall
     * 
     * There is a brick wall in front of you. The wall is rectangular and has several rows of bricks.
     * The bricks have the same height but different width. You want to draw a vertical line from the
     * top to the bottom and cross the least bricks.
     * 
     * The brick wall is represented by a list of rows. Each row is a list of integers representing
     * the width of each brick in this row from left to right.
     * 
     * If your line go through the edge of a brick, then the brick is not considered as crossed. You
     * need to find out how to draw the line to cross the least bricks and return the number of
     * crossed bricks.
     * 
     * You cannot draw a line just along one of the two vertical edges of the wall, in which case the
     * line will obviously cross no bricks.
     * 
     * Example:
     * https://leetcode.com/problems/brick-wall/
     * Input: [[1,2,2,1],
     *         [3,1,2],
     *         [1,3,2],
     *         [2,4],
     *         [3,1,2],
     *         [1,3,1,1]]
     * 
     * Output: 2
     */
    public class Brick_Wall
    {
        public int LeastBricks(IList<IList<int>> wall)
        {
            var capsCount = new Dictionary<int, int>();
            foreach (var row in wall)
            {
                int pos = 0;
                foreach (var brick in row.Take(row.Count - 1))
                {
                    pos += brick;
                    capsCount[pos] = capsCount.GetValueOrDefault(pos) + 1;
                }
            }
            if (capsCount.Count == 0) return wall.Count;
            return wall.Count - capsCount.Values.Max();
        }
    }
}
