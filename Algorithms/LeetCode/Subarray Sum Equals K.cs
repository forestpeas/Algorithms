using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 560. Subarray Sum Equals K
     * 
     * Given an array of integers and an integer k, you need to find the total number of continuous
     * subarrays whose sum equals to k.
     * 
     * Example 1:
     * Input:nums = [1,1,1], k = 2
     * Output: 2
     * 
     * Note:
     * The length of the array is in range [1, 20,000].
     * The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
     */
    public class SubarraySumEqualsK
    {
        public int SubarraySum(int[] nums, int k)
        {
            // Solution from Approach #4 of https://leetcode.com/articles/subarray-sum-equals-k/
            // (Didn't come up with this myself. Sliding window doesn't work because of negative numbers.)
            // sum(i,j)=sum(0,j)-sum(0,i)
            // map contains the frequencies of "prefix sums".
            int result = 0;
            var map = new Dictionary<int, int> { { 0, 1 } }; // In case, for example, nums[0] = k = 1.
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num;
                if (map.TryGetValue(sum - k, out int count)) result += count;
                map[sum] = map.GetValueOrDefault(sum) + 1;
            }

            return result;
        }
    }
}
