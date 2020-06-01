using System;

namespace Algorithms.LeetCode
{
    /* 1401. Circle and Rectangle Overlapping
     * 
     * Given a circle represented as (radius, x_center, y_center) and an axis-aligned
     * rectangle represented as (x1, y1, x2, y2), where (x1, y1) are the coordinates
     * of the bottom-left corner, and (x2, y2) are the coordinates of the top-right
     * corner of the rectangle.
     * 
     * Return True if the circle and rectangle are overlapped otherwise return False.
     * 
     * In other words, check if there are any point (xi, yi) such that belongs to the
     * circle and the rectangle at the same time.
     * 
     * Example 1:
     * https://leetcode.com/problems/circle-and-rectangle-overlapping/
     * Input: radius = 1, x_center = 0, y_center = 0, x1 = 1, y1 = -1, x2 = 3, y2 = 1
     * Output: true
     * Explanation: Circle and rectangle share the point (1,0) 
     * 
     * Constraints:
     * 
     * 1 <= radius <= 2000
     * -10^4 <= x_center, y_center, x1, y1, x2, y2 <= 10^4
     * x1 < x2
     * y1 < y2
     */
    public class Circle_and_Rectangle_Overlapping
    {
        public bool CheckOverlap(int r, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            // inspired by https://stackoverflow.com/a/1879223
            // Find the closest point to the center of the circle within the border of the rectangle.
            // If the center is within the rectangle, the point is the center itself.
            int closestX = Math.Max(x1, Math.Min(x_center, x2)); // limits x_center to the range x1..x2
            int closestY = Math.Max(y1, Math.Min(y_center, y2));
            int distanceX = x_center - closestX;
            int distanceY = y_center - closestY;
            return (distanceX * distanceX) + (distanceY * distanceY) <= r * r;
        }
    }
}
