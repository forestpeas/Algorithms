﻿using System;

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
            int m = nums1.Length, n = nums2.Length;
            if (m == 0 && n == 0)
            {
                throw new ArgumentException();
            }
            if (m < n)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            if (n == 0) return (m & 1) == 1 ? nums1[m / 2] : ((double)nums1[m / 2] + nums1[m / 2 - 1]) / 2;

            int lo = 0, hi = m;
            while (lo <= hi)
            {
                int i = (hi + lo) / 2;
                int j = (m + n) / 2 - i;
                if (j < 0)
                {
                    hi = i;
                }
                else if (j > n)
                {
                    lo = i + 1;
                }
                else if (i != 0 && j != n && nums1[i - 1] > nums2[j])
                {
                    hi = i;
                }
                else if (j != 0 && i != m && nums2[j - 1] > nums1[i])
                {
                    lo = i + 1;
                }
                else
                {
                    int left;
                    int right;
                    if (i == 0)
                    {
                        left = nums2[j - 1];
                    }
                    else if (j == 0)
                    {
                        left = nums1[i - 1];
                    }
                    else
                    {
                        left = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }

                    if (i == m)
                    {
                        right = nums2[j];
                    }
                    else if (j == n)
                    {
                        right = nums1[i];
                    }
                    else
                    {
                        right = Math.Min(nums1[i], nums2[j]);
                    }
                    if (i + j < m - i + n - j)
                    {
                        return right;
                    }
                    return ((double)left + right) / 2;
                }
            }
            throw new ArgumentException();
        }
    }
}
