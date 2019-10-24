using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 300. Longest Increasing Subsequence
     * 
     * Given an unsorted array of integers, find the length of longest increasing subsequence.
     * 
     * Example:
     * 
     * Input: [10,9,2,5,3,7,101,18]
     * Output: 4 
     * Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
     * 
     * Note:
     * There may be more than one LIS combination, it is only necessary for you to return the length.
     * Your algorithm should run in O(n^2) complexity.
     * 
     * Follow up: Could you improve it to O(n log n) time complexity?
     */
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            // Patience sorting: https://www.cs.princeton.edu/courses/archive/spring13/cos423/lectures/LongestIncreasingSubsequence.pdf
            // Think of the nums as cards. We need to group the cards into piles. For each of the cards
            // from left to right, place the card onto the leftmost pile whose top card has a value higher
            // than (or equal to, for example:[2,5,5]) the current card's value, if there is no such pile,
            // form a new pile on the right. The number of piles is the length of longest increasing subsequence.
            var piles = new List<int>(nums.Length);
            foreach (int num in nums)
            {
                int idx = piles.BinarySearch(num);
                if (idx < 0) idx = ~idx;
                if (idx == piles.Count)
                {
                    piles.Add(num);
                }
                else
                {
                    piles[idx] = num;
                }
            }
            return piles.Count;
        }

        public int LengthOfLIS_DP(int[] nums)
        {
            // O(n^2). dp[i] is the length of the LIS of [nums[0]...nums[i]], with the restriction of nums[i] being
            // the tail of the LIS.
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                int maxLength = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        maxLength = Math.Max(maxLength, dp[j] + 1);
                    }
                }
                dp[i] = maxLength;
            }
            return dp.Max();
        }
    }
}
