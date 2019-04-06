using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 15. 3Sum
     * 
     * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
     * Find all unique triplets in the array which gives the sum of zero.
     * Note: The solution set must not contain duplicate triplets.
     * 
     * Example:
     * 
     * Given array nums = [-1, 0, 1, 2, -1, -4],
     * 
     * A solution set is:
     * [
     *   [-1, 0, 1],
     *   [-1, -1, 2]
     * ]
     */
    public class ThreeSumSolution
    {
        // Your runtime beats 78.78 % of csharp submissions.
        // Your memory usage beats 85.85 % of csharp submissions.
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ret = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return ret;
            Array.Sort(nums); // If we don't sort it first, it will be hard to eliminate the duplicate triplets.
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Find "2Sums" in nums[i+1,...,nums.Length -1], target is -nums[i].
                if (i == 0 || nums[i] != nums[i - 1]) // skip duplicates
                {
                    // Since the array is sorted, the algorithm below avoids many unnecessary comparisons of the O(n^2) brute force solution.
                    for (int lo = i + 1, hi = nums.Length - 1; lo < hi;)
                    {
                        if (-nums[i] > nums[lo] + nums[hi])
                        {
                            while (++lo < nums.Length && nums[lo] == nums[lo - 1]) ; // skip duplicates
                        }
                        else if (-nums[i] < nums[lo] + nums[hi])
                        {
                            while (--hi > 0 && nums[hi] == nums[hi + 1]) ; // skip duplicates
                        }
                        else
                        {
                            ret.Add(new List<int>() { nums[i], nums[lo], nums[hi] });
                            // skip duplicates
                            while (++lo < nums.Length && nums[lo] == nums[lo - 1]) ;
                            while (--hi > 0 && nums[hi] == nums[hi + 1]) ;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
