using System;

namespace Algorithms.LeetCode
{
    /* 11. Container With Most Water
     * 
     * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
     * n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0).
     * Find two lines, which together with x-axis forms a container, such that the container contains the most water.
     * 
     * Note: You may not slant the container and n is at least 2.
     */
    public class ContainerWithMostWater
    {
        // Your runtime beats 100.00 % of csharp submissions.
        // Your memory usage beats 49.62 % of csharp submissions.
        public int MaxArea(int[] height)
        {
            // Greedy algorithm. We start from the container with the most wide width. Because the area is always
            // constricted by the shorter line, we move the shorter line inwards, looking for a probably longer line instead.
            // In this way, we have the max area of all the lines we've currently visited.
            int maxArea = 0, lo = 0, hi = height.Length - 1;
            while (lo < hi)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[lo], height[hi]) * (hi - lo));
                if (height[lo] < height[hi])
                {
                    lo++;
                }
                else
                {
                    hi--;
                }
            }
            return maxArea;
        }
    }
}
