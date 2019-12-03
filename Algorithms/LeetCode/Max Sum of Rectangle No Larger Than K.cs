using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 363. Max Sum of Rectangle No Larger Than K
     * 
     * Given a non-empty 2D matrix matrix and an integer k, find the max sum of a rectangle in the matrix
     * such that its sum is no larger than k.
     * 
     * Example:
     * 
     * Input: matrix = [[1,0,1],[0,-2,3]], k = 2
     * Output: 2 
     * Explanation: Because the sum of rectangle [[0, 1], [-2, 3]] is 2,
     *              and 2 is the max number no larger than k (k = 2).
     * 
     * Note:
     * The rectangle inside the matrix must have an area > 0.
     * What if the number of rows is much larger than the number of columns?
     */
    public class Max_Sum_of_Rectangle_No_Larger_Than_K
    {
        public int MaxSumSubmatrix(int[][] matrix, int k)
        {
            // Inspired by https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/discuss/83599/Accepted-C%2B%2B-codes-with-explanation-and-references
            // This problem can be converted to sub-problems of a problem similar to "53. Maximum Subarray".
            // Each number in the 1-dimension array represents a subarray of a row, because this number
            // is accumulated from the numbers in that subarray.
            // The problem becomes "Find the subarray which has the largest sum but less than k".
            // We can use the "prefix sum" technique. For each current sum j so far, find a previous minimum
            // sum i such that j - i <= k.
            int m = matrix.Length;
            int n = matrix[0].Length;
            int result = int.MinValue;

            // Time complexity is O[n^2 * m * log(m)], so if n is larger than m, we'd better swap m and n.
            for (int left = 0; left < n; left++)
            {
                int[] nums = new int[m];
                for (int right = left; right < n; right++)
                {
                    for (int i = 0; i < m; i++) nums[i] += matrix[i][right];

                    var set = new TreeSet<int>() { 0 };
                    int j = 0;
                    foreach (int num in nums)
                    {
                        // Find the minimum i such that num[j] - num[i] <= k.
                        j += num;
                        if (set.Ceiling(j - k, out int i)) result = Math.Max(result, j - i);
                        set.Add(j);
                    }
                }
            }

            return result;
        }
    }
}
