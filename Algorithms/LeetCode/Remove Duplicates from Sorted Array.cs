﻿namespace Algorithms.LeetCode
{
    /* 26. Remove Duplicates from Sorted Array
     * 
     * Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
     * 
     * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
     * 
     * Example 1:
     * 
     * Given nums = [1,1,2],
     * 
     * Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
     * 
     * It doesn't matter what you leave beyond the returned length.
     * Example 2:
     * 
     * Given nums = [0,0,1,1,1,2,2,3,3,4],
     * 
     * Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.
     * 
     * It doesn't matter what values are set beyond the returned length.
    */
    public class RemoveDuplicatesFromSortedArray
    {
        // Your runtime beats 93.78 % of csharp submissions.
        // Your memory usage beats 16.67 % of csharp submissions.
        public int RemoveDuplicates(int[] nums)
        {
            // Two Pointers - we can keep two pointers i and j, where i is the slow-runner while j is the fast-runner.
            // We increment j to skip the duplicates, then we copy num[j] to num[i+1].
            if (nums.Length < 2) return nums.Length;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    nums[++i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
