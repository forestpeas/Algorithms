using System;

namespace Algorithms.LeetCode
{
    /* 4. Median of Two Sorted Arrays
     * There are two sorted arrays nums1 and nums2 of size m and n respectively.
     * Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
     * You may assume nums1 and nums2 cannot be both empty.
     * 
     * Example 1:
     * 
     * nums1 = [1, 3]
     * nums2 = [2]
     * 
     * The median is 2.0
     * 
     * Example 2:
     * 
     * nums1 = [1, 2]
     * nums2 = [3, 4]
     * 
     * The median is (2 + 3)/2 = 2.5
     */
    public class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // i and j are two indexes pointing to the first element on the right side of the "split line".
            // Every element on the left should be smaller than those on the right.
            // For example:
            // 1 | 2 
            // 3 | 4 5
            // step 1: i = 1, j = 1
            //
            // 1 2 |
            //     | 3 4 5
            // step 2: i = 2, j = 0
            int m = nums1.Length, n = nums2.Length;
            if (m > n)
            {
                // Because the final splitting line will always cuts through the longer array,
                // and we don't want negative i or j (variables used below).
                return FindMedianSortedArrays(nums2, nums1);
            }
            if (m + n == 1) return nums2[0];

            int lo = 0, hi = m;
            while (lo <= hi)
            {
                int i = (lo + hi) / 2;
                int j = (m + n) / 2 - i; // i + j = m - i + n - j
                if (i > 0 && nums1[i - 1] > nums2[j])
                {
                    hi = i;
                }
                else if (i < m && nums2[j - 1] > nums1[i])
                {
                    lo = i + 1;
                }
                else
                {
                    int leftMax, rightMin;
                    if (i == 0) leftMax = nums2[j - 1];
                    else if (j == 0) leftMax = nums1[i - 1];
                    else leftMax = Math.Max(nums1[i - 1], nums2[j - 1]);

                    if (i == m) rightMin = nums2[j];
                    else if (j == n) rightMin = nums1[i];
                    else rightMin = Math.Min(nums1[i], nums2[j]);

                    if (i + j < m - i + n - j) return rightMin;
                    return ((double)leftMax + rightMin) / 2;
                }
            }
            throw new ArgumentException();
        }
    }
}
