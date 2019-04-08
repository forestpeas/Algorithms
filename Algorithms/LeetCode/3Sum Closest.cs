using System;

namespace Algorithms.LeetCode
{
    /* 16. 3Sum Closest
     * Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target.
     * Return the sum of the three integers. You may assume that each input would have exactly one solution.
     * 
     * Example:
     * 
     * Given array nums = [-1, 2, 1, -4], and target = 1.
     * 
     * The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
     */
    public class ThreeSumClosestSolution
    {
        // Your runtime beats 100.00 % of csharp submissions.
        // Your memory usage beats 54.55 % of csharp submissions.
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null || nums.Length < 3) return 0;
            Array.Sort(nums);
            int difference = int.MaxValue;
            int closest = 0;
            // similar to Problem 15 ThreeSum
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // find "2Sum" in nums[i+1,...,nums.Length -1], target is target-nums[i]
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    int target2Sum = target - nums[i];
                    for (int lo = i + 1, hi = nums.Length - 1; lo < hi;)
                    {
                        int current2Sum = nums[lo] + nums[hi];

                        if (target2Sum > current2Sum)
                        {
                            while (++lo < nums.Length && nums[lo] == nums[lo - 1]) ; // skip duplicates
                        }
                        else if (target2Sum < current2Sum)
                        {
                            while (--hi > 0 && nums[hi] == nums[hi + 1]) ; // skip duplicates
                        }
                        else
                        {
                            return target;
                        }

                        int current3Sum = current2Sum + nums[i];
                        int currentDifference = Math.Abs(current3Sum - target);
                        if (currentDifference < difference)
                        {
                            closest = current3Sum;
                            difference = currentDifference;
                        }
                    }
                }
            }
            return closest;
        }
    }
}
