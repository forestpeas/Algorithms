namespace Algorithms.LeetCode
{
    /* 34. Find First and Last Position of Element in Sorted Array
     * 
     * Given an array of integers nums sorted in ascending order, find the
     * starting and ending position of a given target value.
     * 
     * Your algorithm's runtime complexity must be in the order of O(log n).
     * 
     * If the target is not found in the array, return [-1, -1].
     * 
     * Example 1:
     * 
     * Input: nums = [5,7,7,8,8,10], target = 8
     * Output: [3,4]
     * 
     * Example 2:
     * 
     * Input: nums = [5,7,7,8,8,10], target = 6
     * Output: [-1,-1]
     */
    public class FindFirstAndLastPositionOfElementInSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] >= target)
                {
                    hi = mid; // When nums[mid] == target.
                }
                else
                {
                    lo = mid + 1;
                }
            }

            if (lo == nums.Length || nums[lo] != target) return new int[] { -1, -1 };
            int start = lo;

            lo = 0;
            hi = nums.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] > target)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1; // When nums[mid] == target.
                }
            }

            int end = lo - 1;
            return new int[] { start, end };
        }
    }
}
