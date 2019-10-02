namespace Algorithms.LeetCode
{
    /* 231. Power of Two
     * 
     * Given an integer, write a function to determine if it is a power of two.
     * 
     * Example 1:
     * 
     * Input: 1
     * Output: true 
     * Explanation: 2^0 = 1
     * 
     * Example 2:
     * 
     * Input: 16
     * Output: true
     * Explanation: 2^4 = 16
     * 
     * Example 3:
     * 
     * Input: 218
     * Output: false
     */
    public class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            // Same as "Problem 326. Power of Three".
            // 1073741824 is 2^30, the max power of two that an integer can represent.(2^31 > int.MaxValue)
            return n > 0 && 1073741824 % n == 0;
        }
    }
}
