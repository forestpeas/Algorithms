﻿using System;

namespace Algorithms.LeetCode
{
    /* 1299. Replace Elements with Greatest Element on Right Side
     * 
     * Given an array arr, replace every element in that array with the greatest element among the
     * elements to its right, and replace the last element with -1.
     * 
     * After doing so, return the array.
     * 
     * Example 1:
     * 
     * Input: arr = [17,18,5,4,6,1]
     * Output: [18,6,6,6,1,-1]
     * 
     * Constraints:
     * 
     *     1 <= arr.length <= 10^4
     *     1 <= arr[i] <= 10^5
     */
    public class Replace_Elements_with_Greatest_Element_on_Right_Side
    {
        public int[] ReplaceElements(int[] arr)
        {
            int max = -1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int tmp = arr[i];
                arr[i] = max;
                max = Math.Max(max, tmp);
            }
            return arr;
        }
    }
}
