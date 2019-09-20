namespace Algorithms.LeetCode
{
    /* 215. Kth Largest Element in an Array
     * 
     * Find the kth largest element in an unsorted array. Note that it is the kth largest
     * element in the sorted order, not the kth distinct element.
     * 
     * Example 1:
     * 
     * Input: [3,2,1,5,6,4] and k = 2
     * Output: 5
     * 
     * Example 2:
     * 
     * Input: [3,2,3,1,2,4,5,5,6] and k = 4
     * Output: 4
     * 
     * Note: 
     * You may assume k is always valid, 1 ≤ k ≤ array's length.
     */
    public class KthLargestElementInAnArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            // Quick select.
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int lo = l + 1;
                int hi = r;
                while (true)
                {
                    while (lo <= hi && nums[lo] >= nums[l]) lo++;
                    while (lo <= hi && nums[hi] <= nums[l]) hi--;
                    if (lo > hi) break;
                    Swap(nums, lo++, hi--);
                }
                Swap(nums, l, hi);

                if (hi + 1 < k) l = hi + 1; // hi + 1 indicates the rank of nums[hi].
                else if (hi + 1 > k) r = hi - 1;
                else return nums[hi];
            }

            return -1; // k is invalid.
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
