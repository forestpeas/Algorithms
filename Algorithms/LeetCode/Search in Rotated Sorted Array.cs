﻿namespace Algorithms.LeetCode
{
    /* 33. Search in Rotated Sorted Array
     * 
     * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
     * (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
     * You are given a target value to search. If found in the array return its index, otherwise return -1.
     * You may assume no duplicate exists in the array.
     * Your algorithm's runtime complexity must be in the order of O(log n).
     * 
     * Example 1:
     * 
     * Input: nums = [4,5,6,7,0,1,2], target = 0
     * Output: 4
     * 
     * Example 2:
     * 
     * Input: nums = [4,5,6,7,0,1,2], target = 3
     * Output: -1
     */
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            // Find the "rotated point" - the index of the smallest value in nums.
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] < nums[hi])
                {
                    hi = mid; // The right part is in order.
                }
                else
                {
                    lo = mid + 1; // The left part is in order.
                }
            }
            // Now lo is the "rotated point".
            // Binary search with the appropriate offset.
            int offset = lo;
            lo = 0;
            hi = nums.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int mappedMid = (mid + offset) % nums.Length;
                int midValue = nums[mappedMid];
                if (midValue > target)
                {
                    hi = mid;
                }
                else if (midValue < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mappedMid;
                }
            }

            return -1;
        }
    }
}
