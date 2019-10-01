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

            int lo = 0;
            int hi = nums.Length - 1;

            // We need to consider the case when duplicate numbers are scattered at the beginning and end of the array,
            // for example: 
            // nums = [1,1,1,1,2,1,1].
            //                   ↑
            //              rotated point
            // If we use the same code from "Problem 33. Search in Rotated Sorted Array", we end up finding nums[0].
            // In this example, the "rotated point" should be nums[4], how do we find it?
            // We can see that it should be in the end of the array, so we eliminate the duplicates from the beginning.
            // Another example:
            // [2,2,1,2]
            // If we use the same code from "Problem 33. Search in Rotated Sorted Array", we end up finding nums[0].
            while (lo < nums.Length && nums[lo] == nums[hi])
            {
                lo++;
            }

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] <= nums[hi]) // If nums[mid] == nums[hi], we need to find the leftmost one, e.g. nums = [0, 1, 1, 1, 1, 2].
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            // Now lo is the "rotated point".
            // Binary search with the appropriate offset
            int offset = lo;
            lo = 0;
            hi = nums.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int mappedMid = (mid + offset) % nums.Length;
                int midValue = nums[mappedMid];
                if (midValue > target)
                {
                    hi = mid;
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
