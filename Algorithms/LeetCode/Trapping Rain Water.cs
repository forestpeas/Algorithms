using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 42. Trapping Rain Water
     * Given n non-negative integers representing an elevation map where the width of each bar is 1, 
     * compute how much water it is able to trap after raining.
     * 
     * Example:
     * 
     * Input: [0,1,0,2,1,0,1,3,2,1,2,1]
     * Output: 6
     */
    public class TrappingRainWater
    {
        // Your runtime beats 99.40 % of csharp submissions.
        // Your memory usage beats 16.59 % of csharp submissions.
        public int Trap(int[] height)
        {
            // Use a stack to track those heights that may be "useful" in the future.
            var stack = new Stack<int>();
            int i = 0;
            for (; i < height.Length; i++)
            {
                if (height[i] > 0)
                {
                    stack.Push(i);
                    break;
                }
            }
            int result = 0;
            for (i++; i < height.Length; i++)
            {
                if (height[i] <= 0) continue;

                int lastHeight = stack.Peek();
                if (height[i] < height[lastHeight])
                {
                    result += height[i] * (i - lastHeight - 1);
                    stack.Push(i);
                }
                else
                {
                    result += height[lastHeight] * (i - lastHeight - 1);
                    stack.Pop();
                    // "Use" all the tracked heights that are lower than the current height, then throw them away.
                    while (stack.Count != 0)
                    {
                        int lastLastHeight = stack.Peek();
                        if (height[lastLastHeight] <= height[i])
                        {
                            result += (height[lastLastHeight] - height[lastHeight]) * (i - lastLastHeight - 1);
                            lastHeight = stack.Pop();
                        }
                        else
                        {
                            result += (height[i] - height[lastHeight]) * (i - lastLastHeight - 1);
                            break;
                        }
                    }
                    stack.Push(i);
                }
            }
            return result;
        }

        // Refer to : https://leetcode.com/problems/trapping-rain-water/discuss/17357/Sharing-my-simple-c++-code:-O(n)-time-O(1)-space
        public int TwoPointers(int[] height)
        {
            /* instead of calculating area by height * width, we can think it in a cumulative way. In other words, sum water amount of each bin(width=1).
             * Search from left to right and maintain a max height of left and right separately, which is like a one-side wall of partial container. 
             * Fix the higher one and flow water from the lower part. For example, if current height of left is lower, we fill water in the left bin. 
             * Until left meets right, we filled the whole container.
             */
            int left = 0; int right = height.Length - 1;
            int result = 0;
            int maxleft = 0, maxright = 0;
            while (left <= right)
            {
                if (height[left] <= height[right])
                {
                    if (height[left] >= maxleft) maxleft = height[left];
                    else result += maxleft - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= maxright) maxright = height[right];
                    else result += maxright - height[right];
                    right--;
                }
            }
            return result;
        }
    }
}
