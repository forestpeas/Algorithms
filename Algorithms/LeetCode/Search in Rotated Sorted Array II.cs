namespace Algorithms.LeetCode
{
    /* 81. Search in Rotated Sorted Array II
     * 
     * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
     * (i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).
     * You are given a target value to search. If found in the array return true, otherwise return false.
     * 
     * Follow up:
     * This is a follow up problem to Search in Rotated Sorted Array, where nums may contain duplicates.
     * Would this affect the run-time complexity? How and why?
     * 
     * Example 1:
     * 
     * Input: nums = [2,5,6,0,0,1,2], target = 0
     * Output: true
     * 
     * Example 2:
     * 
     * Input: nums = [2,5,6,0,0,1,2], target = 3
     * Output: false
     */
    public class SearchInRotatedSortedArrayII
    {
        public bool Search(int[] nums, int target)
        {
            // Almost the same as "Problem 33. Search in Rotated Sorted Array".
            if (nums.Length < 1) return false;
            // Find the "rotated point" - the index of the smallest value in nums.
            int lo = 0;
            int hi = nums.Length - 1;
            // Eliminate the duplicates from the beginning. For example: nums = [2, 2, 2, 0, 2, 2] or nums = [1, 1, 1, 1, 3]
            if (nums[lo] == nums[hi])
            {
                while (lo + 1 < nums.Length && nums[lo] == nums[lo + 1]) lo++;
            }
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] <= nums[hi])
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            // Binary search with the appropriate offset
            int offset = lo;
            lo = 0;
            hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                int mappedMid = (mid + offset) % nums.Length;
                int midValue = nums[mappedMid];
                if (midValue > target)
                {
                    hi = mid - 1;
                }
                else if (midValue < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
