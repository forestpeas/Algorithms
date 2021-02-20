namespace Algorithms.LeetCode
{
    /* 413. Arithmetic Slices
     * 
     * A sequence of number is called arithmetic if it consists of at least three elements and if the
     * difference between any two consecutive elements is the same.
     * 
     * For example, these are arithmetic sequence:
     * 1, 3, 5, 7, 9
     * 7, 7, 7, 7
     * 3, -1, -5, -9
     * The following sequence is not arithmetic.
     * 1, 1, 2, 5, 7
     * 
     * A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of
     * integers (P, Q) such that 0 <= P < Q < N.
     * 
     * A slice (P, Q) of array A is called arithmetic if the sequence:
     * A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.
     * 
     * The function should return the number of arithmetic slices in the array A.
     * 
     * Example:
     * 
     * A = [1, 2, 3, 4]
     * return: 3, for 3 arithmetic slices in A: [1, 2, 3], [2, 3, 4] and [1, 2, 3, 4] itself.
     */
    public class Arithmetic_Slices
    {
        public int NumberOfArithmeticSlices(int[] A)
        {
            // Essentially the problem asks us to find the number of all possible subarrays that
            // are arithmetic progressions and contain at least 3 elements. So this is somewhat
            // similar to problems like "992. Subarrays with K Different Integers" and "1248.
            // Count Number of Nice Subarrays".
            if (A.Length < 3) return 0;

            int result = 0;
            int diff = A[1] - A[0];
            for (int l = 0, r = 2; r < A.Length; r++)
            {
                if (A[r] - A[r - 1] != diff)
                {
                    diff = A[r] - A[r - 1];
                    l = r - 1;
                    continue;
                }

                result += r - l - 1; // A[l..r], A[l+1..r], ..., A[r-2,r]
            }

            return result;
        }
    }
}
