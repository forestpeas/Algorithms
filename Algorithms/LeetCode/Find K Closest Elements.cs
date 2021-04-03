using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 658. Find K Closest Elements
     * 
     * Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array.
     * The result should also be sorted in ascending order.
     * 
     * An integer a is closer to x than an integer b if:
     *     |a - x| < |b - x|, or
     *     |a - x| == |b - x| and a < b
     * 
     * Example 1:
     * 
     * Input: arr = [1,2,3,4,5], k = 4, x = 3
     * Output: [1,2,3,4]
     * 
     * Example 2:
     * 
     * Input: arr = [1,2,3,4,5], k = 4, x = -1
     * Output: [1,2,3,4]
     */
    public class Find_K_Closest_Elements
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int idx = Array.BinarySearch(arr, x);
            int l, r;
            if (idx >= 0)
            {
                l = idx - 1;
                r = idx + 1;
                k--;
            }
            else
            {
                idx = ~idx;
                l = idx - 1;
                r = idx;
            }
            while (k-- > 0)
            {
                if (l < 0) r++;
                else if (r >= arr.Length) l--;
                else if (x - arr[l] > arr[r] - x) r++;
                else l--;
            }

            return new ArraySegment<int>(arr, l + 1, r - l - 1);
        }
    }
}
