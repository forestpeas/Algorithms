namespace Algorithms.LeetCode
{
    /* 172. Factorial Trailing Zeroes
     * 
     * Given an integer n, return the number of trailing zeroes in n!.
     * 
     * Example 1:
     * 
     * Input: 3
     * Output: 0
     * Explanation: 3! = 6, no trailing zero.
     * 
     * Example 2:
     * 
     * Input: 5
     * Output: 1
     * Explanation: 5! = 120, one trailing zero.
     * 
     * Note: Your solution should be in logarithmic time complexity.
     */
    public class FactorialTrailingZeroes
    {
        public int TrailingZeroes(int n)
        {
            // Prime-factorize n, and every pair of 2 and 5 results in a trailing zero.
            // 2 is much more than 5, so the problem becomes how many 5 are there?
            // For example, n = 26.
            // First we count the number of multiples of 5 from [1,2,3,...,n], 
            // which is n / 5 = 5, and they are 5, 10, 15 20, 25.
            // Notice that the last "25" is actually 5 * 5, So we must also count the
            // number of multiples of 25(which is n / 25 = 1), and also the multiples of 125...
            int result = 0;
            while (n >= 5)
            {
                n = n / 5;
                result += n;
            }
            return result;
        }
    }
}
