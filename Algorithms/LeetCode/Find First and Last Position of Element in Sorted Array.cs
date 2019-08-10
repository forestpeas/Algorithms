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
            int result = BinarySearch(nums, 0, nums.Length - 1, target);
            int start = result;
            int end = result;
            // Maybe this is O(log n) instead of nO(log n) because in every iteration "result" is "cut in half"
            // instead of linear decrease.
            while (result != -1)
            {
                start = result;
                result = BinarySearch(nums, 0, result - 1, target);
            }

            result = end;
            while (result != -1)
            {
                end = result;
                result = BinarySearch(nums, result + 1, nums.Length - 1, target);
            }

            return new int[] { start, end };
        }

        private int BinarySearch(int[] nums, int lo, int hi, int target)
        {
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                int midValue = nums[mid];
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
                    return mid;
                }
            }
            return -1;
        }
    }
}
