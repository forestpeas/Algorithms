﻿using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 446. Arithmetic Slices II - Subsequence
     * 
     * A sequence of numbers is called arithmetic if it consists of at least three elements and if the
     * difference between any two consecutive elements is the same.
     * 
     * For example, these are arithmetic sequences:
     * 
     * 1, 3, 5, 7, 9
     * 7, 7, 7, 7
     * 3, -1, -5, -9
     * The following sequence is not arithmetic.
     * 
     * 1, 1, 2, 5, 7
     *  
     * A zero-indexed array A consisting of N numbers is given. A subsequence slice of that array
     * is any sequence of integers (P0, P1, ..., Pk) such that 0 ≤ P0 < P1 < ... < Pk < N.
     * 
     * A subsequence slice (P0, P1, ..., Pk) of array A is called arithmetic if the sequence A[P0],
     * A[P1], ..., A[Pk-1], A[Pk] is arithmetic. In particular, this means that k ≥ 2.
     * 
     * The function should return the number of arithmetic subsequence slices in the array A.
     * 
     * The input contains N integers. Every integer is in the range of -231 and 231-1 and 0 ≤ N ≤ 1000.
     * The output is guaranteed to be less than 231-1.
     *  
     * Example:
     * 
     * Input: [2, 4, 6, 8, 10]
     * 
     * Output: 7
     * 
     * Explanation:
     * All arithmetic subsequence slices are:
     * [2,4,6]
     * [4,6,8]
     * [6,8,10]
     * [2,4,6,8]
     * [4,6,8,10]
     * [2,4,6,8,10]
     * [2,6,10]
     */
    public class Arithmetic_Slices_II_Subsequence
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            // mem[i][diff] represents the length of the longest arithmetic subsequence that ends with A[i]
            // (actually it's "length - 1"), and these elements form arithmetic subsequences with the
            // difference of "diff".
            var mem = new Dictionary<long, int>[A.Length];
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                mem[i] = new Dictionary<long, int>();
                for (int j = 0; j < i; j++)
                {
                    long diff = (long)A[i] - A[j];
                    int count = mem[j].GetValueOrDefault(diff);
                    mem[i][diff] = mem[i].GetValueOrDefault(diff) + count + 1;
                    res += count;
                }
            }
            return res;
        }
    }
}
