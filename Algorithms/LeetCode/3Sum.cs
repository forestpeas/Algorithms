using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ret = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return ret;
            Array.Sort(nums); // If we don't sort it first, it will be hard to eliminate the duplicate triplets.
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Find "2Sums" in nums[i+1,...,nums.Length -1], target is -nums[i].
                if (i == 0 || nums[i] != nums[i - 1]) // skip the duplicate
                {
                    // Since the array is sorted, the algorithm below avoids many unnecessary comparisons of the O(n^2) brute force solution.
                    for (int lo = i + 1, hi = nums.Length - 1; lo != hi;)
                    {
                        if (lo == i + 1 || nums[lo] != nums[lo - 1]) // skip the duplicate
                        {
                            if (-nums[i] > nums[lo] + nums[hi]) lo++;
                            else if (-nums[i] < nums[lo] + nums[hi]) hi--;
                            else ret.Add(new List<int>() { nums[i], nums[lo++], nums[hi] });
                        }
                        else
                        {
                            lo++;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
