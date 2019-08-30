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
            // Iterative approach: add the current number to each subset in the last step.
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
            foreach (int num in nums)
            {
                int length = subsets.Count;
                for (int i = 0; i < length; i++)
                {
                    subsets.Add(new List<int>(subsets[i]) { num });
                }
            }
            return subsets;
        }

        public IList<IList<int>> Subsets2(int[] nums)
        {
            // To get a subset, for each number we choose whether to put it in the subset.
            // For example: nums = [1,2,3], there are 2^3 = 8 subsets.
            // Each number in 0~7 correspond to a subset. 
            // The 1-bit means the number in this position should be in the subset.
            // 000 // Nothing should be chosen.
            // 001 // First number should be chosen.
            // 010 // Second number should be chosen.
            // 011 // First and second number should be chosen.
            // 100 // Third number should be chosen.
            // 101 // ...
            // 110
            // 111
            int n = 1 << nums.Length;
            var subsets = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                var subset = new List<int>();
                for (int j = 0; j < nums.Length; j++)
                {
                    if (((i >> j) & 1) == 1) // Whether the j-th bit in i is 1.
                    {
                        subset.Add(nums[j]);
                    }
                }
                subsets.Add(subset);
            }
            return subsets;
        }
    }
}
