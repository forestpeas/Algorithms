using System;

namespace Algorithms.LeetCode
{
    /* 1802. Maximum Value at a Given Index in a Bounded Array
     * 
     * You are given three positive integers n, index and maxSum. You want to construct an array nums
     * (0-indexed) that satisfies the following conditions:
     * 
     * nums.length == n
     * nums[i] is a positive integer where 0 <= i < n.
     * abs(nums[i] - nums[i+1]) <= 1 where 0 <= i < n-1.
     * The sum of all the elements of nums does not exceed maxSum.
     * nums[index] is maximized.
     * 
     * Return nums[index] of the constructed array.
     * 
     * Note that abs(x) equals x if x >= 0, and -x otherwise.
     * 
     * Example 1:
     * 
     * Input: n = 4, index = 2,  maxSum = 6
     * Output: 2
     * Explanation: The arrays [1,1,2,1] and [1,2,2,1] satisfy all the conditions. There are no other valid
     * arrays with a larger value at the given index.
     * 
     * Example 2:
     * 
     * Input: n = 6, index = 1,  maxSum = 10
     * Output: 3
     */
    public class Maximum_Value_at_a_Given_Index_in_a_Bounded_Array
    {
        public int MaxValue(int n, int index, int maxSum)
        {
            int lo = 1, hi = maxSum + 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                long sum = GetSum(mid, index + 1); // sum of a[0..index]
                sum += GetSum(mid, n - index); // sum of a[index..end]
                sum -= mid; // a[index] was added twice
                if (sum > maxSum)
                {
                    hi = mid;
                }
                else if (sum < maxSum)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return lo - 1;

        }

        private long GetSum(long a1, long n)
        {
            long extraSum = Math.Max(0, n - a1); // e.g. sum of the last three "1"s from: 3,2,1,1,1,1
            if (n > a1) n = a1;
            long res = n * a1 - n * (n - 1) / 2; // sum of a1,...,3,2,1
            return res + extraSum;
        }
    }
}
