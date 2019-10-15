using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 220. Contains Duplicate III
     * 
     * Given an array of integers, find out whether there are two distinct indices i and j in the array
     * such that the absolute difference between nums[i] and nums[j] is at most t and the absolute difference
     * between i and j is at most k.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3,1], k = 3, t = 0
     * Output: true
     * 
     * Example 2:
     * 
     * Input: nums = [1,0,1,1], k = 1, t = 2
     * Output: true
     * 
     * Example 3:
     * 
     * Input: nums = [1,5,9,1,5,9], k = 2, t = 3
     * Output: false
     */
    public class ContainsDuplicateIII
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            // Maintains a sliding window of size k, for each number n, check whether the window
            // contains a number n' such that n - t <= n' <= n + t.
            if (k <= 0 || t < 0) return false;
            var set = new SortedSet<long>();
            for (int i = 0; i < nums.Length; i++)
            {
                var view = set.GetViewBetween(nums[i] - (long)t, nums[i] + (long)t); // Prevent overflow.
                if (view.Count != 0) return true;
                set.Add(nums[i]);
                if (i >= k) set.Remove(nums[i - k]);
            }
            return false;
        }
    }
}
