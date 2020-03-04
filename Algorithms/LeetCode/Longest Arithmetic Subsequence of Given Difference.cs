using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1218. Longest Arithmetic Subsequence of Given Difference
     * 
     * Given an integer array arr and an integer difference, return the length of the longest subsequence in arr which is
     * an arithmetic sequence such that the difference between adjacent elements in the subsequence equals difference.
     * 
     * Example 1:
     * 
     * Input: arr = [1,2,3,4], difference = 1
     * Output: 4
     * Explanation: The longest arithmetic subsequence is [1,2,3,4].
     * 
     * Example 2:
     * 
     * Input: arr = [1,3,5,7], difference = 1
     * Output: 1
     * Explanation: The longest arithmetic subsequence is any single element.
     * 
     * Example 3:
     * 
     * Input: arr = [1,5,7,8,5,3,4,2,1], difference = -2
     * Output: 4
     * Explanation: The longest arithmetic subsequence is [7,5,3,1].
     */
    public class Longest_Arithmetic_Subsequence_of_Given_Difference
    {
        public int LongestSubsequence(int[] arr, int difference)
        {
            // For each num in arr, map[num] is the length of the longest subsequence that ends with num.
            var map = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                map[num] = map.GetValueOrDefault(num - difference) + 1;
            }
            return map.Values.Max();
        }
    }
}
