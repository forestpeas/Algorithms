using System;

namespace Algorithms.LeetCode
{
    /* 598. Range Addition II
     * 
     * You are given an m x n matrix M initialized with all 0's and an array of operations ops, where
     * ops[i] = [ai, bi] means M[x][y] should be incremented by one for all 0 <= x < ai and 0 <= y < bi.
     * 
     * Count and return the number of maximum integers in the matrix after performing all the operations.
     * https://leetcode.com/problems/range-addition-ii/
     */
    public class Range_Addition_II
    {
        public int MaxCount(int m, int n, int[][] ops)
        {
            int min1 = m, min2 = n;
            foreach (int[] op in ops)
            {
                min1 = Math.Min(min1, op[0]);
                min2 = Math.Min(min2, op[1]);
            }
            return min1 * min2;
        }
    }
}
