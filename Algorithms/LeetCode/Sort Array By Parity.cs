﻿namespace Algorithms.LeetCode
{
    /* 905. Sort Array By Parity
     * 
     * Given an array A of non-negative integers, return an array consisting of all
     * the even elements of A, followed by all the odd elements of A.
     * 
     * You may return any answer array that satisfies this condition.
     * 
     * Example 1:
     * 
     * Input: [3,1,2,4]
     * Output: [2,4,3,1]
     * The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
     * 
     * Note:
     * 1 <= A.length <= 5000
     * 0 <= A[i] <= 5000
     */
    public class SortArrayByParitySolution
    {
        public int[] SortArrayByParity(int[] A)
        {
            // Two pointers: elements before i is even, elements after j is odd.
            int i = 0, j = A.Length - 1;
            while (true)
            {
                while (i < j && A[i] % 2 == 0)
                {
                    i++;
                }

                while (i < j && A[j] % 2 == 1)
                {
                    j--;
                }

                if (i < j)
                {
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }
                else break;
            }

            return A;
        }
    }
}
