using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 18. 4Sum
     * 
     * Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that
     * a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.
     * 
     * Note: The solution set must not contain duplicate quadruplets.
     * 
     * Example:
     * 
     * Given array nums = [1, 0, -1, 0, -2, 2], and target = 0.
     * 
     * A solution set is:
     * [
     *   [-1,  0, 0, 1],
     *   [-2, -1, 1, 2],
     *   [-2,  0, 0, 2]
     * ]
     */
    public class FourSumSolution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            // Similar to "Problem 15. 3Sum".
            var ret = new List<IList<int>>();
            if (nums == null || nums.Length < 4) return ret;
            Array.Sort(nums);
            for (int j = 0; j < nums.Length - 3; j++)
            {
                if (j != 0 && nums[j] == nums[j - 1]) continue; // skip duplicates
                // Find "3Sum" in nums[j+1,...,nums.Length -1], target is target-nums[j]
                for (int i = j + 1; i < nums.Length - 2; i++)
                {
                    // Find "2Sum" in nums[i+1,...,nums.Length -1], target is target-nums[j]-nums[i]
                    if (i == j + 1 || nums[i] != nums[i - 1])
                    {
                        for (int lo = i + 1, hi = nums.Length - 1; lo < hi;)
                        {
                            if (target - nums[j] - nums[i] > nums[lo] + nums[hi])
                            {
                                while (++lo < nums.Length && nums[lo] == nums[lo - 1]) ; // skip duplicates
                            }
                            else if (target - nums[j] - nums[i] < nums[lo] + nums[hi])
                            {
                                while (--hi > 0 && nums[hi] == nums[hi + 1]) ; // skip duplicates
                            }
                            else
                            {
                                ret.Add(new List<int>() { nums[j], nums[i], nums[lo], nums[hi] });
                                // skip duplicates
                                while (++lo < nums.Length && nums[lo] == nums[lo - 1]) ;
                                while (--hi > 0 && nums[hi] == nums[hi + 1]) ;
                            }
                        }
                    }
                }
            }
            return ret;
        }
    }
}
