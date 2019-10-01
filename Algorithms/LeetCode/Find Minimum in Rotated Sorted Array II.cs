namespace Algorithms.LeetCode
{
    /* 154. Find Minimum in Rotated Sorted Array II
     * 
     * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
     * (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).
     * Find the minimum element.
     * The array may contain duplicates.
     * 
     * Example 1:
     * 
     * Input: [1,3,5]
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: [2,2,2,0,1]
     * Output: 0
     * 
     * Note:
     * This is a follow up problem to Find Minimum in Rotated Sorted Array.
     * Would allow duplicates affect the run-time complexity? How and why?
     */
    public class FindMinimumInRotatedSortedArrayII
    {
        public int FindMin(int[] nums)
        {
            // Same as the first step of "81. Search in Rotated Sorted Array II".
            int lo = 0;
            int hi = nums.Length - 1;

            while (nums[lo] == nums[hi])
            {
                if (lo + 1 >= nums.Length) break;
                lo++;
            }

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] <= nums[hi])
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return nums[lo];
        }
    }
}
