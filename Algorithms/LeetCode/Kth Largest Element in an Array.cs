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
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int v = nums[lo]; // partitioning item
                int i = lo + 1, j = hi;
                while (i <= j)
                {
                    // descending order
                    if (nums[i] < v && nums[j] > v)
                    {
                        Swap(nums, i++, j--);
                    }
                    else if (nums[i] >= v)
                    {
                        i++;
                    }
                    else if (nums[j] <= v)
                    {
                        j--;
                    }
                }

                Swap(nums, lo, j);

                if (j + 1 < k) lo = j + 1; // j + 1 indicates the rank of nums[j].
                else if (j + 1 > k) hi = j - 1;
                else return nums[j];
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
