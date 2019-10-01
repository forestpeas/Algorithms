namespace Algorithms.LeetCode
{
    /* 324. Wiggle Sort II
     * 
     * Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....
     * 
     * Example 1:
     * 
     * Input: nums = [1, 5, 1, 1, 6, 4]
     * Output: One possible answer is [1, 4, 1, 5, 1, 6].
     * 
     * Example 2:
     * 
     * Input: nums = [1, 3, 2, 2, 3, 1]
     * Output: One possible answer is [2, 3, 1, 3, 1, 2].
     * 
     * Note:
     * You may assume all input has valid answer.
     * 
     * Follow Up:
     * Can you do it in O(n) time and/or in-place with O(1) extra space?
     */
    public class WiggleSortII
    {
        public void WiggleSort(int[] nums)
        {
            // We can divide nums into two groups, one group that contains the larger half, another
            // contains the smaller half. For example, nums = [1,2,3,4,5,6]
            // After FindKthLargest(nums, nums.Length / 2):
            // nums = [6,5,4, 1,2,3]
            //         -----  -----
            //         large  small
            // Then we should place the smaller numbers in the positions with even index, and the larger
            // numbers in the position with odd index, like this(s is small, l is large):
            // [s,l,s,l,s,l]
            // So swap the even-indexed numbers in the larger group with the odd-indexed numbers in the
            // smaller group:
            // nums = [1,5,3,6,2,4]
            //        [s,l,s,l,s,l]
            // Finally, we should also consider this case:
            // nums = [4,5,5,5, 5,6,6,6] (After FindKthLargest)
            // There are 3 "5" that belongs to the smaller group, and 1 "5" that belongs to the larger group.
            // Because the order of even-indexed numbers or odd-indexed numbers does not affect the result,
            // we should move all the "5" in the even-indexed numbers to the beginning, an all the "5" in
            // the odd-indexed numbers to the end, so that the "5"s won't be next to each other.
            // [s,l,s,l,s,l,s,l]
            //  ↑   ↑   ↑     ↑
            //  5   5   5     5
            if (nums.Length < 2) return;

            new KthLargestElementInAnArray().FindKthLargest(nums, nums.Length / 2); // O(n) in average.
            int median = nums[nums.Length / 2 - 1]; // Not the strict median.

            int i = 0;
            int j = nums.Length / 2;
            if (j % 2 == 0) j++;
            while (j < nums.Length)
            {
                Swap(nums, i, j);
                i += 2;
                j += 2;
            }

            int lo = 0;
            int hi = nums.Length % 2 == 0 ? nums.Length - 2 : nums.Length - 1;
            while (lo < hi)
            {
                if (nums[lo] == median) lo += 2;
                else if (nums[hi] != median) hi -= 2;
                else
                {
                    Swap(nums, lo, hi);
                    lo += 2;
                    hi -= 2;
                }
            }
            lo = 1;
            hi = nums.Length % 2 == 0 ? nums.Length - 1 : nums.Length - 2;
            while (lo < hi)
            {
                if (nums[lo] != median) lo += 2;
                else if (nums[hi] == median) hi -= 2;
                else
                {
                    Swap(nums, lo, hi);
                    lo += 2;
                    hi -= 2;
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
