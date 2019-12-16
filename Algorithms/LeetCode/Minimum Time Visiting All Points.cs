using System;

namespace Algorithms.LeetCode
{
    /* 1266. Minimum Time Visiting All Points
     * 
     * On a plane there are n points with integer coordinates points[i] = [xi, yi].
     * Your task is to find the minimum time in seconds to visit all points.
     * 
     * https://leetcode.com/problems/minimum-time-visiting-all-points/
     */
    public class Minimum_Time_Visiting_All_Points
    {
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int result = 0;
            for (int i = 1; i < points.Length; i++)
            {
                // Take the diagonal path as much as possible.
                int dx = Math.Abs(points[i][0] - points[i - 1][0]);
                int dy = Math.Abs(points[i][1] - points[i - 1][1]);
                result += Math.Max(dx, dy);
            }
            return result;
        }
    }
}
