using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 128. Longest Consecutive Sequence
     * 
     * Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
     * Your algorithm should run in O(n) complexity.
     * 
     * Example:
     * 
     * Input: [100, 4, 200, 1, 3, 2]
     * Output: 4
     * Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
     */
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            // Because we first check whether num - 1 is in nums, the only situation to enter
            // the while loop is that we have found the start of a sequence. And the "while"
            // body can only run for at most n times in total, so the overall runtime is O(n).
            var numSet = new HashSet<int>(nums);
            int result = 0;
            foreach (int num in nums)
            {
                if (!numSet.Contains(num - 1))
                {
                    int consecutiveNum = num + 1;
                    while (numSet.Contains(consecutiveNum))
                    {
                        consecutiveNum++;
                    }
                    result = Math.Max(result, consecutiveNum - num);
                }
            }

            return result;
        }
    }
}
