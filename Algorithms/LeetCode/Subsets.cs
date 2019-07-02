using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 78. Subsets
     * 
     * Given a set of distinct integers, nums, return all possible subsets (the power set).
     * Note: The solution set must not contain duplicate subsets.
     * 
     * Example:
     * 
     * Input: nums = [1,2,3]
     * Output:
     * [
     *   [3],
     *   [1],
     *   [2],
     *   [1,2,3],
     *   [1,3],
     *   [2,3],
     *   [1,2],
     *   []
     * ]
     */
    public class SubsetsSolution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            // For example: nums = [1,2,3]
            // First Step:
            // []
            // Second Step:
            // []
            // [1]
            // Third Step:
            // []
            // [1]
            // [2]
            // [1,2]
            // Fourth Step:
            // []
            // [1]
            // [2]
            // [1,2]
            // [3]
            // [1,3]
            // [2,3]
            // [1,2,3]
            var subsets = new List<IList<int>>() { new List<int>() };
            for (int i = 0; i < nums.Length; i++)
            {
                var newSubsets = new List<IList<int>>();
                foreach (var subset in subsets)
                {
                    newSubsets.Add(new List<int>(subset) { nums[i] });
                }
                subsets.AddRange(newSubsets);
            }
            return subsets;
        }
    }
}
