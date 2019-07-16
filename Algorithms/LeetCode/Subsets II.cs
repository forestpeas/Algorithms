using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 90. Subsets II
     * 
     * Given a collection of integers that might contain duplicates, nums,
     * return all possible subsets (the power set).
     * 
     * Note: The solution set must not contain duplicate subsets.
     * 
     * Example:
     * 
     * Input: [1,2,2]
     * Output:
     * [
     *   [2],
     *   [1],
     *   [1,2,2],
     *   [2,2],
     *   [1,2],
     *   []
     * ]
     */
    public class SubsetsII
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            // Similar to "Problem 78. Subsets".
            // For example: nums = [1,2,2]
            // Step 1-3 are the same, and we have:
            // []
            // [1]
            // [2]
            // [1,2]
            // Then we only have to add a "2" to the last two subsets.
            // We don't need to add a "2" to the first two subsets is because we have already done
            // so in the last step.
            // []
            // [1]
            // [2] -> [2,2]
            // [1,2] -> [1,2,2]
            // But this approach only works when duplicates are successive. 
            // So we need to sort the nums first.
            if (nums.Length < 1) return new int[][] { new int[0] };
            Array.Sort(nums);
            var subsets = new List<IList<int>>() { new int[0], new int[1] { nums[0] } };
            int lastLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                int length = subsets.Count;
                for (int j = nums[i] == nums[i - 1] ? lastLength : 0; j < length; j++)
                {
                    subsets.Add(new List<int>(subsets[j]) { nums[i] });
                }
                lastLength = length;
            }
            return subsets;
        }
    }
}
