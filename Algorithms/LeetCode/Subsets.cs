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
    }
}
