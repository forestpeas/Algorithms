using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 373. Find K Pairs with Smallest Sums
     * 
     * You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.
     * Define a pair (u,v) which consists of one element from the first array and one element from
     * the second array.
     * Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.
     * 
     * Example 1:
     * 
     * Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
     * Output: [[1,2],[1,4],[1,6]] 
     * Explanation: The first 3 pairs are returned from the sequence: 
     *              [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
     * 
     * Example 2:
     * 
     * Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
     * Output: [1,1],[1,1]
     * Explanation: The first 2 pairs are returned from the sequence: 
     *              [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
     * 
     * Example 3:
     * 
     * Input: nums1 = [1,2], nums2 = [3], k = 3
     * Output: [1,3],[2,3]
     * Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]
     */
    public class FindKPairsWithSmallestSums
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            // I think this problem is essentially the same as "378. Kth Smallest Element in a Sorted Matrix".
            // For example, nums1 = [1,7,11], nums2 = [2,4,6]
            //       2   4   6
            //    +------------
            //  1 |  3   5   7
            //  7 |  9  11  13
            // 11 | 13  15  17

            // To avoid duplicates, add the first row to pq first, or only move right on the first row.
            if (nums1.Length < 1 || nums2.Length < 1) return new int[0][];

            var result = new List<IList<int>>();
            var pq = new PriorityQueue<int[]>(Comparer<int[]>.Create((x, y) =>
            {
                return (nums1[y[0]] + nums2[y[1]]) - (nums1[x[0]] + nums2[x[1]]);
            }));

            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                pq.Add(new int[] { i, 0 });
            }

            while (pq.Count != 0 && result.Count < k)
            {
                var pair = pq.DeleteTop();
                result.Add(new int[] { nums1[pair[0]], nums2[pair[1]] });
                if (pair[1] + 1 < nums2.Length) pq.Add(new int[] { pair[0], pair[1] + 1 });
            }

            return result;
        }
    }
}
