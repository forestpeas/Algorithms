namespace Algorithms.LeetCode
{
    /* 1201. Ugly Number III
     * 
     * Write a program to find the n-th ugly number.
     * 
     * Ugly numbers are positive integers which are divisible by a or b or c. 
     * 
     * Example 1:
     * 
     * Input: n = 3, a = 2, b = 3, c = 5
     * Output: 4
     * Explanation: The ugly numbers are 2, 3, 4, 5, 6, 8, 9, 10... The 3rd is 4.
     * 
     * Example 2:
     * 
     * Input: n = 4, a = 2, b = 3, c = 4
     * Output: 6
     * Explanation: The ugly numbers are 2, 3, 4, 6, 8, 9, 10, 12... The 4th is 6.
     * 
     * Example 3:
     * 
     * Input: n = 5, a = 2, b = 11, c = 13
     * Output: 10
     * Explanation: The ugly numbers are 2, 4, 6, 8, 10, 11, 12, 13... The 5th is 10.
     * 
     * Example 4:
     * 
     * Input: n = 1000000000, a = 2, b = 217983653, c = 336916467
     * Output: 1999999984
     * 
     * Constraints:
     * It's guaranteed that the result will be in range [1, 2 * 10^9]
     */
    public class Ugly_Number_III
    {
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            // Inspired by https://leetcode.com/problems/ugly-number-iii/discuss/387539/cpp-Binary-Search-with-picture-and-Binary-Search-Template
            // F(n) is the total number of ugly numbers <= n, as well as the rank of n if n is an ugly number.
            // a is the total number of numbers that are divisible by a.
            // b is the total number of numbers that are divisible by b.
            // c is the total number of numbers that are divisible by c.
            // F(N) = a + b + c - a ∩ c - a ∩ b - b ∩ c + a ∩ b ∩ c
            // Note that there can be multiple "valid" numbers during the search, and we need to find the leftmost one.
            // I don't know how to prove it in mathematics. I simply guess it's like this: [i...j] are all "valid" numbers
            // that have the rank n, but only i is divisible by a, b and c.
            long ab = (long)a * b / Gcd(a, b);
            long ac = (long)a * c / Gcd(a, c);
            long bc = (long)b * c / Gcd(b, c);
            long abc = a * bc / Gcd(a, bc);

            int lo = 1, hi = int.MaxValue;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                long rank = mid / a + mid / b + mid / c - mid / ab - mid / ac - mid / bc + mid / abc;
                if (rank < n) lo = mid + 1;
                else hi = mid;
            }

            return lo;
        }

        private long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
    }
}
