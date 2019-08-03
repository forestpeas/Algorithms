namespace Algorithms.LeetCode
{
    /* 287. Find the Duplicate Number
     * 
     * Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive),
     * prove that at least one duplicate number must exist. Assume that there is only one duplicate number,
     * find the duplicate one.
     * 
     * Example 1:
     * 
     * Input: [1,3,4,2,2]
     * Output: 2
     * 
     * Example 2:
     * 
     * Input: [3,1,3,4,2]
     * Output: 3
     * 
     * Note:
     * You must not modify the array (assume the array is read only).
     * You must use only constant, O(1) extra space.
     * Your runtime complexity should be less than O(n2).
     * There is only one duplicate number in the array, but it could be repeated more than once.
     */
    public class FindTheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {
            // Similar to binary search.
            // Target is between [lo, hi].
            // For example: nums = [1,3,4,2,2]
            // lo = 1, hi = 4, mid = 2
            // There are 2 numbers in nums that is greater than 2.
            // How many numbers sould be? Normally there should be only a 3 and a 4.
            // And this matches our count, so the target shouldn't be above 2.
            // So target is now between [1,2], and mid = 1.
            // There are 4 numbers in nums that is greater than 1,
            // This time we count more numbers than needed(we only need 3), so the range becomes [2,2].
            int lo = 1;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                int count = 0;
                foreach (int num in nums)
                {
                    if (num > mid) count++;
                }
                if (count > nums.Length - 1 - mid)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }
            return lo;
        }
    }
}
