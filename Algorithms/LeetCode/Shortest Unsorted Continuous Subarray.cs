namespace Algorithms.LeetCode
{
    /* 581. Shortest Unsorted Continuous Subarray
     * 
     * Given an integer array, you need to find one continuous subarray that if you only sort this subarray
     * in ascending order, then the whole array will be sorted in ascending order, too.
     * 
     * You need to find the shortest such subarray and output its length.
     * 
     * Example 1:
     * Input: [2, 6, 4, 8, 10, 9, 15]
     * Output: 5
     * Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in
     * ascending order.
     * 
     * Note:
     * Then length of the input array is in range [1, 10,000].
     * The input array may contain duplicates, so ascending order here means <=.
     */
    public class ShortestUnsortedContinuousSubarray
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            // "l" and "r" are the left and right boundaries of the expected shortest subarray so far.
            // Each time a number is less than a previously seen greater number, it should be the
            // right boundary, and the left boundary may also expand accordingly.
            // I think the time complexity should be O(n) because "l" only fowards in one direction.
            int l = -1, r = -1;
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < max)
                {
                    // The first time we find a "mismatch", just initialize l to i - 1.
                    if (l == -1) l = i - 1;
                    r = i;
                    while (l - 1 >= 0 && nums[l - 1] > nums[i]) l--;
                }
                else max = nums[i];
            }

            if (l == -1) return 0;
            return r - l + 1;
        }
    }
}
