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
            Array.Sort(nums);
            var hashSet = new HashSet<int>();
            var subsets = new List<IList<int>>() { new List<int>() };
            int lastLength = 0;
            foreach (int num in nums)
            {
                int length = subsets.Count;
                for (int j = hashSet.Add(num) ? 0 : lastLength; j < length; j++)
                {
                    subsets.Add(new List<int>(subsets[j]) { num });
                }
                lastLength = length;
            }
            return subsets;
        }
    }
}
