﻿using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1200. Minimum Absolute Difference
     * 
     * Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any
     * two elements. 
     * 
     * Return a list of pairs in ascending order(with respect to pairs), each pair [a, b] follows
     * a, b are from arr
     * a < b
     * b - a equals to the minimum absolute difference of any two elements in arr
     * 
     * Example 1:
     * 
     * Input: arr = [4,2,1,3]
     * Output: [[1,2],[2,3],[3,4]]
     * Explanation: The minimum absolute difference is 1. List all pairs with difference equal to 1 in ascending order.
     * 
     * Example 2:
     * 
     * Input: arr = [1,3,6,10,15]
     * Output: [[1,3]]
     * 
     * Example 3:
     * 
     * Input: arr = [3,8,-10,23,19,-4,-14,27]
     * Output: [[-14,-10],[19,23],[23,27]]
     */
    public class Minimum_Absolute_Difference
    {
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            // The minimum absolute difference must be a difference between two consecutive elements in the sorted array.
            Array.Sort(arr);
            int minDiff = int.MaxValue;
            var result = new List<IList<int>>();
            for (int i = 1; i < arr.Length; i++)
            {
                int diff = arr[i] - arr[i - 1];
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result.Clear();
                }
                if (diff == minDiff) result.Add(new int[] { arr[i - 1], arr[i] });
            }

            return result;
        }
    }
}
