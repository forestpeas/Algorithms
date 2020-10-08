using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 456. 132 Pattern
     * 
     * Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i],
     * nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].
     * 
     * Return true if there is a 132 pattern in nums, otherwise return false.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3,4]
     * Output: false
     * Explanation: There is no 132 pattern in the sequence.
     * Example 2:
     * 
     * Input: nums = [3,1,4,2]
     * Output: true
     * Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
     * Example 3:
     * 
     * Input: nums = [-1,3,2,0]
     * Output: true
     * Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
     */
    public class _132_Pattern
    {
        public bool Find132pattern(int[] nums)
        {
            var ranges = new Stack<int[]>();
            bool rise = true;
            int lo = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (rise) ranges.Push(new int[] { lo, nums[i - 1] });
                    rise = false;
                }
                else if (nums[i] > nums[i - 1])
                {
                    if (!rise) lo = nums[i - 1];
                    rise = true;
                }

                while (ranges.Count != 0 && nums[i] > ranges.Peek()[1])
                {
                    ranges.Pop();
                }
                if (ranges.Count != 0 && nums[i] > ranges.Peek()[0] && nums[i] < ranges.Peek()[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
