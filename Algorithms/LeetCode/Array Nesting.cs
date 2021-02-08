using System;

namespace Algorithms.LeetCode
{
    /* 565. Array Nesting
     * 
     * A zero-indexed array A of length N contains all integers from 0 to N-1. Find and return
     * the longest length of set S, where S[i] = {A[i], A[A[i]], A[A[A[i]]], ... } subjected
     * to the rule below.
     * 
     * Suppose the first element in S starts with the selection of element A[i] of index = i,
     * the next element in S should be A[A[i]], and then A[A[A[i]]]… By that analogy, we stop
     * adding right before a duplicate element occurs in S.
     * 
     * Example 1:
     * 
     * Input: A = [5,4,0,3,1,6,2]
     * Output: 4
     * Explanation: 
     * A[0] = 5, A[1] = 4, A[2] = 0, A[3] = 3, A[4] = 1, A[5] = 6, A[6] = 2.
     * 
     * One of the longest S[K]:
     * S[0] = {A[0], A[5], A[6], A[2]} = {5, 6, 2, 0}
     */
    public class Array_Nesting
    {
        public int ArrayNesting(int[] nums)
        {
            // nums is just a bunch of independent list nodes, find the longest among them
            int res = 0;
            bool[] visited = new bool[nums.Length];
            foreach (int num in nums)
            {
                int curr = 0, i = num;
                while (!visited[i])
                {
                    visited[i] = true;
                    curr++;
                    i = nums[i];
                }
                res = Math.Max(res, curr);
            }
            return res;
        }
    }
}
