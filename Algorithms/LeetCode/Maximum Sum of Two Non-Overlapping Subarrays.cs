using System;

namespace Algorithms.LeetCode
{
    /* 1031. Maximum Sum of Two Non-Overlapping Subarrays
     * 
     * Given an array A of non-negative integers, return the maximum sum of elements in two
     * non-overlapping (contiguous) subarrays, which have lengths L and M.  (For clarification,
     * the L-length subarray could occur before or after the M-length subarray.)
     * 
     * Example 1:
     * 
     * Input: A = [0,6,5,2,2,5,1,9,4], L = 1, M = 2
     * Output: 20
     * Explanation: One choice of subarrays is [9] with length 1, and [6,5] with length 2.
     * 
     * Example 2:
     * 
     * Input: A = [3,8,1,3,2,1,8,9,0], L = 3, M = 2
     * Output: 29
     * Explanation: One choice of subarrays is [3,8,1] with length 3, and [8,9] with length 2.
     * 
     * Example 3:
     * 
     * Input: A = [2,1,5,6,0,9,5,0,3,8], L = 4, M = 3
     * Output: 31
     * Explanation: One choice of subarrays is [5,6,0,9] with length 4, and [3,8] with length 3.
     * 
     * Note:
     * L >= 1
     * M >= 1
     * L + M <= A.length <= 1000
     * 0 <= A[i] <= 1000
     */
    public class Maximum_Sum_of_Two_Non_Overlapping_Subarrays
    {
        public int MaxSumTwoNoOverlap(int[] A, int L, int M)
        {
            // Inspired by https://leetcode.com/problems/maximum-sum-of-two-non-overlapping-subarrays/discuss/278251/JavaC++Python-O(N)Time-O(1)-Space/304272
            int[] sumsL = Init(L, A); // sumsL[i] is the sum of elements from i to i + L - 1
            int[] sumsM = Init(M, A); // sumsM is similar to sumsL.

            // For each i, maxL is the maximum array L before i.
            // maxL and sumsM[i] is not overlapping.
            int maxL = 0;
            int maxM = 0;
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (i - L >= 0) maxL = Math.Max(maxL, sumsL[i - L]);
                if (i - M >= 0) maxM = Math.Max(maxM, sumsM[i - M]);
                result = Math.Max(result, Math.Max(maxL + sumsM[i], maxM + sumsL[i]));
            }
            return result;
        }

        public int MaxSumTwoNoOverlap2(int[] A, int L, int M)
        {
            // First attempt: Brute-force. Try every pair of array L and array M, time complexity is O(N^2).
            int[] sumsL = Init(L, A);
            int[] sumsM = Init(M, A);
            int result = 0;
            for (int i = 0; i < A.Length - L + 1; i++)
            {
                for (int j = 0; j + M - 1 < i; j++) result = Math.Max(result, sumsL[i] + sumsM[j]);
                for (int j = i + L; j < A.Length - M + 1; j++) result = Math.Max(result, sumsL[i] + sumsM[j]);
            }

            return result;
        }

        private int[] Init(int size, int[] A)
        {
            int sum = 0;
            for (int i = 0; i < size; i++) sum += A[i];
            int[] sums = new int[A.Length];
            sums[0] = sum;
            for (int i = size; i < A.Length; i++)
            {
                sum -= A[i - size];
                sum += A[i];
                sums[i - size + 1] = sum;
            }
            return sums;
        }
    }
}
