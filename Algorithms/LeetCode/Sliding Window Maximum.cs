using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 239. Sliding Window Maximum
     * 
     * Given an array nums, there is a sliding window of size k which is moving from the very left
     * of the array to the very right. You can only see the k numbers in the window. Each time the
     * sliding window moves right by one position. Return the max sliding window.
     * 
     * Example:
     * 
     * Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
     * Output: [3,3,5,5,6,7] 
     * Explanation: 
     * 
     * Window position                Max
     * ---------------               -----
     * [1  3  -1] -3  5  3  6  7       3
     *  1 [3  -1  -3] 5  3  6  7       3
     *  1  3 [-1  -3  5] 3  6  7       5
     *  1  3  -1 [-3  5  3] 6  7       5
     *  1  3  -1  -3 [5  3  6] 7       6
     *  1  3  -1  -3  5 [3  6  7]      7
     *  
     * Note: 
     * You may assume k is always valid, 1 ≤ k ≤ input array's size for non-empty array.
     * 
     * Follow up:
     * Could you solve it in linear time?
     */
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            /* Use a deque to hold the numbers in the sliding window. We can eliminate
             * some numbers because they can never be the maximum element in the window.
             * For example, in a window of [7  3  6], the 3 in the middle can never be
             * the maximum element, because 6 > 3 and 6 is on the right of 3. In this
             * way, the tail of the deque is always the the maximum element in the window.
             * 
             * Window position                deque(head -> tail)
             * ---------------                -------------------
             * [1  3  -1] -3  5  3  6  7      -1 -> 3
             *  1 [3  -1  -3] 5  3  6  7      -3 -> -1 -> 3
             *  1  3 [-1  -3  5] 3  6  7       5
             *  1  3  -1 [-3  5  3] 6  7       3 -> 5
             *  1  3  -1  -3 [5  3  6] 7       6
             *  1  3  -1  -3  5 [3  6  7]      7
             */
            if (nums.Length == 0) return new int[0];
            int[] result = new int[nums.Length - k + 1];
            var deque = new LinkedList<int>(); // Contains index of nums.
            for (int i = 0; i < nums.Length; i++)
            {
                if (deque.Last?.Value < i - k + 1)
                {
                    deque.RemoveLast();
                }

                // Remove all the smaller numbers before nums[i].
                while (deque.First != null && nums[deque.First.Value] < nums[i])
                {
                    deque.RemoveFirst();
                }

                deque.AddFirst(i);
                if (i - k + 1 >= 0)
                {
                    result[i - k + 1] = nums[deque.Last.Value];
                }
            }

            return result;
        }
    }
}
