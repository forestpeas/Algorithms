using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 42. Trapping Rain Water
     * 
     * Given n non-negative integers representing an elevation map where the width of each bar is 1, 
     * compute how much water it is able to trap after raining.
     * For illustration, refer to https://leetcode.com/problems/trapping-rain-water/.
     * 
     * Example:
     * 
     * Input: [0,1,0,2,1,0,1,3,2,1,2,1]
     * Output: 6
     */
    public class TrappingRainWater
    {
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

        // Inspired by https://leetcode.com/problems/trapping-rain-water/discuss/17357/Sharing-my-simple-c++-code:-O(n)-time-O(1)-space
        public int TwoPointers(int[] height)
        {
            // For example, when height[left] < height[right], we can always be sure that (maxLeft - height[left])
            // can be added to the result, no matter what values the un-visited heights are. Because height[right]
            // will always be able to hold the water of (maxLeft - height[left]).
            int left = 0; int right = height.Length - 1;
            int result = 0;
            int maxLeft = 0, maxRight = 0; // The max height from left or right.
            while (left <= right)
            {
                if (height[left] <= height[right])
                {
                    if (height[left] >= maxLeft) maxLeft = height[left];
                    else result += maxLeft - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= maxRight) maxRight = height[right];
                    else result += maxRight - height[right];
                    right--;
                }
            }
            return result;
        }
    }
}
