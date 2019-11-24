using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 992. Subarrays with K Different Integers
     * 
     * Given an array A of positive integers, call a (contiguous, not necessarily distinct) subarray
     * of A good if the number of different integers in that subarray is exactly K.
     * 
     * (For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.)
     * 
     * Return the number of good subarrays of A.
     * 
     * Example 1:
     * 
     * Input: A = [1,2,1,2,3], K = 2
     * Output: 7
     * Explanation: Subarrays formed with exactly 2 different integers: [1,2], [2,1], [1,2], [2,3],
     * [1,2,1], [2,1,2], [1,2,1,2].
     * 
     * Example 2:
     * 
     * Input: A = [1,2,1,3,4], K = 3
     * Output: 3
     * Explanation: Subarrays formed with exactly 3 different integers: [1,2,1,3], [2,1,3], [1,3,4].
     *  
     * Note:
     * 1 <= A.length <= 20000
     * 1 <= A[i] <= A.length
     * 1 <= K <= A.length
     */
    public class Subarrays_with_K_Different_Integers
    {
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            // Sliding window.
            // We need to keep K unique numbers in the sliding window. The right bound of the 
            // sliding window is always the current number, but the left bound can "slide" in
            // a range, let's call it [l1,l2]. For example, K = 2:
            // 1, 2, 1, 2, 3
            // ↑     ↑  ↑
            // l1    l2 r
            // Subarrays [l1,r], [l1+1,r],[l1+2,r]...[l2,r] are all subarrays that satisfy the
            // condition. When we shrink until the number of unique numbers has just reached K,
            // we get l1. When we shrink until the left bound number's count is only 1 (one more
            // "left shrink" we will have only K-1 unique numbers), we get l2.
            int result = 0, prefix = 0; // prefix = l2 - l1
            var count = new Dictionary<int, int>();
            int numUnique = 0;
            for (int l = 0, r = 0; r < A.Length; r++)
            {
                count[A[r]] = count.GetValueOrDefault(A[r]) + 1;
                if (count[A[r]] == 1) numUnique++;
                while (numUnique > K) // Shrink util the number of unique numbers has just reached K
                {
                    if (--count[A[l]] == 0) numUnique--;
                    l++;
                    prefix = 0; // Reset l1.
                }
                while (count[A[l]] > 1) // "Shrink" until the left bound number's count is only 1.
                {
                    --count[A[l]];
                    l++;
                    prefix++;
                }
                if (numUnique == K) result += prefix + 1;
            }
            return result;
        }

        public int SubarraysWithKDistinct2(int[] A, int K)
        {
            // Inspired by https://leetcode.com/problems/subarrays-with-k-different-integers/discuss/234482/JavaC%2B%2BPython-Sliding-Window-atMost(K)-atMost(K-1)
            return AtMostK(A, K) - AtMostK(A, K - 1);
        }

        private int AtMostK(int[] A, int K)
        {
            int result = 0;
            var count = new Dictionary<int, int>();
            for (int l = 0, r = 0; r < A.Length; r++)
            {
                count[A[r]] = count.GetValueOrDefault(A[r]) + 1;
                if (count[A[r]] == 1) K--;
                while (K < 0)
                {
                    if (--count[A[l]] == 0) K++;
                    l++;
                }
                result += r - l + 1; // All the possible subarrays that ends with A[j].
            }
            return result;
        }
    }
}
