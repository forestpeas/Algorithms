using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 84. Largest Rectangle in Histogram
     * 
     * Given n non-negative integers representing the histogram's bar height where
     * the width of each bar is 1, find the area of largest rectangle in the histogram.
     * 
     * Example:
     * 
     * Input: [2,1,5,6,2,3]
     * Output: 10
     */
    public class LargestRectangleInHistogram
    {
        private class Bar
        {
            public int height;
            public int index;
        }

        public int LargestRectangleArea(int[] heights)
        {
            // When we meet a height that is less than the previous height,
            // we can immediately get the area of a rectangle with a previous height.
            // For example: heights = [1,2,3,0]
            // When we meet 0, we can get 3*1, 2*2 and 1*3.
            // But if a height is greater than the previous height, we can't draw any conclusion yet
            // because there may be some more heights that can add to an area.
            var stack = new Stack<Bar>(); // The stack will be holding sorted heights, like 1,2,3.
            int largestArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (!stack.TryPeek(out var top) || heights[i] > top.height)
                {
                    stack.Push(new Bar() { height = heights[i], index = i });
                }
                else if (heights[i] < top.height)
                {
                    int index = top.index;
                    do
                    {
                        largestArea = Math.Max(largestArea, top.height * (i - top.index));
                        index = top.index;
                        stack.Pop();
                    } while (stack.TryPeek(out top) && heights[i] < top.height);
                    stack.Push(new Bar() { height = heights[i], index = index });
                }
            }
            while (stack.TryPop(out var top))
            {
                largestArea = Math.Max(largestArea, top.height * (heights.Length - top.index));
            }
            return largestArea;
        }
    }
}
