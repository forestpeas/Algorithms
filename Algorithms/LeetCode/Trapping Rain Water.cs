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
    }
}
