namespace Algorithms.LeetCode
{
    /* 80. Remove Duplicates from Sorted Array II
     * 
     * Given a sorted array nums, remove the duplicates in-place such that duplicates appeared at most twice and return the new length.
     * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
     * 
     * Example 1:
     * 
     * Given nums = [1,1,1,2,2,3],
     * 
     * Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
     * It doesn't matter what you leave beyond the returned length.
     * 
     * Example 2:
     * 
     * Given nums = [0,0,1,1,1,1,2,3,3],
     * 
     * Your function should return length = 7, with the first seven elements of nums being modified to 0, 0, 1, 1, 2, 3 and 3 respectively.
     * It doesn't matter what values are set beyond the returned length.
     */
    public class RemoveDuplicatesFromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {
            // Similar to "Problem 26. Remove Duplicates from Sorted Array".
            if (nums.Length < 2) return nums.Length;
            int i = 0;
            bool iFixed = false;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    nums[++i] = nums[j];
                    iFixed = false;
                }
                else if (!iFixed)
                {
                    nums[++i] = nums[j];
                    iFixed = true;
                }
            }
            return i + 1;
        }
    }
}
